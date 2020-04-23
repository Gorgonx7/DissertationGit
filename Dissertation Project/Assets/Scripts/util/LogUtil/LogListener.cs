using Assets.LogUtil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// log listener listens for new logs and displays them in the log UI
/// </summary>
public class LogListener : MonoBehaviour
{
    public GameObject logPrefab;
    public List<GameObject> logList = new List<GameObject>();
    public float xOffset = -196;
    // Start is called before the first frame update
    void Start()
    {
        LogManager.LogListeners.Add(this);   
    }

   
    public void CreateNewLog(string logString)
    {
        GameObject log = Instantiate(logPrefab);
        log.transform.SetParent(gameObject.transform, false);
      
        log.GetComponent<Text>().text += logString;
        float totalHeight = 0.0f;
        foreach(GameObject i in logList)
        {
            totalHeight += -25; 
        }
        log.transform.localPosition += new Vector3(0, totalHeight, 0); ;
        log.transform.localPosition = new Vector3(xOffset, log.transform.localPosition.y, 0);
        logList.Add(log);

    }
}
