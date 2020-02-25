using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ACE.Event_System
{
    public class ACE_Standard_Event_Functions
    {
        public void ChangeShaderVariable(GameObject triggerObject, string shaderString, float shaderValue)
        {
            triggerObject.GetComponent<Material>().SetFloat(shaderString, shaderValue);
        }
    }
}
