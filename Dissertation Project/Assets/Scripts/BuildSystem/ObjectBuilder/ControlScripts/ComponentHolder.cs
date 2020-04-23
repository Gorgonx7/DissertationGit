using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.BuildSystem
{
    /// <summary>
    /// Legacy code for the old drop down UI
    /// </summary>
    class ComponentHolder
    {
        private static List<Component> addedComponents = new List<Component>();

        public static void ResetComponentList()
        {
            addedComponents = new List<Component>();
        }
        public static void AddComponent(Component compToAdd)
        {
            addedComponents.Add(compToAdd);
        }
    }
}
