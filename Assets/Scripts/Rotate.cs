using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(10, 60, 0) * Time.deltaTime);
	}
}
