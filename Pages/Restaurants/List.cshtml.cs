using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;

        public string Message { get; set; }

        public ListModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {//Por meio da interface Iconfiguration, consigo acessar o arquivo appsetings, buscando pelo valor da keyword message, e exibindo na tela.
            Message = configuration["Message"];
        }
    }
}
