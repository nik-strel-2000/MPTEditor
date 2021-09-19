using Microsoft.AspNetCore.Mvc;
using MPTEditor.Models;
using System.Threading.Tasks;

namespace MPTEditor.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext db;

        public HomeController(ApplicationContext content)
        {
            this.db = content;
        }
        public async Task<IActionResult> MainMenu()
        {
            return await Task.Run(() => View());
        }
    }
}
