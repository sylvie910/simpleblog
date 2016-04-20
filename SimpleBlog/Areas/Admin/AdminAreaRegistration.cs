using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //routes specific to this area
            context.MapRoute(
                "Admin_default",
                //因为都在Admin这个名称空间中，所以都是以Admin/开头的url
                //parameters asp.net can extract the url that to create the data that passed to our application 
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}