using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAnimation : MonoBehaviour {
	public bool kill;
	public float speed;
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		kill = false;
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (kill) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		else transform.position = Vector3.MoveTowards(transform.position, player.transform.position + offset, speed * Time.deltaTime);
	}
}
