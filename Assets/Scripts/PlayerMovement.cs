using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	// Update is called once per frame
	void Update ()
	{
		float moveVertical = 0;
		float moveHorizontal = 0;

		if (Input.GetKeyDown("up")) moveVertical = 1;
		if (Input.GetKeyDown("down")) moveVertical = -1;
		if (Input.GetKeyDown("left")) moveHorizontal = -1;
		if (Input.GetKeyDown("right")) moveHorizontal = 1;

		transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));

	}
}
