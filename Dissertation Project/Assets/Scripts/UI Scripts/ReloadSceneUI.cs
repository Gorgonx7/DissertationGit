using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valve.VR;
using UnityEngine.SceneManagement;
using Util.Interactables;
/// <summary>
/// Reloads the current scene
/// </summary>
namespace Assets.UI_Scripts
{
    public class ReloadSceneUI : InteractableCollision
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
            SceneManager.LoadScene("SampleSceneTeaMaking", LoadSceneMode.Single);
            
        }

        public override void OnEventUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            // Not needed for this interaction
        }
    }
}
