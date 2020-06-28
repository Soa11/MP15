using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBool : MonoBehaviour
{
     private Animator myAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            myAnimationController.SetBool("play", true);
        }
        if (Input.GetKeyDown("2"))
        {
            myAnimationController.SetBool("play", false);
        }


    }
}
