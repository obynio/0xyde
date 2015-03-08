//This is a super hacky solution. For some reason the collision was not detected when the destroyer cube was staying still, so this
// little script makes it move constantly. Sorry, not a programmer :)

var curX:float;
var curZ:float;

function Start () {

curX=transform.position.x;
curZ=transform.position.z;

}

function Update () {
transform.Translate(0.01*Time.deltaTime, 0, 0.01*Time.deltaTime);
if((transform.position.x)>(curX+0.01)) 
{
transform.position.x=curX;
}


if((transform.position.z)>(curZ+0.007)) 
{
transform.position.z=curZ;
}


}