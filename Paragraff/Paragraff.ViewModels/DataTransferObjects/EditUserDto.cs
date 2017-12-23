using Paragraff.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.DataTransferObjects
{
    public class EditUserDto
    {
        [Required]
        [Key]
        public string Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(350)]
        public string About { get; set; }

        public Gender Gender { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
