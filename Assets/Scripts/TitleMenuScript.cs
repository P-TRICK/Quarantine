using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenuScript : MonoBehaviour {
    public Transform openpanel;
    public Button exitgame, returnb;
    // Use this for initialization
    public void Play(string Scene1) {
       // Application.LoadLevel(Scene1);
    }

    public void Options() {

    }

    public void Quit(bool clicked){ 
     if(clicked == true) {
         openpanel.gameObject.SetActive(clicked);
            exitgame.onClick.AddListener(() =>
            {
                Application.Quit();
            });
            returnb.onClick.AddListener(() =>
            {
                openpanel.gameObject.SetActive(false);
            });
        } 
    }
}
