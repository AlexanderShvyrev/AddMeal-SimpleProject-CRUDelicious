using System.ComponentModel.DataAnnotations;
using System;

namespace DojoCrudelicious.Models
{
    public class Dish
    {
        [Key]

        public int DishId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Chef{get; set;}
        [Required]
        public int Tastiness{get; set;}
        [Required]
        [Range(1,1000000)]
        public int Calories{get; set;}
        public string Description{get; set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}