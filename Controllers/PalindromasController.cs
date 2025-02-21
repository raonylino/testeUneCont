using Microsoft.AspNetCore.Mvc;

namespace UneContTeste.Controllers
{
    public class PalindromasController : Controller
    {
        [Route("~/teste/palindromas")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("~/api/palindroma")]
        public IActionResult VerificarPalindromo([FromBody] string palavra)
        {
            var resultado = Palindroma(palavra);
            return Ok(resultado);
        }

        static bool Palindroma(string palavra)
        {

            Dictionary<char, int> frequencia = new Dictionary<char, int>();

            foreach (char c in palavra)
            {
                if (frequencia.ContainsKey(c))
                    frequencia[c]++;
                else
                    frequencia[c] = 1;
            }

            int impares = frequencia.Values.Count(v => v % 2 != 0);

            return impares <= 1;
        }

    }
}