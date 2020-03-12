using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace St.Marys_Donor.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if(_claimsPrincipal.IsInRole("Administrator"))
                {
                    context.Result = new RedirectToActionResult("Index", "Administrators", null);
                }
                else if (_claimsPrincipal.IsInRole("Donor"))
                {
                    context.Result = new RedirectToActionResult("Index", "Donors", null);
                }
                else if (_claimsPrincipal.IsInRole("Hospital Administrator"))
                {
                    context.Result = new RedirectToActionResult("Index", "Hospital_Administrator", null);
                }
               else if (_claimsPrincipal.IsInRole("Patient"))
                {
                    context.Result = new RedirectToActionResult("ProfilePage", "Patients", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
