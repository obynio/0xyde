using System;
using UnityEngine;
using System.Collections;
using System.Security.AccessControl;

public class LiftElevation : MonoBehaviour 
{
    public float liftSpeed = 2f;
    public float stopPosition = 173f;

    private GameObject left;
    private GameObject right;

	// Use this for initialization
	void Start () 
    {
        left = GameObject.Find("door_exit_inner_left_001");
        right = GameObject.Find("door_exit_inner_right_001");
	}
	
	// Update is called once per frame
	void Update () 
    {
        

        // This is quite a piece of shit..
	    if (transform.localPosition.y < stopPosition)
	        transform.Translate(Vector3.up*liftSpeed*Time.deltaTime);
	    else if (left.transform.localPosition.z < 2.6f)
	    {
            left.transform.Translate(Vector3.forward * Time.deltaTime);
            right.transform.Translate(Vector3.back * Time.deltaTime);
	    }
	    else
	        this.enabled = false;
                
	            
        
    }
}
