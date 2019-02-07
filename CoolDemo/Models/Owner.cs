using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoolDemo.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]public string  FirstName { get; set; }
        [Required]public string LastName { get; set; }
        [Required]public DateTime DOB { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
