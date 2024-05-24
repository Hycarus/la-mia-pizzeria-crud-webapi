
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
        public IActionResult GetAllPizzas(string? name)
        {
            if (name == null)
                return Ok(PizzaManager.GetAllPizzas());
            return Ok(PizzaManager.GetPizzasByName(name));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var pizza = PizzaManager.GetPizza(id);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }

        [HttpGet("{name}")]
        public IActionResult GetPizzaByName(string name)
        {
            var pizza = PizzaManager.GetPizzasByName(name);
            if (pizza == null)
                return NotFound("ERRORE");
            return Ok(pizza);
        }


        // POST api/values
        [HttpPost]
        public IActionResult CreatePizza([FromBody] Pizza pizza)
        {
            PizzaManager.InsertPizza(pizza, null);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, [FromBody] PizzaFormModel data)
        {
            var pizzaToEdit = PizzaManager.UpdatePizza(id, data.Pizza, data.SelectedIngredients);
            if (pizzaToEdit != null)
            {
                return Ok(pizzaToEdit);
            }
            else
                return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return Ok();
            else
                return NotFound();
        }
    }
}

