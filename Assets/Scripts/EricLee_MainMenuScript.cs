using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EricLee_MainMenuScript : MonoBehaviour {

	//Simplification of code from help of Ken

	//Will hold the mainMenuPanel and quitConfirmPanel
	//will be used to set visibility
	public GameObject mainMenuPanel;
	public GameObject quitConfirmPanel;

	/* Start and Update are currently uneeded for this script
	 * 
	 * 
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	*/

	//Start Button - will go to a level based on name
	public void Play(string levelName)
	{
		Debug.Log (levelName);
	}

	//Options Button - will go to options menu when it exists
	public void Options()
	{
		Debug.Log ("BAM");
	}

	//Quit Function  *start*  calls quit confirm panel
	public void Quit()
	{
		mainMenuPanel.SetActive (false);
		quitConfirmPanel.SetActive (true);
	}

		//Quit Confirm      exits application
	public void QuitConfirm()
	{
		Application.Quit ();
	}

		//Quit Decline      returns to main menu
	public void QuitCancel()
	{
		mainMenuPanel.SetActive (true);
		quitConfirmPanel.SetActive (false);
	}

	//Quit Function *end*
}
