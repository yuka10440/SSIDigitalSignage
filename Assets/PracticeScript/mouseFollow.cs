using UnityEngine;
using System.Collections;
using Leap;


public class mouseFollow : MonoBehaviour {

	void Start(){
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
			//transform.position = GetComponentInParent<patternTest> ().indexTip;
			transform.position = GetComponentInParent<patternTest_2> ().indexTip;

	}
}
