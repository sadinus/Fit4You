using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models
{
    public class UserInformationDisplayModel
    {
        public UserInformationDisplayModel()
        {

        }

        public UserInformationDisplayModel(string defaultValue)
        {
            Gender = defaultValue;
            AgeDisplay = defaultValue;
            WeightDisplay = defaultValue;
            HeightDisplay = defaultValue;
            BMI = defaultValue;
            BMR = defaultValue;
        }

        public string Gender { get; set; }
        public string AgeDisplay { get; set; }
        public string WeightDisplay { get; set; }
        public string HeightDisplay { get; set; }
        
        public string BMI { get; set; }
        public string BMIMeaning { get; set; }
        public string BMR { get; set; }
    }
}
