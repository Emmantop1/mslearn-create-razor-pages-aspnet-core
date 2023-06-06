using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContossoPizza.Pages
{
    public class PizzalistModel : PageModel
    {
        private readonly PizzaService pizzaService;
        public IList<Pizza> Pizzalist {get; set;}=default!;
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzalistModel(PizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }
        public void OnGet()
        {
            Pizzalist=pizzaService.GetPizzas();
        }


        public IActionResult OnPost(){
            if (!ModelState.IsValid || NewPizza ==null){
                return Page();
            }
            pizzaService.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id){
            pizzaService.DeletePizza(id);
            return RedirectToAction("Get");
        }
    }

}
