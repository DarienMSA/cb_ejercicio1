using cb_ejercicio1.Data;
using cb_ejercicio1.Logic;
using cb_ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;

namespace cb_ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        private readonly RulesDbContext _context;

        public HomeController(RulesDbContext context)
        {
            _context = context;
        }

        public IActionResult IndexReglas()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportToExcel()
        {
            string filename = "Reglas";
            ToExcel toExcel = new ToExcel(filename);
            var data = await _context.CbcReglaInconsistencia.FromSqlRaw("bp_reglas_obtener").ToListAsync();

            var content = toExcel.CbcReglaInconsistenciaToExcel(data);
            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{filename}.xlsx");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}