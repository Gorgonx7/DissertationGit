using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The rating controller updates the rating UI
/// </summary>
public class RatingController : MonoBehaviour
{
   public void SetRating(int rating)
   {
        if (rating <= 2)
        {
            gameObject.transform.parent.gameObject.GetComponent<Image>().color = Color.red;
        } else if (rating <= 3)
        {
            gameObject.transform.parent.gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            gameObject.transform.parent.gameObject.GetComponent<Image>().color = Color.green;
        }
        GetComponent<Text>().text = rating + "/5";
   
   }
}
