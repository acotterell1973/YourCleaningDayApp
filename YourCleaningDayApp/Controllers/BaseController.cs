using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YourCleaningDayApp.Controllers
{
    public class BaseController : Controller
    {
        internal JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        };

        internal int DefaultNumberOfRecords => 5;
        internal int MaximumNumberOfRecords => 100;
    }
}
