using UnityEngine;
using System.Collections;

public class ChangeTextColor : MonoBehaviour {

    public Color overcolor = Color.yellow;
    public Color clickcolor = Color.red;
    public Color exitcolor = Color.white;
    TextMesh textMesh;

    // Use this for initialization
    void Start () {
        //var text = new GameObject("Text");
        textMesh = GetComponent<TextMesh>();
        //text.AddComponent<MeshCollider>();
	}

    void OnMouseOver()
    {
        textMesh.color = overcolor;

        if (Input.GetButton("Fire1"))
        {
            textMesh.color = clickcolor;
        }
    }

    void OnMouseExit()
    {
        textMesh.color = exitcolor;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
