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
		objectToMoveTo = GameObject.Find("ObjectiveObject");
	}
	
	// Update is called once per frame
	void Update () {
        if(objectToMoveTo != null)
		    transform.position = Vector3.MoveTowards(transform.position, objectToMoveTo.transform.position, speed * Time.deltaTime);
	}
}
