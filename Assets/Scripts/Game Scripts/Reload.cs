using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

    public GameObject earth;


    // Use this for initialization
    void Start ()
    {
        earth = GameObject.Find("Player Earth");
    }
	
	// Update is called once per frame
	void Update ()
    {
	 
	}

    void OnMouseDown()
    {
        earth.GetComponent<DestroyObject>().playerNoteSequenceString = "";
    }
}
