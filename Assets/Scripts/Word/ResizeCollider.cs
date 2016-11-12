using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider))]
public class ResizeCollider : MonoBehaviour {

    public float paddingX;
    public float paddingY;
    BoxCollider boxCollider;
    Renderer renderer;

    void SizeCollider()
    {
        boxCollider = (BoxCollider)gameObject.AddComponent(typeof(BoxCollider));
        renderer = (Renderer)gameObject.AddComponent(typeof(Renderer));
        boxCollider.center = new Vector3(renderer.bounds.extents.x - renderer.bounds.size.x / 2, renderer.bounds.extents.y - renderer.bounds.size.y / 2, transform.position.z);
        boxCollider.size = new Vector3(renderer.bounds.size.x + paddingX, renderer.bounds.size.y + paddingY, 1);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
