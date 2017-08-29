﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;

namespace Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Startup.ConfigureWebApi);

            //reconhecer a pasta /Areas 
            AreaRegistration.RegisterAllAreas();
        }
    }
}
