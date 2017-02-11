using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public delegate void ClickAction();
    public static event ClickAction OnClick;
    public static event ClickAction OnRelease;

    TrailRenderer trail;


	// Use this for initialization
	void Start ()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowMouse();
        CheckMouseClick();
	}

    private void FollowMouse()
    {
        Vector3 screenPoint = Input.mousePosition;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = transform.position.z;
        transform.position = worldPoint;
        //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
    }

    private void CheckMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            trail.enabled = true;
            OnClick();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            trail.Clear();
            trail.enabled = false;
            OnRelease();
        }
    }

   
}
