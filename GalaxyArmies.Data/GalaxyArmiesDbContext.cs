using GalaxyArmies.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyArmies.Data
{
   public class GalaxyArmiesDbContext : DbContext
    {
        public GalaxyArmiesDbContext(DbContextOptions<GalaxyArmiesDbContext> options)
        :base (options)
        {
        }
        public DbSet<GalaxyArmiesModel> GalaxyArmiesModels { get; set; }
    }
}
