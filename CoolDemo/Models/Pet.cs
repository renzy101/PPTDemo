using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoolDemo.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Name too long"), MinLength(2, ErrorMessage = "Name too short")]
        public string Name { get; set; }
        public int? Age { get; set; }

        [ForeignKey("PetOwner")]
        public int? OwnerId { get; set; }
        public Owner PetOwner { get; set; }

        //public int? OwnerId {get; set:}
        //[ForeignKey ("OwnerId")]
        //public Owner PetOwner
    }
    
}
