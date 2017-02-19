using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Have to add   'using UnityEngine.UI'   to include 'Button' objects in the script
using UnityEngine.UI;
//Used to include the 'EventSystem'    will allow interaction with UI
using UnityEngine.EventSystems;

public class EricLee_MenuScript : MonoBehaviour 
{
	//As per tech chat's suggestion - use multiple panels vs setting new scenes - Ken + Josh

	//thanks to Josh for suggestions on setting panel objects to public 
	//this allowed the panels to be set to invisible before the game began

	//variables to store panel objects
	public GameObject mainMenu;
	public GameObject quitConfirm;

	//Button[] buttons;
	// Use this for initialization
	void Start () 
	{
		//finds 'MainMenu' panel by name
		//
		//_mainMenu = GameObject.Find("MainMenu");

		//finds 'QuitConfirmPanel' panel by name
		//
		//_quitConfirm = GameObject.Find ("QuitConfirmPanel");

		//sets panel to invisible as to not interfere with the main menu
		//while it is open
		//
		//quitConfirm.gameObject.SetActive (false);

		//I dont think this ended up being necessary
		//Collects all buttons in the scene into an array to be used
		//
		//buttons = this.GetComponentsInChildren<Button> (true);
	}

	//possibility for turning panels invis before game start
	//need to find a way to declare variables before this function runs in order to use it
	//will currently leave this on hold
	//
	//
	//void Awake()
	//{
		//_quitConfirm = GameObject.Find ("QuitConfirmPanel");
		//quitConfirm.SetActive (false);
	//}
	
	// Update is called once per frame
	void Update () 
	{
		//if left click
		if (Input.GetMouseButtonDown (0)) 
		{
			
			//MAIN BODY of the script for the menu
			//if over UI element
			//
			if (EventSystem.current.IsPointerOverGameObject ()) 
			{
				//would use with comment #1 on the bottom maybe
				//Button clicked = CheckButtonName (EventSystem.current.currentSelectedGameObject.name);

				// if - current object that has been clicked is not nothing (ensures an object that is passed)
				// this also avoids a nullpointererror that would occur when clicking anything else but the buttons
				//
				if (EventSystem.current.currentSelectedGameObject != null)
				{
					
					//BELOW is used to compare tags of buttons within the scene
					//adding buttons in the future simply means adding more conditionals
					//
					if (EventSystem.current.currentSelectedGameObject.name.CompareTo ("Start") == 0) 
					{
						//Debug.Log ("hhh");

						//If there were levels, this would take a level name then switch to that level
						//but currently this does nothing
						//
						Play ("1-1");
					} 
					else if (EventSystem.current.currentSelectedGameObject.name.CompareTo ("Options") == 0) 
					{
						Options ();
					} 

					//for the quit button which access the 'Quit' function
					//
					else if (EventSystem.current.currentSelectedGameObject.name.CompareTo ("Quit") == 0)
					{
						Quit ();
					} 
					//the 2 bellow control the yes or no option of the 
					//confirmation window from the 'Quit' button
					//
					else if (EventSystem.current.currentSelectedGameObject.name.CompareTo ("Quit_YesButton") == 0) 
					{
						//should quit the application
						//
						Application.Quit ();
					} 
					else if (EventSystem.current.currentSelectedGameObject.name.CompareTo ("Quit_NoButton") == 0) 
					{
						//returns to main menu, sets quit menu to invisible and main menu to visible again
						//
						quitConfirm.gameObject.SetActive (false);
						mainMenu.gameObject.SetActive (true);
					}
				}
			} 
		}
	}

	//what the play button does
	public void Play(string sceneName)
	{
		//click test
		//Debug.Log ("WHAM");
	}

	//what the options button does
	public void Options()
	{
		//log
		Debug.Log ("BAM!");
	}

	//what the quit button does
	public void Quit()
	{
		//Click test
		//Debug.Log ("whaZAM!");

		quitConfirm.gameObject.SetActive (true);
		mainMenu.gameObject.SetActive (false);

		//#2 note on the bottom
		//SceneManager.LoadScene ("QuitConfirmScreen");
	}

	/*
	 * 
	 * #1
	 * 
	 * had an idea that I would find the button from the array to use
	 * would search through string name
	 * 
	 * however, I realized that, currently, the buttons have no individual scripts
	 * to access
	 * 
	 * Will leave this here for future use possibly?
	 * 
	 * also, this is not tested
	 * so this is not a guarenteed answer if needed later
	 * 
	public Button CheckButtonName(string buttonName)
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			if (buttons [i].CompareTag (buttonName)) 
			{
				return buttons [i];
			}
		}

		return null;
	}
	*/

	/*   
	 * #2
	 * SceneManager is (from what I know) what is used to change scenes
	 * so, the buttons will change the scene based off which scene is saved into
	 * the scene resource folder and the name of said scene
	 *
	 * LoadScene(SceneName) is the function used to load in the scene
	*/

}
