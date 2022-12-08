using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHdag7CodeFirst.Data
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(15,100)]
        public int Age { get; set; }
        public int ShoeSize { get; set; }
        public County County { get; set; }
    }
}
