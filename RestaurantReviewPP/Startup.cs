using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantReviewPP.Startup))]
namespace RestaurantReviewPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
