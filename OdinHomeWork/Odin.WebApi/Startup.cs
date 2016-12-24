using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Odin.WebApi.App_Start;
using Odin.WebApi.Filters;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

[assembly: OwinStartup(typeof(Odin.WebApi.Startup))]

namespace Odin.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = NinjectWebCommon.CreateKernel();
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.Filters.Add(new BusinessLogicExceptionFilterAttribute());
            app.UseNinjectMiddleware(() => kernel);
            app.UseNinjectWebApi(config);
        }
    }
}
