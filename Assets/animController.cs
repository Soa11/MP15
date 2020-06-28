using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    public Animator anim;
    bool animPlay;


    const float secondsInDay = 86400;
    const float quarter = 1f / 4f;
    const float hour = secondsInDay / 24f;


    float secondsSinceMidnight;
    float dayProgress; //How far are we through the day in terms of 0-1 (percentage)

    int nextTriggerHour = 0;
    float currentHour = 0;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        animPlay = false;

        //Time Updates
        secondsSinceMidnight = (float)System.DateTime.Now.TimeOfDay.TotalSeconds;
        dayProgress = secondsSinceMidnight / secondsInDay; //get day progress (t)
        currentHour = secondsSinceMidnight / hour;
        nextTriggerHour = Mathf.CeilToInt(currentHour);

    }

   
    void Update()
    {
        secondsSinceMidnight = (float)System.DateTime.Now.TimeOfDay.TotalSeconds;
        dayProgress = secondsSinceMidnight / secondsInDay; //get day progress (t)
        currentHour = secondsSinceMidnight / hour;


        if (currentHour >= nextTriggerHour) //if the current hour is greater than the trigger, do stuff and increase the trigger
        {
            Debug.Log("animation triggered at " + nextTriggerHour);
            anim.SetBool("play", true);

            nextTriggerHour++;

            //cleanup for midnight
            if (nextTriggerHour == 24)
            {
                nextTriggerHour = 0;
            }


            if (dayProgress > 1)
            {
                dayProgress -= 1;
                anim.SetBool("play", false);
            }
        }





        /*if(Input.GetKey(KeyCode.Space))

            anim.SetBool("play", true);


        //anim.Play("colourChange");

        else
            anim.SetBool("play", false);*/



    }
}
