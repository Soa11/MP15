using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour
{

    public GameObject obj;
    private Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = obj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.Play("colourChange");
            Debug.Log("anim");
        }
            
            
            }
        }
    
