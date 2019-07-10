using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace LoggingCodefirst.Controllers
{  
    [Authorize]  
    public class BrandController : Controller
    {
        #region Private Members

        private readonly IBrandService _brandService;
        private readonly ILocalizationService<BrandResource> _localizer;
        private readonly IHostingEnvironment _hostingEnvironment;  
        
        #endregion
        
        #region Constructors

        public BrandController(
            IBrandService brandService, 
            ILocalizationService<BrandResource> localizer,
            IHostingEnvironment hostingEnvironment)
        {
            _localizer = localizer;
            _brandService = brandService;
            _hostingEnvironment = hostingEnvironment;  
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Index Brand function
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var brands =  _brandService.GetBrands();
            return View(brands);
        }

        /// <summary>
        /// Create Brand Get Function
        /// </summary>
        /// <returns>Brand Create View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }
        
        /// <summary>
        /// Create Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Brand Index</returns>
        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.CreateBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateBrandSuccess").ToString();
                    return PartialView("_CreatePartial",brandViewModel); 
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateBrand").ToString();
                return PartialView("_CreatePartial", brandViewModel);
            }
            return PartialView("_CreatePartial", brandViewModel);
        }

        /// <summary>
        /// Edit Brand
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>Edit Partial</returns>
        [HttpGet]        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var brand = await _brandService.GetBrandEditAsync(id.Value);
            if (brand == null)
            {
                return BadRequest();
            }
            return PartialView("_EditPartial", brand);
        }

        /// <summary>
        /// Edit Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>index brand</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.EditBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditBrandSuccess").ToString();
                    return PartialView("_EditPartial", brandViewModel);
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditBrand").ToString();
                return PartialView("_EditPartial", brandViewModel);
            }
            return PartialView("_EditPartial", brandViewModel);
        }

        /// <summary>
        /// Delete brand
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>index brand</returns>
        [HttpGet]  
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (await _brandService.DeleteBrandAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteBrandSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteBrand").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        /// <summary>
        /// Create Brand Get Function
        /// </summary>
        /// <returns>Brand Create View</returns>
        [HttpGet]
        public IActionResult Import()
        {
            return PartialView("_ImportPartial");
        }
        
        [HttpPost]   
        public async Task<IActionResult> Import(IFormFile formFile)  
        {  
            if (formFile == null || formFile.Length <= 0)  
            {  
                return PartialView("_ImportPartial", formFile);
            }  
  
            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))  
            {  
                return PartialView("_ImportPartial", formFile);
            }
            
            using (var stream = new MemoryStream())  
            {  
                await formFile.CopyToAsync(stream);  
  
                using (var package = new ExcelPackage(stream))  
                {  
                    var worksheet = package.Workbook.Worksheets[1];  
                    var rowCount = worksheet.Dimension.Rows;
                    
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var brand = new BrandViewModel
                        {
                            Id = int.Parse(worksheet.Cells[row, 1].Value.ToString().Trim()),
                            BrandName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                        };
                        await _brandService.CreateBrandAsync(brand);
                    }  
                }  
            }
            return PartialView("_ImportPartial");
        }  
        
        [HttpGet]   
        public IActionResult Export()  
        {  
            var rootFolder = _hostingEnvironment.WebRootPath + "/export";  
            var fileName = DateTime.Now.ToString("yMMdd_HHmmss") +".xlsx";  
  
            var file = new FileInfo(Path.Combine(rootFolder, fileName));  
  
            using (var package = new ExcelPackage(file))  
            {  
                var brands =  _brandService.GetBrands();
  
                var worksheet = package.Workbook.Worksheets.Add("Brands");
                var brandViewModels = brands as BrandViewModel[] ?? brands.ToArray();
                var totalRows = brandViewModels.Count();  
  
                worksheet.Cells[1, 1].Value = "Id";  
                worksheet.Cells[1, 2].Value = "BrandName";  
                var i = 0;  
                for (var row = 2; row <= totalRows + 1; row++)  
                {  
                    worksheet.Cells[row, 1].Value = brandViewModels[i].Id;  
                    worksheet.Cells[row, 2].Value = brandViewModels[i].BrandName;  
                    i++;  
                }  
                package.Save();   
            }  
            TempData["SuccessMessage"] = "Brand list has been exported successfully";
            return RedirectToAction(nameof(Index));
        }  
        
        #endregion
        
    }//end of class
}