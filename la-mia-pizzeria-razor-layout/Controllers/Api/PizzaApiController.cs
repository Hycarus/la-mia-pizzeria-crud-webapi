
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult GetPizzasByName(string filter = "")
        {
            var pizzas = PizzaManager.GetAllPizzas().Where(p => p.Name.ToLower().Contains(filter));
            if (pizzas == null)
                return NotFound();
            else
                return Ok(pizzas);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = PizzaManager.GetPizza(id, true);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }

        // POST api/values
        [HttpPost]
        public IActionResult PostPizza([FromBody] PizzaFormModel data)
        {
            using (PizzaContext context = new())
            {
                PizzaManager.InsertPizza(data.Pizza, data.SelectedIngredients);
                return Ok();
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, [FromBody] PizzaFormModel data)
        {
            using(PizzaContext context = new())
            {
                var pizzaToEdit = PizzaManager.UpdatePizza(id, data.Pizza, data.SelectedIngredients);
                if (pizzaToEdit != null)
                {
                    return Ok(pizzaToEdit);
                }
                else
                    return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            using (PizzaContext context = new())
            {
                if (PizzaManager.DeletePizza(id))
                    return Ok();
                else
                    return NotFound();
            }
        }
    }
}

