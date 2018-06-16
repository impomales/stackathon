using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	// Update is called once per frame
	public Rigidbody rb;
	public Text gameOver;
	public int coins;
	public Text coinsDisplay;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		gameOver.text = "";
	}

	void Update ()
	{
		if (transform.position.y < 0) handleGameOver("YOU FAIL!");
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
			coinsDisplay.text = "Coins: " + coins;
		}
		else if (other.gameObject.CompareTag("Stationary"))
		{
			Debug.Log("HI");
			rb.velocity = Vector3.zero;
		}
		else if (other.gameObject.CompareTag("Collision"))
		{
			handleGameOver("YOU DIE!");
		}
		else if (other.gameObject.CompareTag("Finish"))
		{
			handleGameOver("YOU WIN!");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Stationary"))
		{
			rb.velocity = Vector3.zero;
		}
	}

	private void handleGameOver(string message)
	{
		gameOver.text = message;
		Invoke("reloadGame", 1f);
	}

	private void reloadGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
