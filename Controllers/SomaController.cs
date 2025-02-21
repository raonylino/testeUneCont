using Microsoft.AspNetCore.Mvc;
using UneContTeste.Models;

namespace UneContTeste.Controllers
{
    public class SomaController : Controller
    {
        [Route("~/teste/soma")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/api/viagens")]
        public IActionResult EncontrarIndices([FromBody] SomaModel dados)
        {
            if (dados == null || dados.Pesos == null || dados.Pesos.Length == 0)
            {
                return BadRequest("Entrada inválida.");
            }

            int[] resultado = EncontrarDoisNumeros(dados.Pesos, dados.Objetivo);
            return Ok(resultado);
        }

        private static int[] EncontrarDoisNumeros(double[] numeros, double objetivo)
        {
            Dictionary<double, int> mapa = new Dictionary<double, int>();
            double complemento = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                complemento = objetivo - numeros[i];

                if (mapa.ContainsKey(complemento))
                {
                    return [mapa[complemento], i];
                }

                if (!mapa.ContainsKey(numeros[i]))
                {
                    mapa[numeros[i]] = i;
                }
            }

            return [mapa[complemento], numeros.Length - 1];
        }
    }
}