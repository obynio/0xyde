using UnityEngine;
using System.Collections;

 [RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
	public float rotationSpeed = 0;
	public float walkSpeed = 5;
	public float runSpeed = 8;
	public float deadzone = 0.25f;
	public bool joystick = false;

	//methode de rotation
	private Quaternion targetRotation;
	private Quaternion desireRotation;

	//Composants
	public Gun gun;
	public Blast blast;
	public GameObject fpc;
	
	
	private CharacterController controller;
	private Camera cam;

	void Start ()
	{
		controller = GetComponent<CharacterController>();
		cam = Camera.main;
	}

	//controlles visée avec la souris
	void Update ()
	{
		UpCamera ();
		if (Input.GetButtonDown ("Joy"))
		{
			joystick = !joystick;
		}
	}

	void UpCamera ()
	{	
		if (!(Mathf.Abs(Input.GetAxis("Mouse X2")) > 0.2 
		    || Mathf.Abs(Input.GetAxis("Mouse Y2")) > 0.2) &&
		    !(Mathf.Abs(Input.GetAxis("Mouse X1")) < 0.1 
		  || Mathf.Abs(Input.GetAxis("Mouse Y1")) < 0.1))
		{
			// récupère la position de la souris, et on fait suivre cette position grace a la soustraction (2eme ligne)
			Vector3 mousePos = Input.mousePosition;
			mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
			targetRotation = Quaternion.LookRotation (mousePos - new Vector3 (transform.position.x, 0, transform.position.z));
			//suprimmer Time.deltaTime pour un Gameplay plus nerveux mais moins "réaliste"
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		}

		else
		{
			Vector2 shootDirection = new Vector2(Input.GetAxis("Mouse X2"),     
			                                     Input.GetAxis("Mouse Y2"));

			if(shootDirection.magnitude < deadzone)
			{
				shootDirection = Vector2.zero;
			}
			else
			{
				Vector3 shootRotation = new Vector3(shootDirection.x, 0, shootDirection.y);
				targetRotation = Quaternion.LookRotation(shootRotation);
				//transform.rotation = desireRotation;
				//transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, desireRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
			}
		}	transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

		//déplacement WASD ou ZQSD
		Vector3 input = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 motion = input;
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? .7f :1;
		motion *= (Input.GetButton ("Run")) ? runSpeed : walkSpeed;
		motion += Vector3.up * -8;
		
		controller.Move (motion * Time.deltaTime);
		
		if (Input.GetButtonDown ("Fire1"))
		{
			gun.Shoot();
		}
		if (Input.GetButtonDown ("Fire2"))
		{
			blast.Shoot();
		}
	}
}
