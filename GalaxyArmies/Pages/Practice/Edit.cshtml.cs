using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using GalaxyArmies.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static GalaxyArmies.Core.ViewModels.GalaxyArmiesModel;

namespace GalaxyArmies.Pages.Practice
{
    public class EditModel : PageModel
    {
        private IGalaxyArmies _galaxyArmies;
        public IHtmlHelper _htmlHelper;

        [BindProperty]
        public GalaxyArmiesModel GalaxyArmiesModel { get; set; }
        public IEnumerable<SelectListItem> Armies { get; set; }
        public EditModel(IGalaxyArmies galaxyArmies, IHtmlHelper htmlHelper)
        {
            this._galaxyArmies = galaxyArmies;
            this._htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(long? galaxyArmiesId)
        {
            Armies = _htmlHelper.GetEnumSelectList<ArmiesType>();
            if (galaxyArmiesId.HasValue)
            {
                GalaxyArmiesModel = _galaxyArmies.GetById(galaxyArmiesId.Value);
            }
            else
            {
                GalaxyArmiesModel = new GalaxyArmiesModel(); 
            }
            if (GalaxyArmiesModel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        { 
            //  ModelState["Address"].Errors //TO CHECK IF MODEL DATA HAVE ANY ERRORS OR VACANT DATA
            if (ModelState.IsValid)
            {
                GalaxyArmiesModel = _galaxyArmies.Update(GalaxyArmiesModel);
                _galaxyArmies.Commit();
                return RedirectToPage("./Detail", new { galaxyArmiesId = GalaxyArmiesModel.Id });
            }
            Armies = _htmlHelper.GetEnumSelectList<ArmiesType>();
            return Page();

           

        }
    }
}