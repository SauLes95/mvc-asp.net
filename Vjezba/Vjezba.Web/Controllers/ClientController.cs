using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Vjezba.Web.Mock;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                List<Client> clients = MockClientRepository.Instance.All().ToList();
                return View(clients);
            }

            else
            {
                List<Client> filteredClients = MockClientRepository.Instance.All()
                    .Where(client => client.FullName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                return View(filteredClients);
            }

        }

        public IActionResult Details(int id)
        {
            var client = MockClientRepository.Instance.FindByID(id);

            return View(client);
        }

    }
}
