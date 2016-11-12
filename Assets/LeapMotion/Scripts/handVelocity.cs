using UnityEngine;
using System.Collections;
using Leap;

public class handVelocity : MonoBehaviour {
	public Transform palm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody palmBody = palm.GetComponent<Rigidbody>();
//		Vel ();
		//Debug.Log ("velocity="+palmBody.velocity.y);
	}
//	float Vel(){
//		Rigidbody palmBody = palm.GetComponent<Rigidbody>();
//		vel = palmBody.velocity.y;
//		return vel;
//	}
}
