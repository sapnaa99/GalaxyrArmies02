using GalaxyArmies.Core.ViewModels;
using GalaxyArmies.Data.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GalaxyArmies.Data.Services
{
    public class SqlGalaxyArmiesService : IGalaxyArmies
    {
        private readonly GalaxyArmiesDbContext _db;
        public SqlGalaxyArmiesService(GalaxyArmiesDbContext db)
        {
            this._db = db;
            
        }
        public GalaxyArmiesModel AddNew(GalaxyArmiesModel newGalaxyArmiesModel)
        {
            _db.GalaxyArmiesModels.Add(newGalaxyArmiesModel);
            return newGalaxyArmiesModel;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public GalaxyArmiesModel Delete(long Id)
        {
            var data = GetById(Id);
            if (data != null)
            {
                _db.GalaxyArmiesModels.Remove(data);
            }
            return data;
        }

        public IEnumerable<GalaxyArmiesModel> GetAllGalaxyArmiesName(string name)
        {
            var data = from a in _db.GalaxyArmiesModels
                       where string.IsNullOrEmpty(name) || a.Name.ToLower().StartsWith(name.ToLower())
                       orderby a.Name
                       select a;

                       return data;
        }

        public GalaxyArmiesModel GetById(long Id)
        {
            return _db.GalaxyArmiesModels.Find(Id);
        }

        public GalaxyArmiesModel Update(GalaxyArmiesModel updatedGalaxyArmiesModel)
        {
            var entity = _db.GalaxyArmiesModels.Attach(updatedGalaxyArmiesModel);
            entity.State = EntityState.Modified;
            return updatedGalaxyArmiesModel;
        }
    }
}
