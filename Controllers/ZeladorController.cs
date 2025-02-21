using Microsoft.AspNetCore.Mvc;
using UneContTeste.Models;

namespace UneContTeste.Controllers
{
    public class ZeladorController : Controller
    {
        [Route("~/teste/zelador")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("api/zelador")]
        public IActionResult CalcularViagens([FromBody] ZeladorModel dados)
        {
            if (dados == null || dados.Pesos == null || dados.Pesos.Length == 0)
            {
                return BadRequest("Entrada inválida.");
            }

            int viagens = MinimoDeViagens(dados.Pesos);
            return Ok(new int[] { viagens });
        }

        private static int MinimoDeViagens(double[] pesos)
        {
            Array.Sort(pesos);
            int left = 0, right = pesos.Length - 1, viagens = 0;

            while (left <= right)
            {
                if (pesos[left] + pesos[right] <= 3.00)
                    left++;

                right--;
                viagens++;
            }

            return viagens;
        }
    }
}