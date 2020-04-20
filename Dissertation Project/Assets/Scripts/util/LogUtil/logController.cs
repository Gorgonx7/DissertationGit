using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logController : MonoBehaviour
{
    public Scrollbar scrollBar;


    public int maxValues;
    List<GameObject> log = new List<GameObject>();
    public GameObject logPrefab;

    private Vector3 initialLogPosition = new Vector3(-200, 150, 0);
    private const float textLogHight = 100;

    public Canvas canvasToUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(log.Count > maxValues)
        {
            int newMaxDistance = log.Count - maxValues;
            scrollBar.numberOfSteps = newMaxDistance;
        }
    }

    public void add(string logString)
    {
        GameObject newLog = Instantiate(logPrefab);
        newLog.transform.parent = canvasToUse.transform;
        newLog.GetComponent<Text>().text += " " + logString;
        Vector3 logpos = initialLogPosition + (initialLogPosition * log.Count);
        logpos.x = initialLogPosition.x;
        logpos.z = 0;
        newLog.GetComponent<RectTransform>().anchoredPosition = logpos;
        newLog.GetComponent<RectTransform>().localPosition.Set(logpos.x, logpos.y, logpos.z);
        newLog.transform.localScale = new Vector3(1, 1, 1);

        log.Add(newLog);
    }

}
