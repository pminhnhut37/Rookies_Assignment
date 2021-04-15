using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Shared.Rating;

namespace CustomerSite.ViewComponents
{
    public class RatingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(RatingVM ratingVM)
        {
            return View("Default", ratingVM);
        }
    }
}
