using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GalaxyArmies.Core.ViewModels
{
    public partial class GalaxyArmiesModel
    {
        public long? Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ArmiesType Armies { get; set; }
    }
}
