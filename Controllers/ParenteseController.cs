using Microsoft.AspNetCore.Mvc;
using UneContTeste.Models;

namespace UneContTeste.Controllers
{
    public class ParenteseController : Controller
    {
        [Route("~/teste/paranteses")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/parenteses")]
        public IActionResult ContarParenteses([FromBody] ParenteseModel entrada)
        {
            if (entrada == null || string.IsNullOrEmpty(entrada.Valor))
            {
                return BadRequest("Entrada inválida.");
            }

            int left = 0;
            int right = 0;

            foreach (char c in entrada.Valor)
            {
                if (c == '(')
                {
                    left++;
                }
                else if (c == ')')
                {
                    if (left > 0)
                    {
                        left--;
                    }
                    else
                    {
                        right++;
                    }
                }
            }

            int resultado = left + right;
            return Ok(resultado);
        }

    }
}