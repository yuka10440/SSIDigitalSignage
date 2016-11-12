using UnityEngine;
using System.Collections;

public class FlyingObject : MonoBehaviour {

    public Rigidbody rb;
    private const float G = 9.9f;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        var velocity = new Vector3(0, 0, 0);
        velocity.x += Input.GetAxis("Horizontal");
        velocity.y += Input.GetAxis("Vertical");
        //if (Input.GetButton("Fire1"))
        //{
        //    velocity.z += 1.0f;
        //}
        //if (Input.GetButton("Fire2"))
        //{
        //    velocity.z += -1.0f;
        //}

        rb.velocity = velocity * 500 * Time.deltaTime + new Vector3(0, G + Random.Range(0.0f, 10.0f), 0) * Time.deltaTime;
        var originalRotation = rb.rotation;
        var yEular = 0.0f;

        if (rb.velocity.x > 0)
        {
            yEular = -5.0f;
        }
        else if (rb.velocity.x < 0)
        {
            yEular = 5.0f;
        }

        var xEular = 0.0f;

        if (rb.velocity.y > 0)
        {
            xEular = 5.0f;
        }
        else if (rb.velocity.y < 0)
        {
            xEular = -5.0f;
        }

        var eular = new Vector3(xEular, yEular, 0);
        rb.rotation = Quaternion.Euler(eular);
	}
}
