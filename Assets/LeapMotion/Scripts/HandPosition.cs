using UnityEngine;
using System.Collections;
using Leap;

public class HandPosition : MonoBehaviour {

	HandModel hand_model;
	Hand leap_hand;
	
	void Start() 
	{
		hand_model = GetComponent<HandModel>();
		leap_hand = hand_model.GetLeapHand();
		if (leap_hand == null) Debug.LogError("No leap_hand founded");
	}
	
	void Update() 
	{
		for (int i = 0; i < HandModel.NUM_FINGERS;i++)
		{
			FingerModel finger = hand_model.fingers[i];
			// draw ray from finger tips (enable Gizmos in Game window to see)

			Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red); 
		}
	}
}
