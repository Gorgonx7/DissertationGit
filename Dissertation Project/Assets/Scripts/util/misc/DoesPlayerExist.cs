using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Checks if the player exisits and then creates it if not
/// </summary>
public class DoesPlayerExist : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (enabled)
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                Instantiate(playerPrefab);
            }
        }
    }
    private void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject holder = Instantiate(playerPrefab);
            holder.transform.position = gameObject.transform.position;
        }
    }

}
