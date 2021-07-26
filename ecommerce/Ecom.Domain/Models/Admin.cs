using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters. ")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Username cannot exceed 30 characters. ")]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be in range 8-16 characters. ")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        //[StringLength(16, MinimumLength = 8, ErrorMessage = "The Password value must be in range 8-16 characters. ")]
        public string Email { get; set; }
        

    }
}
