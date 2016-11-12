using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FontScalable : MonoBehaviour {

    [Range(1, 6)]
    public float fontScale = 1;
    TextMesh textMesh;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 defaultScale = new Vector3(1, 1, 1) * fontScale;
        int fontSize = textMesh.fontSize;
        fontSize = fontSize == 0 ? 12 : fontSize;

        float scale = 0.1f * 128 / fontSize;
        transform.localScale = defaultScale * scale;
	}
}
