using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GalaxyArmies.Pages.Practice
{
    public class DetailModel : PageModel
    {
        public GalaxyArmiesModel GalaxyArmiesModel { get; set; }
        private IGalaxyArmies _galaxyArmies { get; set; }

        public DetailModel(IGalaxyArmies galaxyArmies)
        {
            this._galaxyArmies = galaxyArmies;
        }
        public IActionResult OnGet(long galaxyArmiesId)  
        {
            GalaxyArmiesModel =_galaxyArmies.GetById(galaxyArmiesId);
            if (GalaxyArmiesModel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page(); 
        }
    }
}