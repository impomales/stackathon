using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public float speed;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, speed * Time.deltaTime);
		// try move to for smoother camera.
	}
}
