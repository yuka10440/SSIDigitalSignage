using UnityEngine;
using System.Collections;
using Leap;

public class Swipe_Gesture : MonoBehaviour {
	Controller controller;
	HandModel handModel;	//hand Components
	Hand leapHand;
	FingerModel finger;

	RectTransform container;
	public GameObject b1;	//Button1
	public GameObject b2;	//Button2
	public GameObject b3;	//Button3
	public GameObject b4;	//Button4
	public bool isOpen;		//isOpen for DropDown Example
	public Transform palm;	//palm for hand's speed calculation


	void Start () {


		container = GameObject.Find("Container").GetComponent<RectTransform>();

		isOpen = false; 	//Only for DropDown Test
		handModel = GetComponent<HandModel> ();
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 50f);	//Set Gesture: Minimum Length
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 400f);	//Set Gestrue: Minimum Velocity
		controller.Config.Save ();
	}
	
	void Update () {


		//Define fingers
		FingerModel finger1 = handModel.fingers[1];//get index finger
		FingerModel finger2 = handModel.fingers[2];//get middle finger
		FingerModel finger3 = handModel.fingers [3];//get kusuri-yubi finger
		Rigidbody palmBody = palm.GetComponent<Rigidbody>();
		Frame frame = controller.Frame ();

		//caculate distance between fingers
		float dis = Mathf.Abs (finger2.GetTipPosition ().x - finger1.GetTipPosition ().x);
		float dis2 = Mathf.Abs (finger3.GetTipPosition ().y - finger2.GetTipPosition ().y);

		//calculate velocity of hand
		float vel = palmBody.velocity.y;



		//Gesture Setting
		GestureList gestures = frame.Gestures();
			for(int i=0;i<gestures.Count;i++) {
				Gesture gesture = gestures[i];
				if(gesture.Type == Gesture.GestureType.TYPESWIPE){
					SwipeGesture Swipe = new SwipeGesture(gesture);
					Vector SwipeDirection = Swipe.Direction;

				/** Vertical Swipe Direction 
				   y: 	hand Direction
				 vel: 	minimum velocity to recognize the action  
				 dis:	minimum distance to travel of hand
				dis2:	fingertip distance 
				 **/
				if(SwipeDirection.y<0 && dis<0.35 && vel <-2 && dis2>0.7){
					//On ();
					//Debug.Log("DOWN");//Gesture Confirm
					b1.SetActive(true);
					b2.SetActive(true);
					b3.SetActive(true);
					b4.SetActive(true);
					iTween.MoveTo (b1, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath1"), "time", 1.20,"easetype","easeOutBack"));
					iTween.MoveTo (b2, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath2"), "time", 1.20,"easetype","easeOutBack"));
					iTween.MoveTo (b3, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath3"), "time", 1.20,"easetype","easeOutBack"));
					iTween.MoveTo (b4, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath4"), "time", 1.20,"easetype","easeOutBack"));

				}else if(SwipeDirection.y>0 && vel>5){
					//Debug.Log ("UP");
					iTween.MoveFrom (b1, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath1"), "time", .20,"easetype","linear"));
					iTween.MoveFrom (b2, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath2"), "time", .20,"easetype","linear"));
					iTween.MoveFrom (b3, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath3"), "time", .20,"easetype","linear"));
					iTween.MoveFrom (b4, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath4"), "time", .20,"easetype","linear"));
					b1.SetActive(false);
					b2.SetActive(false);
					b3.SetActive(false);
					b4.SetActive(false);

						//------------Use Below When using lerp--------------
						//isOpen=false;
						//Vector3 scale = container.localScale;
						//scale.y = Mathf.Lerp (scale.y, 0, Time.deltaTime*10);
						//container.localScale = scale;
					}
//				Vector3 scale = container.localScale;
//				scale.y = Mathf.Lerp (scale.y, isOpen? 1:0, Time.deltaTime*20);
//				container.localScale = scale;
			}
		}
	}

//	void On(){
//		Vector3 scale = container.localScale;
//		scale.y = Mathf.Lerp (scale.y, 1, Time.deltaTime*15);
//		container.localScale = scale;
//	}
}

