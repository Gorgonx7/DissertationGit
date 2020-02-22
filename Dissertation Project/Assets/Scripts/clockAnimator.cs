using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockAnimator : MonoBehaviour
{
    public Transform hours, minutes, seconds;
    public AudioSource tickingSound;
    bool isSoundPlaying = false;
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;
    public bool analog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (analog)
        {
            TimeSpan timespan = DateTime.Now.TimeOfDay;
            
            hours.localRotation =
                Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
            minutes.localRotation =
                Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
            seconds.localRotation =
                Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);
        }
        else
        {
            DateTime time = DateTime.Now;
            hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
            minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
        }
        if (!isSoundPlaying)
        {
            tickingSound.Play();
            isSoundPlaying = true;
        }
    }
}
