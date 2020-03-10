using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SelectionPanalController : MonoBehaviour
{
    const string SCENESDIRECTORY = "./UDO/Scenes/";
    public GameObject ButtonPrefab;
    public List<GameObject> rooms = new List<GameObject>();
    public GameObject parentObject;
    public float xOffset;
    public float yOffset;
    public float initialY;
    public Filter currentFilter = Filter.UDO;
    // Start is called before the first frame update
    void Start()
    {
        string[] Scenes = Directory.GetDirectories(SCENESDIRECTORY);
        foreach(string i in Scenes)
        {
            bool Sample = false;
            string[] files = Directory.GetFiles(i);
            if(files.Length == 1)
            {
                Sample = true;
            }
            string SceneName = i.Split('/')[i.Split('/').Length - 1];
            GameObject holder = Instantiate(ButtonPrefab);
            holder.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Room: " + SceneName;
            holder.GetComponent<RoomLoadSelectionButtonControlScript>().RoomToLoad = SceneName;
            if (!Sample)
            {
                holder.GetComponent<RoomLoadSelectionButtonControlScript>().filter = Filter.UDO;
            }
            holder.GetComponent<RoomLoadSelectionButtonControlScript>().enabled = true;
            // Now Position the button prefab
            holder.transform.SetParent(parentObject.transform, false);
            
            rooms.Add(holder);
        }
        SwitchFilter();
        ReRenderUI();
    }
    public void SwitchFilter()
    {
        if(currentFilter == Filter.Sample)
        {
            currentFilter = Filter.UDO;
        }
        else
        {
            currentFilter = Filter.Sample;
        }
        foreach(GameObject i in rooms)
        {
            if(i.GetComponent<RoomLoadSelectionButtonControlScript>().filter == currentFilter)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }
    }
    public void ReRenderUI()
    {
        for(int i = 0; i < rooms.Count; i++)
        {
            int roomCount = 0;
            if(rooms[i].activeSelf)
            {
                rooms[i].transform.localPosition = new Vector3(xOffset, initialY + (yOffset * roomCount), 0);
                roomCount++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
