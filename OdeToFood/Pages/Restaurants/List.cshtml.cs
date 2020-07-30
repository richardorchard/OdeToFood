using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

   //     private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public string Message { get; set; }
        public ILogger<ListModel> logger { get; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {

            this.restaurantData = restaurantData;
            this.logger = logger;
        }


        public void OnGet()
        {

            logger.LogError("executing list model");

            Message = "Hello, World!";

            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);

        }
    }
}