using UnityEngine;
using System.Collections;
using Leap;

public class SwipeItween : MonoBehaviour {
	Controller controller;

	public GameObject buttons;
	public int fingerCount;
	// Use this for initialization
	void Start () {
		buttons.SetActive (false);

		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 100f);
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 400f);
		controller.Config.Save ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		Frame frame = controller.Frame ();
		fingerCount = frame.Fingers.Count;
		Debug.Log (fingerCount);
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i<gestures.Count; i++) {
			Gesture gesture = gestures[i];
			if(gesture.Type == Gesture.GestureType.TYPESWIPE){
				SwipeGesture swipe = new SwipeGesture(gesture);
				Vector swipeDirection = swipe.Direction;
				if(swipeDirection.y<0){
					Debug.Log("Down Gesture");
					buttons.SetActive(true);
					iTween.MoveTo (buttons,iTween.Hash("path", iTweenPath.GetPath("mainMenu"),"time",1f,"easetype","easeInCubic"
					));
				}else if(swipeDirection.y>0){
					Debug.Log("Up Gesture");
					buttons.SetActive(false);
				}
			}
		}
	}
}
