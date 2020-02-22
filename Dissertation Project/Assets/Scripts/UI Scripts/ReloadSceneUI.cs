using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;
using UnityEngine.SceneManagement;
namespace Assets.UI_Scripts
{
    class ReloadSceneUI : InteractableCollision
    {
        public override void LogEvent()
        {
            LogUtil.LogManager.Log("Reset Scene");
        }

        public override void OnEventDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (!isHandNear)
            {
                return;
            }
            SceneManager.LoadScene("scene1", LoadSceneMode.Single);
            base.OnEventDown(fromAction, fromSource);
        }
    }
}
