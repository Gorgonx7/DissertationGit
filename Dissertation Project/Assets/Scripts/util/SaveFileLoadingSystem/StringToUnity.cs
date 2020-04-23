using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.FileSystem
{/// <summary>
/// used to store string conversions to unity types, more could be added but for simplicity only vector3 is used for the demo
/// </summary>
    public static class StringToUnity
    {
        //Hide Flags
        //Physics Material
        public static Vector3 StringToVector3(string sVector) {
            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // store as a Vector3
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));

            return result;
        }
    }
}
