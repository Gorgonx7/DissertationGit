using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
    class worldAnchor : MonoBehaviour
    {
        List<GameObject> worldAnchors = new List<GameObject>();
        private void Start()
        {
            
            foreach(GameObject i in GameObject.FindGameObjectsWithTag("KeyItem"))
            {
                GameObject anchor = new GameObject();
                anchor.name = i.name + "WorldAnchor";
                anchor.transform.SetParent(i.transform,false);
                anchor.transform.parent = null;
            }
        }
    }
}
