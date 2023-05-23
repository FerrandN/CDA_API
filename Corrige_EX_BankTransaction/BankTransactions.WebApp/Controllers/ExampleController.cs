using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankTransactions.WebApp.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NamedView()
        {
            return View("MySuperView");
        }

        public IActionResult DataView()
        {
            ViewData["chaine1"] = "Voici une super chaîne de caractères !";

            ViewBag.chaine2 = "Voilà une autre chaîne, avec un chapeau !";
            return View();
        }

        public IActionResult ModelView()
        {
            BankTransaction transaction = new()
            {
                Transaction_Id = 22,
                Transaction_Date = DateTime.Now,
                Transaction_From = 21345678912,
                Transaction_To = 12345698712,
                Transaction_Amount = (decimal)1234.45,
            };
            return View(transaction);
        }

    }
}
