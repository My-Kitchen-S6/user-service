using System.ComponentModel.DataAnnotations;

namespace user_service.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Auth0Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Role { get; set; }
    }
}