using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {

            restaurants = new List<Restaurant>()
                {

                    new Restaurant{Id= 1, Name = "Caio Bella", Cuisine = CuisineType.Italian, Location="Romford"},
                    new Restaurant{Id= 2, Name = "Popadom", Cuisine = CuisineType.Indian, Location="New Deli"},
                     new Restaurant{Id= 3, Name = "Sombraro", Cuisine = CuisineType.Mexican, Location="Mexico City"},
                     new Restaurant{Id= 4, Name = "Nando's", Cuisine = CuisineType.Chicken, Location="Lisbon"},
                     new Restaurant{Id= 5, Name = "Sudakthai", Cuisine = CuisineType.Thai, Location="Hornchurch"}
                };


        }

        public Restaurant Add(Restaurant newRestaurant)
        {

            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;

        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return null;
        }

        public IEnumerable<Restaurant> GetAll()
        {

            return from r in restaurants
                   orderby r.Name
                   select r;


        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {

            return restaurants.Count();

        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm = null)
        {


            return from r in restaurants
                   where string.IsNullOrEmpty(searchTerm) || r.Name.StartsWith(searchTerm)
                   orderby r.Name
                   select r;


        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {

            var restaraunt = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);


            if (restaraunt != null)
            {
                restaraunt.Location = updatedRestaurant.Location;

                restaraunt.Name = updatedRestaurant.Name;
                restaraunt.Cuisine = updatedRestaurant.Cuisine;


            }

            return restaraunt;

        }
    }

}

