using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingController : MonoBehaviour
{
   public void SetRating(int rating)
   {
        GetComponent<Text>().text = rating + "/5";
   
   }
}
