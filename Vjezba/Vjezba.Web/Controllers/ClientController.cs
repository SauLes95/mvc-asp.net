using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vjezba.Web.Mock;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            IQueryable<Client> clientsQuery = MockClientRepository.Instance.All();
            List<Client> clients = clientsQuery.ToList();
            var clientNum = clients.Count;
            ViewBag.Message = $"U sustavu postoji {clientNum} klijenata.";

            return View(clients);
        }

        public IActionResult Details(int id)
        {
            var client = MockClientRepository.Instance.FindByID(id);

            return View(client);
        }

    }
}
