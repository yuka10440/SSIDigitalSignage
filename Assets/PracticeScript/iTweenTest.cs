using UnityEngine;
using System.Collections;

public class iTweenTest : MonoBehaviour {
	private Hashtable test;
	// Use this for initialization
	void Start () {
//		test = new Hashtable ();
//		test.Add ("time", 4);//taking time
//		test.Add ("x", 5);//moving direction: x-coordinate, distance value.
//		test.Add ("y", 3);//movaing direction: y-coordinate, distance value.
//
//		iTween.MoveTo (gameObject, test);
		iTween.MoveTo (gameObject, iTween.Hash ("path",iTweenPath.GetPath("pathTest"),"time",35));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
