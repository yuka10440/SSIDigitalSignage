using UnityEngine;
using System.Collections;

public class RandomCoordination : MonoBehaviour {

    // プレハブを変数に代入
    public GameObject text;

	// Use this for initialization
	void Start () {
        // オブジェクトの座標
        float x = Random.Range(0.0f, 2.0f);
        float y = Random.Range(0.0f, 2.0f);
        float z = Random.Range(0.0f, 2.0f);

        // オブジェクトを生産
        Instantiate(text, new Vector3(x, y, z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
