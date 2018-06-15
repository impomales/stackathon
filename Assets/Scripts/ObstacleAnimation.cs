using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour {
	public float speed;
	public bool toward;
	private float step;

	// Update is called once per frame
	void Update () {
		if (toward && transform.position.x > 	12) transform.Translate(new Vector3(-24, 0, 0));
		else if (!toward && transform.position.x < -12) transform.Translate(new Vector3(24, 0, 0));
		step = speed * Time.deltaTime;
		if (!toward) step *= -1;
		transform.Translate(new Vector3(step, 0, 0));
	}
}
