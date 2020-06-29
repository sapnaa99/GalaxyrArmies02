using GalaxyArmies.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyArmies.Data.Interface
{
    public interface IGalaxyArmies
    {
        IEnumerable<GalaxyArmiesModel> GetAllGalaxyArmiesName(string name);
        GalaxyArmiesModel GetById(long Id);
        GalaxyArmiesModel Update(GalaxyArmiesModel updatedGalaxyArmiesModel);
        GalaxyArmiesModel AddNew(GalaxyArmiesModel newGalaxyArmiesModel);
        GalaxyArmiesModel Delete(long Id);
        int Commit();
    }
}
