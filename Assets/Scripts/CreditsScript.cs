using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Author: Ruben Sanchez
 * Loads specified scene when user presses escape or space key, clicks on 'back' UI button, or credits have finished rolling 
 */

public class CreditsScript : MonoBehaviour
{
    //panel holding all text for credit scene
    private GameObject _panel;
    //RectTransform of panel used to get its lower bound 
    private RectTransform _panelRect;
    //UI Canvas 
    private Canvas _canvas;
    //RectTransform of Canvas used to get its upper bound
    private RectTransform _canvasRect;

	// Use this for initialization
	void Start ()
    {
        _panel = GameObject.Find("Panel");
        _panelRect = _panel.GetComponent<RectTransform>();
        _canvas = FindObjectOfType<Canvas>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //move panel up to roll credits;
        _panel.transform.Translate(Vector3.up * 0.5f);

        //load next scene if user pressed esc or space
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }         
        
        /* Regardless of length, after the lower bound of the panel has gone above the upper bound of the canvas, all credits have rolled, load the next scene
         * Lower bound of panel found by getting its center y value and subtracting half its height
         * Upper bound of canvas found by getting its center y value and adding half its height
         */
        if((_panel.transform.position.y - (0.5f * _panelRect.rect.height)) > (_canvas.transform.position.y + (0.5f * _canvasRect.rect.height)))
        {
            LoadNextScene();
        }        
                              
	}

    //Loads next scene, UI back button set this method
    public void LoadNextScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

}
