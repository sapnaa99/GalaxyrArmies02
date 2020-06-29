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
    public class DeleteModel : PageModel
    {
        private IGalaxyArmies _galaxyArmies;
        public GalaxyArmiesModel GalaxyArmiesModel { get; set; }
        public DeleteModel(IGalaxyArmies galaxyArmies)
        {
            this._galaxyArmies = galaxyArmies;
        }
        public IActionResult OnGet(long galaxyArmiesId)
        {
            GalaxyArmiesModel = _galaxyArmies.GetById(galaxyArmiesId);
            if (GalaxyArmiesModel == null)
            {
                return RedirectToPage("./Notfound");
            }
            return Page();
        }
        public IActionResult OnPost(long galaxyArmiesId)
        {
            var data = _galaxyArmies.Delete(galaxyArmiesId);
            _galaxyArmies.Commit();
            if (data == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["StatusMessage"] = $"{data.Name} deleted";
            return RedirectToPage("./Index");
        }
    }
}