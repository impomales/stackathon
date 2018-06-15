using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	// Update is called once per frame
	public Rigidbody rb;
	public Text gameOver;
	public int coins;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		gameOver.text = "";
	}

	void Update ()
	{
		if (transform.position.y < 0) handleGameOver();
		float moveVertical = 0;
		float moveHorizontal = 0;

		if (Input.GetKeyDown("up")) moveVertical = 1;
		if (Input.GetKeyDown("down")) moveVertical = -1;
		if (Input.GetKeyDown("left")) moveHorizontal = -1;
		if (Input.GetKeyDown("right")) moveHorizontal = 1;

		transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{

			other.gameObject.SetActive(false);
			coins++;
		}
		else if (other.gameObject.CompareTag("Stationary"))
		{
			Debug.Log("HI");
			rb.velocity = Vector3.zero;
		}
		else if (other.gameObject.CompareTag("Collision"))
		{
			handleGameOver();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Stationary"))
		{
			rb.velocity = Vector3.zero;
		}
	}

	private void handleGameOver()
	{
		gameOver.text = "Game Over!";
	}
}
