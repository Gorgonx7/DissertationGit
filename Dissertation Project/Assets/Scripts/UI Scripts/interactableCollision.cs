using Assets.LogUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR;

namespace Assets.UI_Scripts
{
    abstract class InteractableCollision : IVREvent
    {
        protected bool isHandNear = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Grabber>() != null)
            {
                isHandNear = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Grabber>() != null)
            {
                isHandNear = false;
            }
        }
    }
}
