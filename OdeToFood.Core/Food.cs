using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    public class Food
    {


        public int Id { get; set; }

        [Required, StringLength(80)]
        public string FoodName { get; set; }

        [Required]
        public int Calories { get; set; }
    }
}
