#pragma strict

var state:String; 					// the state of the zombie. always lowercase. for example "idle" "funnywalk" "zombierun". It is good if it has the same name as its animation
// if state is ALL UPPERCASE then it is a special state that cannot be described by an animation (dead or random or similar)
var timer:float=30; 				//SET IN FRAMES NOT SECONDS!! the timer variable used to keep track of the time, when a state has to change. 
private var hitImmune:float=0.1;	//to be less consistent, it is in seconds, so 0.1 is one tenth of a second
var rnd:float; 						//temporarly storing any random value. only use while it is hot, else it might get spoiled :)
private var size:float;

function Start () {

size=Random.Range(0.95, 1.05);
transform.localScale=Vector3(size, size, size);

if (!state) state="idle_normal";

}

function Update () {

if (Input.GetKey ("space") && state != "DEAD")
{
state="danceThriller";
timer=122;
}

if (timer>0) timer-=Time.deltaTime*30;  //cus its in frames, not seconds
if (hitImmune>0) hitImmune-=Time.deltaTime; //to be less consistent, it is in seconds, so 0.1 is one tenth of a second


//CHANGING STATES IF NEEDED - everything separately checks if time is <= 0


if ((state=="idle_normal") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	

	if (rnd<40)
		{ 
		state="idle_normal";
		timer=30;
		}

	if ((rnd>40)&&(rnd<50))
		{ 
		state="idle_scratchHead";
		timer=50;
		}

	if ((rnd>50)&&(rnd<60))
		{ 
		state="idle_lookAround";
		timer=90;
		}

	if ((rnd>60)&&(rnd<70))
		{ 
		state="crouch";
		timer=30;
		}
	if ((rnd>70)&&(rnd<100))  //begins to move. but how??
		{ 
		state="MOVE";  //sends to a special state
		}
	}


if ((state=="funnierWalk") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	
	if ((rnd>0)&&(rnd<90))
		{ 
		state="funnierWalk";
		timer=30;
		}
	if ((rnd>90)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}

if ((state=="funnyWalk") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	
	if ((rnd>0)&&(rnd<90))
		{ 
		state="funnyWalk";
		timer=30;
		}
	if ((rnd>90)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}
if ((state=="run") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	
	if ((rnd>0)&&(rnd<80))
		{ 
		state="run";
		timer=30;
		}

	if ((rnd>80)&&(rnd<90))
		{ 
		state="jump";
		timer=23;
		}

	if ((rnd>90)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}

if ((state=="simpleWalk") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	
	if ((rnd>0)&&(rnd<90))
		{ 
		state="simpleWalk";
		timer=30;
		}
	if ((rnd>90)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}

if ((state=="shamble") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	
	if ((rnd>0)&&(rnd<90))
		{ 
		state="shamble";
		timer=30;
		}
	if ((rnd>90)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}






if ((state=="idle_scratchHead") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}

if ((state=="fallToFace") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	if ((rnd>0)&&(rnd<25))
		{			
		state="standUpFromFace";
		timer=30;
		}
	if ((rnd>25)&&(rnd<75))
		{			
		state="crawl";
		timer=30;
		}
	if ((rnd>75)&&(rnd<100))
		{			
		state="DEAD";  //That is not dead which can eternal lie. And with strange aeons even death may die. 
		timer=0;
		}
	}

if ((state=="fallToBack") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	if ((rnd>0)&&(rnd<50))
		{			
		state="standUpFromBack";
		timer=40;
		}
	if ((rnd>50)&&(rnd<100))
		{			
		state="DEAD";  //Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn
		timer=0;
		}
	}

if ((state=="crawl") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	if ((rnd>0)&&(rnd<90))
		{			
		state="crawl";
		timer=30;
		}
	if ((rnd>90)&&(rnd<100))
		{			
		state="standUpFromFace";  //Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn
		timer=0;
		}
	}

if ((state=="standUpFromBack") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}

if ((state=="burrowUp") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}

if ((state=="standUpFromFace") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}


if ((state=="jump") && (timer <= 0))
	{
	state="run";
	timer=20;
	}


if ((state=="idle_lookAround") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}

if ((state=="hit1") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}

if ((state=="hit2") && (timer <= 0))
	{
	state="idle_normal";
	timer=30;
	}




if ((state=="crouch") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	if (rnd<50)
		{ 
		state="crouch";
		timer=30;
		}

	if ((rnd>50)&&(rnd<60))
		{ 
		state="crouch_eat1";
		timer=90;
		}

	if ((rnd>60)&&(rnd<70))
		{ 
		state="crouch_eat2";
		timer=90;
		}

	if ((rnd>70)&&(rnd<95))
		{ 
		state="crouchMove";
		timer=30;
		}

	if ((rnd>95)&&(rnd<100))
		{ 
		state="idle_normal";
		timer=30;
		}
	}

if ((state=="crouch_eat2") && (timer <= 0))
	{
	state="crouch";
	timer=30;
	}

if ((state=="crouch_eat1") && (timer <= 0))
	{
	state="crouch";
	timer=30;
	}

if ((state=="danceThriller") && (timer <= 0))
	{
	state="MOVE";
	}

if ((state=="crouchMove") && (timer <= 0))
	{
	rnd = Random.Range(1, 100);	
	if (rnd<90)
		{ 
		state="crouchMove";
		timer=30;
		}
	if (rnd>90)
		{ 
		state="crouch";
		timer=30;
		}

	}

if (state=="MOVE")  //this is a special state, we do not check for timers
	{
		rnd = Random.Range(1, 100);	
		
		if ((rnd>0)&&(rnd<20))
			{ 
			state="funnyWalk";
			timer=30;
			}
		if ((rnd>20)&&(rnd<40))
			{ 
			state="funnierWalk";
			timer=30;
			}

		if ((rnd>40)&&(rnd<60))
			{ 
			state="shamble";
			timer=30;
			}

		if ((rnd>60)&&(rnd<80))
			{ 
			state="simpleWalk";
			timer=30;
			}

		if ((rnd>80)&&(rnd<100))
			{ 
			state="run";
			timer=40;
			}
	}

if (state=="BEGINMOVE")  //this is a special state, we do not check for timers
	{
		rnd = Random.Range(1, 100);	
		
		if ((rnd>0)&&(rnd<15))
			{ 
			state="funnyWalk";
			timer=30;
			}
		if ((rnd>15)&&(rnd<35))
			{ 
			state="funnierWalk";
			timer=30;
			}

		if ((rnd>30)&&(rnd<45))
			{ 
			state="shamble";
			timer=30;
			}

		if ((rnd>45)&&(rnd<60))
			{ 
			state="simpleWalk";
			timer=30;
			}

		if ((rnd>60)&&(rnd<80))
			{ 
			state="run";
			timer=40;
			}

		if ((rnd>80)&&(rnd<90))
			{ 
			state="crawl";
			timer=60;
			}

		if ((rnd>90)&&(rnd<100))
			{ 
			state="crouchMove";
			timer=60;
			}



	}

if (state=="DEAD")
	{
	collider.enabled = false;
	transform.Translate(0, -0.1*Time.deltaTime, 0);
	if (transform.position.y<-0.5) Destroy(gameObject);
	}


// PLAY ANIMATIONS ACCORDING TO STATES


if ((state=="idle_normal") && !animation.IsPlaying("idle_normal"))
{
animation.CrossFade("idle_normal", 0.2);
}

if ((state=="idle_lookAround") && !animation.IsPlaying("idle_lookAround"))
{
animation.CrossFade("idle_lookAround", 0.2);
}

if ((state=="idle_scratchHead") && !animation.IsPlaying("idle_scratchHead"))
{
animation.CrossFade("idle_scratchHead", 0.2);
}

if ((state=="crouch") && !animation.IsPlaying("crouch"))
{
animation.CrossFade("crouch", 0.2);
}

if ((state=="crouch_eat2") && !animation.IsPlaying("crouch_eat2"))
{
animation.CrossFade("crouch_eat2", 0.2);
}

if ((state=="crouch_eat1") && !animation.IsPlaying("crouch_eat1"))
{
animation.CrossFade("crouch_eat1", 0.2);
}

if ((state=="funnyWalk") && !animation.IsPlaying("funnyWalk"))
{
animation.CrossFade("funnyWalk", 0.2);
}

if (state=="funnyWalk") 
{
transform.Translate(0, 0, 1*Time.deltaTime);
}
if (state=="funnierWalk") 
{
transform.Translate(0, 0, 1*Time.deltaTime);
}
if (state=="run") 
{
transform.Translate(0, 0, 3*Time.deltaTime);
}
if (state=="jump") 
{
transform.Translate(0, 0, 3*Time.deltaTime);
}
if (state=="simpleWalk") 
{
transform.Translate(0, 0, 0.75*Time.deltaTime);
}
if (state=="crouchMove") 
{
transform.Translate(0, 0, 1*Time.deltaTime);
}
if (state=="shamble") 
{
transform.Translate(0, 0, 1*Time.deltaTime);
}
if (state=="crawl") 
{
transform.Translate(0, 0, 1*Time.deltaTime);
}





if ((state=="funnierWalk") && !animation.IsPlaying("funnierWalk"))
{
animation.CrossFade("funnierWalk", 0.2);
}

if ((state=="shamble") && !animation.IsPlaying("shamble"))
{
animation.CrossFade("shamble", 0.2);
}

if ((state=="run") && !animation.IsPlaying("run"))
{
animation.CrossFade("run", 0.2);
}

if ((state=="simpleWalk") && !animation.IsPlaying("simpleWalk"))
{
animation.CrossFade("simpleWalk", 0.2);
}

if ((state=="crouchMove") && !animation.IsPlaying("crouchMove"))
{
animation.CrossFade("crouchMove", 0.2);
}

if ((state=="jump") && !animation.IsPlaying("jump"))
{
animation.CrossFade("jump", 0.1);
}

if ((state=="danceThriller") && !animation.IsPlaying("danceThriller"))
{
animation.CrossFade("danceThriller", 0.2);
animation["danceThriller"].time = Random.Range(0.00, 0.25);  //if they all dance really together, it is very artifical. This way its better.

}


if ((state=="hit1") && !animation.IsPlaying("hit1"))
{
animation.CrossFade("hit1", 0.2);
}


if ((state=="hit2") && !animation.IsPlaying("hit2"))
{
animation.CrossFade("hit2", 0.2);
}

if ((state=="burrowUp") && !animation.IsPlaying("burrowUp"))
{
animation.CrossFade("burrowUp", 0.2);
}



if ((state=="fallToFace") && !animation.IsPlaying("fallToFace"))
{
collider.enabled = false;
animation.CrossFade("fallToFace", 0.2);
}


if ((state=="fallToBack") && !animation.IsPlaying("fallToBack"))
{
collider.enabled = false;
animation.CrossFade("fallToBack", 0.2);
}

if ((state=="standUpFromBack") && !animation.IsPlaying("standUpFromBack"))
{
collider.enabled = true;
animation.CrossFade("standUpFromBack", 0.2);
}

if ((state=="standUpFromFace") && !animation.IsPlaying("standUpFromFace"))
{
collider.enabled = true;
animation.CrossFade("standUpFromFace", 0.2);
}

if ((state=="crawl") && !animation.IsPlaying("crawl"))
{
collider.enabled = true;
animation.CrossFade("crawl", 0.2);
}


}


function OnCollisionEnter(collision: Collision) 
	{

	
	if ((collision.gameObject.tag == "explosion") && (hitImmune <= 0) && (state != "DEAD"))
		{
		hitImmune=0.5;
		rnd = Random.Range(1, 100);	
	
		if ((rnd>0)&&(rnd<25))
			{
			state="hit1";
			timer=20;
			hitImmune=0.2;
			}

		if ((rnd>25)&&(rnd<50))
			{
			state="hit2";
			timer=20;
			hitImmune=0.2;
			}
		
		if ((rnd>50)&&(rnd<75))
			{
			state="fallToFace";
			timer=27;
			}

		if ((rnd>75)&&(rnd<100))
			{
			state="fallToBack";
			timer=28;
			}



		}

	if (collision.gameObject.tag == "destroyer")
		{
	Debug.Log("destroy");
		Destroy (gameObject);
		}
	}