using UnityEngine;
using System.Collections;

public class SkyBoxRotator : MonoBehaviour {

	Vector3 rotation = new Vector3 (0, 0, 0.01f);
	//Vector3 rotation = new Vector3 (0.01f, 0, 0);
	
	void Update () {
		transform.Rotate (rotation);
		var pos = transform.localScale;
		pos *= 1.0001f;
		transform.localScale = pos;
	}
}
