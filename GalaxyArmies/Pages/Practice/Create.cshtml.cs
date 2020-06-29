using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static GalaxyArmies.Core.ViewModels.GalaxyArmiesModel;

namespace GalaxyArmies.Pages.Practice
{
    public class CreateModel : PageModel
    {
        public IGalaxyArmies _galaxyArmies;
        public IHtmlHelper _htmlHelper;
        [BindProperty]
        public GalaxyArmiesModel galaxyarmiesmodel { get; set; }

        public IEnumerable<SelectListItem> Armies { get; set; }
        public CreateModel(IGalaxyArmies galaxyArmies, IHtmlHelper htmlHelper)
        {
            this._galaxyArmies = galaxyArmies;
            this._htmlHelper = htmlHelper;
        }
        public void OnGet()
        {
            Armies = _htmlHelper.GetEnumSelectList<ArmiesType>();
            galaxyarmiesmodel = new GalaxyArmiesModel();
        }
        public IActionResult OnPost()
        {
            var data = _galaxyArmies.AddNew(galaxyarmiesmodel);
            _galaxyArmies.Commit();
            return RedirectToPage("./Detail", new { galaxyArmiesId = data.Id});
        }
    }
}