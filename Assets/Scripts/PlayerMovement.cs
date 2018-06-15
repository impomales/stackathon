using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	// Update is called once per frame
	public Text gameOver;
	private bool wall;

	void Start()
	{
		gameOver.text = "";
		wall = false;
	}

	void Update ()
	{
		float moveVertical = 0;
		float moveHorizontal = 0;

		if (transform.position.y < 0) gameOver.text ="Game Over!";

		if (Input.GetKeyDown("up")) moveVertical = 1;
		if (Input.GetKeyDown("down")) moveVertical = -1;
		if (Input.GetKeyDown("left")) moveHorizontal = -1;
		if (Input.GetKeyDown("right")) moveHorizontal = 1;

		transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));
		if (wall) transform.Translate(new Vector3(-1, 0, 0));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.SetActive(false);
		}
		else if (other.gameObject.CompareTag("Collision"))
		{
			gameOver.text = "Game Over!";
		}
		else if (other.gameObject.CompareTag("Stationary"))
		{
			wall = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		wall = false;
	}
}
