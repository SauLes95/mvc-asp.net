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

        [HttpPost]
        public IActionResult Index(string queryName, string queryAddress)
        {
            if (string.IsNullOrEmpty(queryName) && string.IsNullOrEmpty(queryAddress))
            {
                List<Client> clients = MockClientRepository.Instance.All().ToList();
                return View(clients);
            }
            else if (string.IsNullOrEmpty(queryName) && !string.IsNullOrEmpty(queryAddress))
            {
                List<Client> filteredClients = MockClientRepository.Instance.All()
                    .Where(client => client.Address.IndexOf(queryAddress, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                return View(filteredClients);
            }
            else if (string.IsNullOrEmpty(queryAddress) && !string.IsNullOrEmpty(queryName))
            {
                List<Client> filteredClients = MockClientRepository.Instance.All()
                   .Where(client => client.FullName.IndexOf(queryName, StringComparison.OrdinalIgnoreCase) >= 0)
                   .ToList();

                return View(filteredClients);
            }
            else
            {
                List<Client> filteredClients = MockClientRepository.Instance.All()
                   .Where(client => 
                        client.Address.IndexOf(queryAddress, StringComparison.OrdinalIgnoreCase) >= 0 &&
                        client.FullName.IndexOf(queryName, StringComparison.OrdinalIgnoreCase) >= 0)
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
