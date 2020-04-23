using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Event_System
{
    /// <summary>
    /// Set of standard functionallity that was planned to be used by the event system to create a standard library of object effects, not implemented due to time constraints
    /// </summary>
    public class ACE_Standard_Event_Functions
    {
        public void ChangeShaderVariable(GameObject triggerObject, string shaderString, float shaderValue)
        {
            triggerObject.GetComponent<Material>().SetFloat(shaderString, shaderValue);
        }
    }
}
