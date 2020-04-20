using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;//Readonly é um campo imutavel, refere-se sempre ao mesmo obj
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //Solicitando a implementacao do IRestaurantData
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {//Por meio da interface Iconfiguration, consigo acessar o arquivo appsetings, buscando pelo valor da keyword message, e exibindo na tela.
            Message = configuration["Message"];
            //Restaurants = restaurantData.GetRestaturantsByName();
        }
    }
}
