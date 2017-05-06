using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YourCleaningDayApp.Data;

namespace YourCleaningDayApp.Controllers
{
    public class BaseController : Controller
    {
        #region internal fields

        internal ApplicationDbContext DbContext;
        internal JsonSerializerSettings DefaultJsonSettings => new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        };

        internal int DefaultNumberOfRecords => 5;
        internal int MaximumNumberOfRecords => 100;

#endregion
    }
}
