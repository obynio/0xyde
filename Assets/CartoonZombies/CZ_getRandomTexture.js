#pragma strict


var texture:Texture[];
private var rndInt:int;

function Start () {

rndInt=Random.Range(0, texture.length);

renderer.material.mainTexture=texture[rndInt];

}

function Update () {

}