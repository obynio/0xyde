//this script detachs the object to the world immediately. Useful when you know its parent will die very soon but you need this object.

#pragma strict



function Start () {
transform.parent=null;

}

function Update () {

}