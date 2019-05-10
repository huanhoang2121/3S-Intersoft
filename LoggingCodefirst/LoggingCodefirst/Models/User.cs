namespace LoggingCodefirst.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Fullname { get; set; }
        public string Password { get; set; }  
        public string Phone { get; set; } 
        public string Address { get; set; } 
        public bool IsActive { get; set; }
        
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
    }
}