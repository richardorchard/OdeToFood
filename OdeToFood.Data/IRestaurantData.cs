using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {


        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);

        Restaurant GetById(int id);


        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);


        Restaurant Delete(int id);


        int Commit();

        int GetCountOfRestaurants();


    }

    }

