using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Josh Shucker
 * Circling component can be attached to any object
 * Receives event call from Player to start caclulations
 * Calculates total angle of mouse movement around object
 * Completes calculation when it receives event call from Player to stop
 * If total angle is greater than its angle limit, it assumes it was circled and destroys object
 */

public class CirclingComponent : MonoBehaviour
{
    // the total angle of the mouse movement around the object
    private float _totalAngle = 0;
    // the limit the total angle must surpass to count as circling the object
    private const float ANGLE_LIMIT = 330.0f;
    // the time to wait between angle calculations
    private const float TIME_BETWEEN_CHECKS = 0.05f;
    // the direction vector from this object to the mouse during the previous calculation
    private Vector2 _prevVec;
    // whether calculations are currently active
    private bool calculate = false;

    /* Subscribe to the click and release events when object is active*/
    private void OnEnable()
    {
        PlayerController.OnClick += CalculateCircling;
        PlayerController.OnRelease += CheckIfCircled;
    }
    /* Unsubscribe to the click and release events when object is inactive*/
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

    /* Called when player presses mouse, starts angle calculation*/ 
    void CalculateCircling()
    {
        // indicate that calculation is in progress
        calculate = true;
        // reset total angle 
        _totalAngle = 0;
        // set value for previous vec to current vector between this object and mouse
        _prevVec = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        // begin calculation
        StartCoroutine(GetAngleSegment());
    }

    /* Called when player releases mouse, checks how far player circled in total*/
    void CheckIfCircled()
    {
        calculate = false;
    }

    /* Finds the angle of how far the player has circled in TIME_BETWEEN_CHECKS */
    IEnumerator GetAngleSegment()
    {
        // if the player is still dragging...     
        if (calculate)
        {
            // get vector from this object to mouse at this moment
            Vector2 currentVec = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            if(currentVec != _prevVec)
            {
                // find angle between current vector and the previous check
                float theta = Mathf.Acos(Vector3.Dot(_prevVec, currentVec) / (Mathf.Abs(_prevVec.magnitude * currentVec.magnitude)));
                //convert to degrees
                theta *= (180 / Mathf.PI);
                // check z component of cross product for sign (gives direction of rotation)
                int dir = Vector3.Cross(_prevVec, currentVec).z > 0 ? 1 : -1;
                // add the angle between the vectors to the total amount rotated
                _totalAngle += (dir * theta);
                // set previous vector to current vector
                _prevVec = currentVec;
            }            
            // wait before repeating
            yield return new WaitForSeconds(TIME_BETWEEN_CHECKS);
            // repeat calculation for next angle segment
            StartCoroutine(GetAngleSegment());
        }
        else
        {
            //get absolute value of angle (in case it was a circle in negative direction)
            _totalAngle = Mathf.Abs(_totalAngle);
            // if the angle is greater than the angle limit, the object is circled
            if (_totalAngle >= ANGLE_LIMIT)
            {
                Destroy(this.gameObject);
            }
        }     
        yield return null;
    }
}
