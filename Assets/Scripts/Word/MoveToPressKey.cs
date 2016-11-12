using UnityEngine;
using System.Collections;

public class MoveToPressKey : MonoBehaviour {

    float a = 0.2f;
    float b = -0.2f;


	// Use this for initialization
	void Start () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += this.transform.up * a;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += this.transform.up * b;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += this.transform.right * a;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += this.transform.right * b;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    this.transform.position += this.transform.up * a;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    this.transform.position += this.transform.up * b;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.transform.position += this.transform.right * a;
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    this.transform.position += this.transform.right * b;
        //}

    }
}
