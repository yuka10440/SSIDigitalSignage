using UnityEngine;
using System.Collections;
using Leap;

public class raycastTest : MonoBehaviour 
{
	HandModel handModel;
	Hand leapHand;

	// Use this for initialization
	void Start () 
	{
		handModel = GetComponent<HandModel>();
		leapHand = handModel.GetLeapHand ();
		if (leapHand == null) 
		{
			Debug.LogError ("No leapHand Founded");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;
		int layerMask = 1 << 8;
		for (int i = 0; i < HandModel.NUM_FINGERS; i++) 
		{
			FingerModel finger = handModel.fingers[i];
			if(Physics.Raycast(finger.GetTipPosition(),fwd,out hit,layerMask))
			{
				float distanceToGround = hit.distance;
				Debug.Log ("hit something"+distanceToGround);
			}
			Debug.DrawRay(finger.GetTipPosition(),finger.GetRay().direction, Color.red);
		}

	}
}
