using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour {
	private GameObject objectToMoveTo;

	[SerializeField]
	private int speed;

	// Use this for initialization
	void Start () {
		// Finds 
		objectToMoveTo = GameObject.Find("Object");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, objectToMoveTo.transform.position, speed * Time.deltaTime);
	}
}
