using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;
using UnityEngine;
namespace Util.Interactables
{
    /// <summary>
    /// Very bottom of the VR event class, used to hold abstract concepts for the above classes
    /// </summary>
    public abstract class IVREvent : MonoBehaviour
    {
        public SteamVR_Action_Boolean control;
        public SteamVR_Input_Sources handType;
        public virtual void Start()
        {

            control.AddOnStateUpListener(OnEventUp, handType);
            control.AddOnStateDownListener(OnEventDown, handType);
        }
        public abstract void LogEvent();

        public abstract void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource);

        public abstract void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource);
        


    }
}
