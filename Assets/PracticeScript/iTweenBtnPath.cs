using UnityEngine;
using System.Collections;

public class iTweenBtnPath : MonoBehaviour {
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;

	// Use this for initialization
	void Start () {

		iTween.MoveTo (obj1, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath1"), "time", .20,"easetype","linear"));
		iTween.MoveTo (obj2, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath2"), "time", .20,"easetype","linear"));
		iTween.MoveTo (obj3, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath3"), "time", .20,"easetype","linear"));
		iTween.MoveTo (obj4, iTween.Hash ("path", iTweenPath.GetPath ("BtnPath4"), "time", .20,"easetype","linear"));


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
