using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Character/FPS Input Controller")]


public class PlayerMovement : MonoBehaviour {

    // This script is only applied to the local player (the player that currently play on the machine)

    private CharacterMotor motor;

    Vector3 directionVector = Vector3.zero;

    Animator anim;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}

    void Awake()
    {
        motor = GetComponent<CharacterMotor>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (directionVector != Vector3.zero)
        {
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            directionLength = Mathf.Min(1.0f, directionLength);

            directionLength = directionLength * directionLength;

            directionVector = directionVector * directionLength;
        }
        

        anim.SetFloat("speed", directionVector.magnitude);

        motor.inputJump = Input.GetButton("Jump");
	}

    // because Update is crap as it's updated once per frame whereas this one is updated once per physics loop
    void FixedUpdate()
    {
        motor.inputMoveDirection = transform.rotation * directionVector;
    }
}
