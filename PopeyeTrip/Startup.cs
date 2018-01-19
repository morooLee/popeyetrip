using Microsoft.Owin;
using Owin;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(PopEyeTrip.Startup))]
namespace PopEyeTrip
{
    public partial class Startup
    {
        public object Response { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
