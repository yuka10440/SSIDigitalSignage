using UnityEngine;
using System.Collections;


public class itween : MonoBehaviour {
	GameObject obj1;
	//GameObject obj2;
	//GameObject obj3;
	// Use this for initialization
	void Start () {
		obj1 = GameObject.FindGameObjectWithTag ("Square");
		//obj2 = GameObject.FindGameObjectWithTag ("Sphere");
		//obj3 = GameObject.FindGameObjectWithTag ("Dot"); 
		FadeOut (obj1);
		//FadeOut (obj2);
		//FadeOut (obj3);
		iTween.MoveTo (obj1, iTween.Hash ("path", iTweenPath.GetPath ("cubePath"), "time", 5,"easetype","linear"));
		//iTween.FadeTo (obj2, 0f, 3f);
		//iTween.MoveTo (obj2, iTween.Hash ("x",-3, "time", 5,"easetype","linear"));
		//iTween.MoveTo (obj3, iTween.Hash ("y", -3, "time", 5, "easetype", "linear"));

		//iTween.MoveAdd (gameObject, iTween.Hash ("orienttopath", true));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void FadeOut(GameObject obj){
		iTween.FadeTo (obj,0.0f,3f
			);
	}
	public void FadeIn(){
		iTween.FadeTo(gameObject,1.0f,5f);
	}

		  

}
