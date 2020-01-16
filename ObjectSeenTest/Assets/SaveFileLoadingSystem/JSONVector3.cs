using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.SaveFileLoadingSystem
{
    [Serializable]
    class JSONVector3
    {
        float x, y, z;
        public JSONVector3(Vector3 input)
        {
            x = input.x;
            y = input.y;
            z = input.z;
        }
        public Vector3 GetVector()
        {
            return new Vector3(x, y, z);
        }
    }
}
