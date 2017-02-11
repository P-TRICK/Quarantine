using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingComponent : MonoBehaviour
{

    private void OnEnable()
    {
        PlayerController.OnClick += CalculateCircling;
        PlayerController.OnRelease += CheckIfCircled;
    }

    private void OnDisable()
    {
        PlayerController.OnClick -= CalculateCircling;
        PlayerController.OnRelease -= CheckIfCircled;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CalculateCircling()
    {
        Debug.Log("Calculating if " + gameObject.name + " is being circled");
    }

    void CheckIfCircled()
    {
        Debug.Log("Mouse released, check if " + gameObject.name + " should be destroyed");
    }
}
