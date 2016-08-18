using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetLoadLetters : MonoBehaviour {
	public Text currentChoice;
	GameObject player, asteroid;
    public string playerNotes;



	// Use this for initialization
	void Start ()
    {
		currentChoice = gameObject.GetComponent<Text> ();
		player = GameObject.Find("Player Earth");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            playerNotes = player.GetComponent<DestroyObject>().playerNoteSequenceString;
            currentChoice.text = playerNotes;
        }
    }

}
