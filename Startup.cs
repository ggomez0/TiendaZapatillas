using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaZapatillas.Startup))]
namespace TiendaZapatillas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
