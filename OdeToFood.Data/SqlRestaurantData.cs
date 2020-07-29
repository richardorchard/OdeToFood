﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }


        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {

            return db.SaveChanges();

        }

        public Restaurant Delete(int id)
        {

            var restaurant = GetById(id);

            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }


        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {

            return db.Restaurants.Count();

        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {

            var query = from r in db.Restaurants
                        where r.Name.StartsWith(searchTerm) || string.IsNullOrEmpty(searchTerm)
                        orderby r.Name
                        select r;
            
            return query;

        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {

            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return updatedRestaurant;


        }
    }
}
