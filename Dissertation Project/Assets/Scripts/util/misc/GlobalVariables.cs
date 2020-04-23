using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.util.misc
{

    /// <summary>
    /// Stores the global variables for the system
    /// </summary>
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
        private static string _GoalXML = "Sample";
        public static string GoalXML
        {
            get
            {
                return _GoalXML;
            }
            set
            {
                Debug.Log("Setting Goal XML location to " + value);
                _GoalXML = value;
            }
        }
        private static List<GameObject> _UDOsForScene = new List<GameObject>();
        public static List<GameObject> UDOsForScene
        {
            get
            {
                return _UDOsForScene;
            }
            set
            {
                _UDOsForScene = value;
            }
        }
    }
}
