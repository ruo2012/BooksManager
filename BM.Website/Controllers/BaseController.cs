using BM.Website.App_Start;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BM.Website.Controllers
{
    public abstract class BaseController : Controller
    {
        public IUnityContainer Unity { get; private set; }

        public BaseController()
        {
            Unity = UnityConfig.GetConfiguredContainer();
        }

    }
}
