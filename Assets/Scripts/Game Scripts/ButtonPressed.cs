using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {
    TutorialSceneManager tutManager;
	// Use this for initialization
	void Start () {
        //tutManager = GameObject.GetComponent<TutorialSceneManager>();
	}
	
	// Update is called once per frame

    void OnMouseDown()
    {
        //tutManager.isNextButtonPressed = true;
    }
}
