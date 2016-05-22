using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {


    // THIS IS NO LONGER A TUTORIAL.. THIS IS THE TIP MANAGER FOR THE TIPS THAT POP UP DURING THE GAME
    GameObject[] tutorialTip;
    GameObject tutorialResource;
    float asteroidTutTime, playerEarthTutTime, clickNoteSeqTime, pressNoteSeqTime;
    Color color, childColor;
    static bool replayGame;
    TutorialManager tipManager;
    // Use this for initialization
    void Start () {
        tipManager = gameObject.GetComponent<TutorialManager>();
        tipManager.enabled = !replayGame;
        tutorialTip = new GameObject[4];
        tutorialResource = Resources.Load("Tutorial Tip") as GameObject;
        for (int i = 0;i < 4; i++)
        {
            tutorialTip[i] = Instantiate(tutorialResource) as GameObject;
            noShowOnStart(i);
        }
        setTutorials();

	}
	
	// Update is called once per frame
	void Update () {


        asteroidTutTime += Time.deltaTime;
        playerEarthTutTime += Time.deltaTime;
        clickNoteSeqTime += Time.deltaTime;
        pressNoteSeqTime += Time.deltaTime;
        //bottom left
        if(asteroidTutTime >= 29 && asteroidTutTime < 68)
        {
            replayGame = true;
            fadeIn(0);
        }
        else if(asteroidTutTime >= 68)
        {
            fadeAndDestroy(0);
        }
        //bottom right
        if (playerEarthTutTime >= 20 && playerEarthTutTime < 59)
        {
            fadeIn(1);
        }
        else if (playerEarthTutTime >= 59)
        {
            fadeOut(1);
        }
        //player earth
        if (clickNoteSeqTime >= 11 && clickNoteSeqTime < 50)
        {
            fadeIn(2);
        }
        else if (clickNoteSeqTime >= 50)
        {
            fadeOut(2);
        }
        //top right
        if (pressNoteSeqTime >= 2 && pressNoteSeqTime < 41)
        {
            fadeIn(3);
        }
        else if (pressNoteSeqTime >= 41)
        {
            fadeOut(3);   
        }



    }

    void setTutorials()
    {
        //bottom left for note playing instructions
        tutorialTip[0].transform.position = new Vector3(-23f, -13.5f, 0f);
        tutorialTip[0].GetComponentInChildren<TextMesh>().text 
            = "				<color=yellow>TIP</color> \nIF YOU SHOOT AN \nINCORRECT SEQUENCE AT \nAN ASTEROID, YOU WILL \nLOSE HALF YOUR <color=yellow>SCORE</color>";
        
        //bottom right for input/load/reset 
        tutorialTip[1].transform.position = new Vector3(23f, -13.5f, 0f);
        tutorialTip[1].GetComponentInChildren<TextMesh>().text
            = "				<color=yellow>TIP</color> \nYOU CAN USE <color=yellow>'TAB'</color> TO \n<color=red>LOAD</color> YOUR SELECTION AND  \n<color=yellow>'SPACE BAR'</color> TO <color=red>RESET</color> \nAND CHOOSE AGAIN.";

        //Next player Earth for canon instructions
        tutorialTip[2].transform.position = new Vector3(12f, -6.5f, 0f);
        tutorialTip[2].GetComponentInChildren<TextMesh>().text 
             = "			    <color=yellow>TIP</color> \nYOU WILL BE ABLE TO AIM \nAND SHOOT THE CANON \nONCE YOU <color=red>LOAD</color> A \nSEQUENCE INTO THE CANON";

        //Top Right for asteroids
        tutorialTip[3].transform.position = new Vector3(23f, 13.5f, 0);
        tutorialTip[3].GetComponentInChildren<TextMesh>().text 
            = "				<color=yellow>TIP</color> \nYOU CAN CLICK ON AN \nON AN ASTEROID MULTIPLE \nTIMES IN ORDER TO HEAR \nITS SEQUENCE AGAIN";

    }


    void noShowOnStart(int num)
    {
        color = tutorialTip[num].GetComponent<Renderer>().material.color;
        childColor = tutorialTip[num].GetComponentInChildren<Renderer>().material.color;
        color.a = 0f;
        childColor.a = 0f;
        tutorialTip[num].GetComponent<Renderer>().material.color = color;
        tutorialTip[num].GetComponentInChildren<MeshRenderer>().material.color = childColor;
    }

    void fadeOut(int num)
    {
        color = tutorialTip[num].GetComponent<Renderer>().material.color;
        childColor = tutorialTip[num].GetComponentInChildren<Renderer>().material.color;
        color.a -= 0.05f;
        childColor.a -= 0.05f;
        tutorialTip[num].GetComponent<Renderer>().material.color = color;
        tutorialTip[num].GetComponentInChildren<MeshRenderer>().material.color = childColor;
    }

    void fadeIn(int num)
    {
        color = tutorialTip[num].GetComponent<Renderer>().material.color;
        childColor = tutorialTip[num].GetComponentInChildren<Renderer>().material.color;
        if (color.a < 1f)
        {
            color.a += 0.05f;
            childColor.a += 0.05f;
        }
        tutorialTip[num].GetComponent<Renderer>().material.color = color;
        tutorialTip[num].GetComponentInChildren<MeshRenderer>().material.color = childColor;
    }


    void fadeAndDestroy(int num)
    {
        fadeOut(num);
        if (tutorialTip[num].GetComponent<Renderer>().material.color.a <= 0f)
            gameObject.GetComponent<TutorialManager>().enabled = false;
    }
}
