using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.Data.Models
{
    [Table("Categories")]
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
