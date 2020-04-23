using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.TimeManagement
{
    //Data for each goals hint system is stored within this class
    class HintData
    {
        public List<string> PastObjects = new List<string>();
        public List<string> ExistingHintObjects = new List<string>();
        public List<string> DerivedHintObjects = new List<string>();
    }
}
