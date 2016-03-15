using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RssfeedByAyncAndAwait.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var httpMessage = await client.GetAsync("https://channel9.msdn.com/feeds/rss").ConfigureAwait(false);
                var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return this.Content(content);
            }
        }
    }
}