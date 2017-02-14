using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Josh Shucker
 * Base class for the player
 * Causes object to follow mouse
 * Handles trail activation and deactivation on mouse click and release
 * Calls events on mouse click and release for CirclingComponent functions
 */
public class PlayerController : MonoBehaviour {

    // Event declaration for click and release events
    public delegate void ClickAction();
    public static event ClickAction OnClick;
    public static event ClickAction OnRelease;

    // handle to trail component
    private TrailRenderer _trail;


	// Use this for initialization
	void Start ()
    {
        /// get trail component and set to inactive at start 
        _trail = GetComponent<TrailRenderer>();
        _trail.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowMouse();
        CheckMouseClick();
	}

    /* Called in update, causes this object to follow the mouse */
    private void FollowMouse()
    {   
        // convert mouse position to world coordinates
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // set z component to this objects z to avoid changing its value
        worldPoint.z = transform.position.z;
        // move this object to the mouse position
        transform.position = worldPoint;
    }

    /* Handles events and trail rendering for mouse click and release*/
    private void CheckMouseClick()
    {
        // if player clicks left mouse button (or taps)
        if(Input.GetMouseButtonDown(0))
        {
            // enable the trail renderer
            _trail.enabled = true;
            // call the click event
            OnClick();
        }
        // if player releases left mouse button (or completes tap)
        else if (Input.GetMouseButtonUp(0))
        {
            // clear the trail from the screen
            _trail.Clear();
            // disable the trail renderer
            _trail.enabled = false;
            // call the release event
            OnRelease();
        }
    }

   
}
