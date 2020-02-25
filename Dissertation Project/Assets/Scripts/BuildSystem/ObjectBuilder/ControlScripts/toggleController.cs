using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<ClickandDragTranslate> BehaviourToDeactivate = new List<ClickandDragTranslate>();
    public List<ClickandDrag> BehaviourToActivate = new List<ClickandDrag>();
    public void StateChange()
    {
        if (gameObject.GetComponent<Toggle>().isOn)
        {
            foreach(MonoBehaviour i in BehaviourToDeactivate)
            {
                i.enabled = false;
            }
            foreach(MonoBehaviour i in BehaviourToActivate)
            {
                i.enabled = true;
            }
        } else
        {
            foreach (MonoBehaviour i in BehaviourToDeactivate)
            {
                i.enabled = true;
            }
            foreach (MonoBehaviour i in BehaviourToActivate)
            {
                i.enabled = false;
            }
        }
    }
}
