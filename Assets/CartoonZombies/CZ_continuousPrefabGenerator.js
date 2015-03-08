var createThis:GameObject[];  // list of possible prefabs

private var rndNr:float; // this is for just a random number holder when we need it

var thisManyTimesPerSec:float=1;


var xWidth:float;  // define the square where prefabs will be generated
var yWidth:float;
var zWidth:float;

var xRotMax:float;  // define maximum rotation of each prefab
var yRotMax:float=180;
var zRotMax:float;




private var x_cur:float;  // these are used in the random palcement process
private var y_cur:float;
private var z_cur:float;


private var xRotCur:float;  // these are used in the random protation process
private var yRotCur:float;
private var zRotCur:float;

private var timeCounter:float;  // counts the time :p
private var effectCounter:int;  // you will guess ti

private var trigger:float;  // trigger: at which interwals should we generate a prefab



function Start () {
if (thisManyTimesPerSec<0.1) thisManyTimesPerSec=0.1; //hack to avoid division with zero and negative numbers
trigger=1/thisManyTimesPerSec;  //define the intervals of time of the prefab generation.
Debug.Log(trigger);
}


function Update () {

timeCounter+=Time.deltaTime;

	if(timeCounter>trigger)
		{
		rndNr=Mathf.Floor(Random.value*createThis.length);  //decide which prefab to create


		x_cur=transform.position.x+(Random.value*xWidth)-(xWidth*0.5);  // decide an actual place
		y_cur=transform.position.y+(Random.value*yWidth)-(yWidth*0.5);
		z_cur=transform.position.z+(Random.value*zWidth)-(zWidth*0.5);

	
		xRotCur=transform.rotation.x+(Random.value*xRotMax*2)-(xRotMax);  // decide rotation
		yRotCur=transform.rotation.y+(Random.value*yRotMax*2)-(yRotMax);  
		zRotCur=transform.rotation.z+(Random.value*zRotMax*2)-(zRotMax);  
	

	
		var justCreated:GameObject=Instantiate(createThis[rndNr], Vector3(x_cur, y_cur, z_cur), transform.rotation);  //create the prefab
		justCreated.transform.Rotate(xRotCur, yRotCur, zRotCur);
		
		
		
		timeCounter-=trigger;  //administration :p
	
		}


}