using BillingSystemTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BillingSystemTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using(DB db=new DB())
            {
                if (db.Roles.Count() == 0)
                {
                    var role1 = new UserRole();
                    var role2 = new UserRole();
                    role1.RoleName = "User";
                    role2.RoleName = "Admin";


                    db.Roles.Add(role1 );
                    db.Roles.Add(role2);
                    db.SaveChanges();


                }

            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
