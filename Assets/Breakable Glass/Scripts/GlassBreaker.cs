using UnityEngine;
using System.Collections;

public class GlassBreaker : MonoBehaviour {
	//Vector3 vel;
	BreakGlass g;
	void FixedUpdate () {
		//vel = rigidbody.velocity;
	}
	
	void OnCollisionEnter (Collision col) {
		if(col.gameObject.GetComponent<BreakGlass>()!=null){
			//g = col.gameObject.GetComponent<BreakGlass>();
			//rigidbody.velocity = vel * g.SlowdownCoefficient;
			col.gameObject.GetComponent<BreakGlass>().BreakIt();
			/*if(g.BreakByVelocity){
				if(col.relativeVelocity.magnitude >= g.BreakVelocity){
					col.gameObject.GetComponent<BreakGlass>().BreakIt();
					return;	
				}
			}
			
			if(g.BreakByImpulse){
				if(col.relativeVelocity.magnitude * rigidbody.mass >= g.BreakImpulse){
					col.gameObject.GetComponent<BreakGlass>().BreakIt();
					return;	
				}
			}*/
			
		}
	}
}
