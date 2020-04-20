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
        //Utiliza-se BindProperty para que a variavel seja usado tanto para receber request, quanto para uma response, neste caso.
        //Informa a estrutura do asp.net core que esta classe esta se preprando para executar uma metodo que processa uma solicitacao http, essa propriedade deve receber informaçãoes de solicitação, dizendo ao asp.net para procurar por algo chamado "searchTerm para preencher isso antes de invocar o onget() 
        //Por padrão essa propriedade só será acionada durante uma operação HTTP POST
        //Para controlar esse comportamente utilizamos uma flag () e configuramos para suportar o método OnGet()
        [BindProperty(SupportsGet =true)]
        public string SearchTerm{ get; set; }

        //Solicitando a implementacao do IRestaurantData
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.configuration = configuration;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {//Por meio da interface Iconfiguration, consigo acessar o arquivo appsetings, buscando pelo valor da keyword message, e exibindo na tela.
            //HttpContext.Request. -> Podemos usar tanto o http context para pegar a request, quanto pegando o parametro do submit como parametro no metodo, que ficara responsavel por procurar um "searchTerm" no httpContext
            //string pode ser null, então mesmo se o método não encontrar um parametro do request vindo como "searchTerm" ele devolverá null, e continuara, diferentemente se fosse int, no qual lançaria uma Exception
            
            Message = configuration["Message"];
            Restaurants = restaurantData.GetRestaturantsByName(SearchTerm);
        }
    }
}
