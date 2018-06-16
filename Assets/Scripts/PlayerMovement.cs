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
	public float rightBound;
	public float leftBound;
	public GameObject eagle;
	private float time;
	private bool isDirty;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		gameOver.text = "";
		time = 5;
		isDirty = false;
	}

	void Update ()
	{
		if (transform.position.y < 0 ||
				transform.position.x > rightBound ||
				transform.position.x < leftBound)
				handleGameOver("YOU FAIL!");
		float moveVertical = 0;
		float moveHorizontal = 0;
		time -= Time.deltaTime;
		if (time <= 0 && isDirty) {
			time = 10;
			eagle.GetComponent<EagleAnimation>().kill = true;
		}
		if (Input.anyKeyDown) {
			time = 5;
			isDirty = true;
		}

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
		Invoke("reloadGame", 0.5f);
	}

	private void reloadGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
