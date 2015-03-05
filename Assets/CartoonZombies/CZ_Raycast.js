#pragma strict


var moveThis : GameObject;
private var hit : RaycastHit;

var explosion:GameObject;
private var cooldown : float;




function Update () 
{
if(cooldown>0) cooldown-=Time.deltaTime;
var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

if (Physics.Raycast (ray, hit)) 
	{
	moveThis.transform.position=hit.point;
	
	if(Input.GetMouseButton(0)&&cooldown<=0)
		{
		Instantiate(explosion, moveThis.transform.position, moveThis.transform.rotation);
		cooldown=0.1;
		}
	}
}