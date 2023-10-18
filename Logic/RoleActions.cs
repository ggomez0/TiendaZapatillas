using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ShopGaspar.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShopGaspar.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "canEdit" role if it doesn't already exist.
            if (!roleMgr.RoleExists("ADMIN"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "ADMIN" });
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "gaspargomez2000",
                Email = "gaspargomez2000@outlook.com"
            };
            IdUserResult = userMgr.Create(appUser, "Gaspar123@");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("gaspargomez2000@outlook.com").Id, "ADMIN"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("gaspargomez2000@outlook.com").Id, "ADMIN");
            }

            //Rol Gerente

            // Access the application context and create result variables.
            Models.ApplicationDbContext contextt = new ApplicationDbContext();
            IdentityResult IdRoleResultt;
            IdentityResult IdUserResultt;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStoree = new RoleStore<IdentityRole>(contextt);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgrr = new RoleManager<IdentityRole>(roleStoree);

            if (!roleMgrr.RoleExists("GERENTE"))
            {
                IdRoleResultt = roleMgr.Create(new IdentityRole { Name = "GERENTE" });
            }

            var userMgrr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextt));
            var appUserr = new ApplicationUser
            {
                UserName = "gerente",
                Email = "gerente@gerente.com"
            };
            IdUserResultt = userMgrr.Create(appUserr, "Gaspar123@");

            // If the new "canEdit" user was successfully created, 
            // add the "canEdit" user to the "canEdit" role. 
            if (!userMgrr.IsInRole(userMgrr.FindByEmail("gerente@gerente.com").Id, "GERENTE"))
            {
                IdUserResultt = userMgrr.AddToRole(userMgrr.FindByEmail("gerente@gerente.com").Id, "GERENTE");
            }
        }
    }
}