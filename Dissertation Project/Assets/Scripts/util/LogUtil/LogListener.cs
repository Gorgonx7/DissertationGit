using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogListener : MonoBehaviour
{
    public GameObject logPrefab;
    public List<GameObject> logList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        LogManager.LogListeners.Add(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewLog(string logString)
    {
        GameObject log = Instantiate(logPrefab);
        log.transform.SetParent(gameObject.transform, false);
      
        log.GetComponent<Text>().text += logString;
        float totalHeight = 0.0f;
        foreach(GameObject i in logList)
        {
            totalHeight += i.GetComponent<Text>().preferredHeight; 
        }
        log.transform.localPosition += new Vector3(-196, totalHeight, 0); ;
        logList.Add(log);

    }
}
