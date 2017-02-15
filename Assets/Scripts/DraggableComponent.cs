using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableComponent : MonoBehaviour {

    public Rigidbody2D rigidBody;
    
	//Contains current object location on screen
    public Vector2 objectPlace;

	//Contains object transform info
	public Transform objectTransform;

	//Mouse position is relative to game world (otherwise itll be wayyy out there)
	public Vector2 mousePos;
	public float objX;
	public float objY;

	private Vector2 _newPos;

	// Use this for initialization
	void Start () {
        //Get the rigidBody component of the player
        rigidBody = GetComponent<Rigidbody2D>();
		//Gets transfrom component
		objectTransform = GameObject.Find("ObjectiveObject").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown(){
        //Debug.Log("Clicked!");

        
		//**NOT NECESSARY TO CALL FOR SPECIFIC NAME OF OBJECT -JOSH'S SUGGESTION
		//
		//
		//objectPlace = GameObject.FindGameObjectWithTag("Object").transform.position;
		//
		//above will search for object of specific name tag, thus it is not needed for this
		//script which will be potentially used for multiple objects


		//**KEN'S INFO - ScreenToWorldPoint TO MOVE FROM PIXEL SCREEN SPACE TO GAME WORLD SPACE

		/*attempt 1    - tried to change object position to pixel type (the same as cursor)
		 * 
		 * Camera.main.WorldToScreenPoint(transform.position);
		 *
		*/

		/*attempt 2    - for some reason, tried to make object of the type it already was
		*               was cause of weird offset
		*ScreenToWorldPoint(transform.position);
		*
		*/

		objectPlace = transform.position;

		//Gets actual mouse position (to the same type as object (world))
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


		//*** BAD
		//*** dont want modification of mouse pos in this case
		//** also dont want screen to world translation
		//
		//Puts mouse position relative to world view (so 0,0 is center)  xxxx
		//
		//
		//mousePos = Camera.main.ScreenToWorldPoint (mousePos);

		//*** BAD
		//*** same problem as above
		//
		//
		//mousePos = Camera.main.WorldToScreenPoint(objectPlace);

		//to find distance of mouse from obj in x and y
		objX = mousePos.x - objectPlace.x;      //Input.mousePosition.x - objectPlace.x; >> this does not use mouse pos relative to world screen
		objY = mousePos.y - objectPlace.y;      //Input.mousePosition.y - objectPlace.y; >> this does not use mouse pos relative to world screen

		//DEBUG TESTS
		//
		//
		//Debug.Log (mousePos);
		//Debug.Log (objX);
		//Debug.Log (objY);
		//Debug.Log (objectPlace);
    }

	//For draggin the object
	void OnMouseDrag(){
		//Debug.Log (objectPlace);

		//** BAD XXXX    INCREASED OBJECT POSITION BY NOT ADJUSTING TO DISPLACEMENT
		//_newPos = new Vector2 (Input.mousePosition.x + objectPlace.x, Input.mousePosition.y + objectPlace.y);

		//AFTER FINDING DISPLACEMENT WHEN THE OBJECT IS FIRST CLICKED
		//THIS CREATES A NEW VECTOR2 WHERE THE MOUSE IS 'TECHNICALLY' AT THE CENTER OF THE OBJECT
		//IT IS DRAGGING BY SUBTRACTING THE CURRENT MOUSE POSITION BY THE AMOUNT OF
		//ITS DISPLACEMENT
		//mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_newPos = new Vector2(Input.mousePosition.x - objX , Input.mousePosition.y - objY);

		//(mousePos.x - objX, mousePos.y - objY);

		//change from screen to world value, to apply change
		Vector2 finPos = Camera.main.ScreenToWorldPoint (_newPos);
		transform.position = finPos;//_newPos;

		//objectPlace = GameObject.FindGameObjectWithTag("Object").transform.position;

		//Debug.Log (objectPlace);
	}
}
