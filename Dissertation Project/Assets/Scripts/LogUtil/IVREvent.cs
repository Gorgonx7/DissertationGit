using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;
using UnityEngine;
namespace Assets.LogUtil
{
    public abstract class IVREvent : MonoBehaviour
    {
        public SteamVR_Action_Boolean control;
        public SteamVR_Input_Sources handType;
        public void Start()
        {

            control.AddOnStateUpListener(OnEventUp, handType);
            control.AddOnStateDownListener(OnEventDown, handType);
        }
        public abstract void LogEvent();
       
        public virtual void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {

        }
        public virtual void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            LogEvent();
        }


    }
}
