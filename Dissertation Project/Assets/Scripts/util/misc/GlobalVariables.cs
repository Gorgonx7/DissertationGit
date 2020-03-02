using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.util.misc
{
    public static class GlobalVariables
    {
        private static float _HeadsetHeight = 0.0f;
        public static float HeadsetHeight { 
            get { 
                return _HeadsetHeight; 
            } 
            set {
                Debug.Log("Setting Headset Height to " + value);
                _HeadsetHeight = value; 
            } 
        }

    }
}
