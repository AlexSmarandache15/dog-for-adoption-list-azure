﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogForAdoptionList.Model
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
