using Assets.LogUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Valve.VR;

namespace Util.Interactables
{
    public abstract class InteractableCollision : IVREvent
    {
        protected bool isHandNear = false;
        protected virtual  void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Grabber>() != null)
            {
                isHandNear = true;
            }
        }
        protected virtual  void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Grabber>() != null)
            {
                isHandNear = false;
            }
        }
    }
}
