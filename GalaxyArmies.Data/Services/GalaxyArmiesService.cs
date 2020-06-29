using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static GalaxyArmies.Core.ViewModels.GalaxyArmiesModel;

namespace GalaxyArmies.Data.Services
{
    public class GalaxyArmiesService : IGalaxyArmies
    {
        readonly List<GalaxyArmiesModel> galaxyarmies;
        public GalaxyArmiesService()
        {
            galaxyarmies = new List<GalaxyArmiesModel>()
            {
                new GalaxyArmiesModel
                {
                    Id = 1,
                    Address = "kathmandu",
                    Name= "Sapana",
                    PhoneNumber = 9862933399,
                    Armies = ArmiesType.Gurkha
                },
                 new GalaxyArmiesModel
                {
                    Id = 2,
                    Address = "kathmandu",
                    Name= "Pramika",
                    PhoneNumber = 9862933399,
                    Armies = ArmiesType.Gurkha
                },
                  new GalaxyArmiesModel
                {
                    Id = 3,
                    Address = "kathmandu",
                    Name= "Mamu",
                    PhoneNumber = 9862933399,
                    Armies = ArmiesType.British
                }
            };
        }

        public GalaxyArmiesModel AddNew(GalaxyArmiesModel newGalaxyArmiesModel)
        {
            galaxyarmies.Add(newGalaxyArmiesModel);
            newGalaxyArmiesModel.Id = galaxyarmies.Max(x => x.Id) + 1;
            return newGalaxyArmiesModel;
        }

        public int Commit()
        {
            return 0;
        }

        public GalaxyArmiesModel Delete(long Id)
        {
            var galaxyArrmiesId = galaxyarmies.FirstOrDefault(x => x.Id == Id);
            if (galaxyArrmiesId != null)
            {
                galaxyarmies.Remove(galaxyArrmiesId);
            }
            return galaxyArrmiesId;
        }

        public IEnumerable<GalaxyArmiesModel> GetAllGalaxyArmiesName(string name=null)
        {
            return from a in galaxyarmies
                   where string.IsNullOrEmpty(name) || a.Name.ToLower().StartsWith(name.ToLower())
                   orderby a.Name
                   select a;
                       
        }

        public GalaxyArmiesModel GetById(long Id)
        {
            var data = (from a in galaxyarmies
                        where a.Id == Id
                        select a);
            return data.FirstOrDefault();
        }

        public GalaxyArmiesModel Update(GalaxyArmiesModel updatedGalaxyArmiesModel)
        {
            var Galax = galaxyarmies.FirstOrDefault(x => x.Id == updatedGalaxyArmiesModel.Id);
            if (Galax == null)
            {
                Galax.Name = updatedGalaxyArmiesModel.Name;
                Galax.Address = updatedGalaxyArmiesModel.Address;
                Galax.PhoneNumber = updatedGalaxyArmiesModel.PhoneNumber;
                Galax.Armies = updatedGalaxyArmiesModel.Armies;
            }
            return Galax;
        }
    }
}
