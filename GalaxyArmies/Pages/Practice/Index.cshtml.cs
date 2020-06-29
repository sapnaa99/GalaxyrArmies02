using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
namespace GalaxyArmies.Pages.Practice
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IGalaxyArmies _galaxyarmies;
        public string Message { get; set; }
        public string MessageSecond { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<GalaxyArmiesModel> galaxyarmiesmodel { get; set; }
        public IndexModel(IConfiguration config, IGalaxyArmies galaxyarmies) 
        {
            this._config = config;
            this._galaxyarmies = galaxyarmies;
        }
        public void OnGet()
        {
            //Message = _config["Message"];
            //MessageSecond = "Hello sapana world";
            galaxyarmiesmodel = _galaxyarmies.GetAllGalaxyArmiesName(SearchTerm);

        }
    }
}