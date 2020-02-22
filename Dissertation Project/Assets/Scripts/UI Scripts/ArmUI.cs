using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ArmUI : MonoBehaviour
{
    public Vector3 PositionRelativeToZero = new Vector3(0, 0, 0);
    public SteamVR_Action_Boolean control;
    public SteamVR_Input_Sources handType;
    public GameObject UIPrefab;
    private GameObject UI;
    public Camera mainCamera;
    bool uiIsShown = false;
    // Start is called before the first frame update
    void Start()
    {
        UI = Instantiate(UIPrefab);
       
        UI.transform.SetParent(gameObject.transform, false);
        UI.GetComponent<RectTransform>().transform.Translate(0, 5, 0);

        UI.GetComponent<Canvas>().worldCamera = mainCamera;
        
        UI.SetActive(false);
        
        control.AddOnStateDownListener(toggleUI, handType);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggleUI(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!uiIsShown)
        {
            UI.SetActive(true);

            UI.transform.position = (gameObject.transform.position);
            UI.transform.Translate(PositionRelativeToZero);
            uiIsShown = true;
        }
        else
        {
            UI.SetActive(false);
            uiIsShown = false;
        }
    }
}
