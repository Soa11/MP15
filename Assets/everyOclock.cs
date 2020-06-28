using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class everyOclock : MonoBehaviour
{
    const float secondsInDay = 86400;
    //const float quarter = 1f / 4f;
    const float hour = secondsInDay / 24f;


    float secondsSinceMidnight;
    float dayProgress; //How far are we through the day in terms of 0-1 (percentage)

    [Space(10)]

    private Animator anim;


    [Space(10)]
    public bool showDebugValues;

    //Quaternion originalRotation;
    //float lastFrameXRotation = 0; // temp variable for calculating how much to move each frame

    bool hasPlayedAnimation = false;

    int nextTriggerHour = 0;
    float currentHour = 0;

   
    void Start()
    {
        //========The default rotation in the ~~Unity Scene~~ should be set to where Midnight is! =============

        anim = GetComponent<Animator>();
      

        //Time Updates
        secondsSinceMidnight = (float)System.DateTime.Now.TimeOfDay.TotalSeconds;
        dayProgress = secondsSinceMidnight / secondsInDay; //get day progress (t)
        currentHour = secondsSinceMidnight / hour; 
        //=============

        nextTriggerHour = Mathf.CeilToInt(currentHour); // figure out what the next hour is going to be
    }


    void Update()
    {


        //Time Updates
        secondsSinceMidnight = (float)System.DateTime.Now.TimeOfDay.TotalSeconds;
        dayProgress = secondsSinceMidnight / secondsInDay; //get day progress (t)
        currentHour = secondsSinceMidnight / hour;
        //=============


      
        //Check if the animation should trigger
        //if (currentHour >= nextTriggerHour) //if the current hour is greater than the trigger, do stuff and increase the trigger
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (null != anim)
                // Debug.Log("animation triggered at " + nextTriggerHour);
                
            {
                anim.Play("ReAnim_colourChange");
                Debug.Log("anim");
                nextTriggerHour++;
            }

            //cleanup for midnight
            if (nextTriggerHour == 24)
            {
                nextTriggerHour = 0;
            }
        }
        //=================================

        //End of day cleanup stuff, resetting timers to 0 and letting animation trigger again
        if (dayProgress > 1)
        {
            dayProgress -= 1;
            hasPlayedAnimation = false;
        }
        //=================================================

     
        if (showDebugValues)
        {
            Debug.Log("Day Progress: " + dayProgress + " / " + "Current Hour: " + currentHour);
            Debug.Log("Next Trigger Hour: " + nextTriggerHour);
        }
    }
}
