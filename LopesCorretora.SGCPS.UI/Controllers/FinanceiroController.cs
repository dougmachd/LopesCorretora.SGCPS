using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.UI.Filtros;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class FinanceiroController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BalancoAnual()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BalancoMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ControleDeDespesas()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DarBaixa()
        {
            return View();
        }
    }
}