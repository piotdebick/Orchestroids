using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    GameObject  tutorialAsteroid;
    GameObject selection, tutorial, tutorialOver;
    GameObject gameManager;
    public bool buttonPressed, fadeOutFinished, fadeInFinished;
    int step;
    Color selectionColor, tutorialColor, textColor;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Game Manager");
        tutorialOver = GameObject.Find("Tutorial Over");
        selection = transform.GetChild(0).gameObject;
        tutorial = transform.GetChild(1).gameObject;
        buttonPressed = false;
        fadeOutFinished = false;
        fadeInFinished = false;
        positionAndContent(0);
        tutorialOver.SetActive(false);
        gameManager.GetComponent<asteroidManager>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (buttonPressed)
        {
            fadeOut();
            if (fadeOutFinished)
            {
                buttonPressed = false;
                fadeOutFinished = false;
                step++;
                positionAndContent(step);
            }
        }
        else
        {
            if(step < 5)
                fadeIn();
            if (fadeInFinished)
            {
                fadeInFinished = false;
            }
        }

        if(tutorialAsteroid == null && step > 4)
            tutorialOver.SetActive(true);
    }

    public void isButtonPressed()
    {
        buttonPressed = true;
    }


    void fadeOut() // fades out the UI when called
    {   
        //Canvas group is to make the button transition
        GetComponent<CanvasGroup>().alpha -= 0.05f;

        //yellow canvas thingy transition
        selectionColor = selection.GetComponent<Renderer>().material.color;
        selectionColor.a -= 0.05f;
        selection.GetComponent<Renderer>().material.color = selectionColor;
        //blue canvas thingy transition
        tutorialColor = tutorial.GetComponent<Renderer>().material.color;
        tutorialColor.a -= 0.05f;
        tutorial.GetComponent<Renderer>().material.color = tutorialColor;

        //for the text transition
        textColor = tutorial.GetComponentInChildren<MeshRenderer>().material.color;
        textColor.a -= 0.05f;
        tutorial.GetComponentInChildren<MeshRenderer>().material.color = textColor;

        if (GetComponent<CanvasGroup>().alpha <= 0)
            fadeOutFinished = true;

    }

    void fadeIn() // fades in the UI when called
    {
        // i know there is a better way of making this work, but im already in too deep and there isn't enough time to redo everything

        if (GetComponent<CanvasGroup>().alpha < 1f)
        {
            //button color transition
            GetComponent<CanvasGroup>().alpha += 0.05f;

            //yellow canvas thingy transition
            selectionColor = selection.GetComponent<Renderer>().material.color;
            selectionColor.a += 0.05f;
            selection.GetComponent<Renderer>().material.color = selectionColor;
            //blue canvas thingy transition
            tutorialColor = tutorial.GetComponent<Renderer>().material.color;
            tutorialColor.a += 0.05f;
            tutorial.GetComponent<Renderer>().material.color = tutorialColor;

            //for the text transition
            textColor = tutorial.GetComponentInChildren<MeshRenderer>().material.color;
            textColor.a += 0.05f;
            tutorial.GetComponentInChildren<MeshRenderer>().material.color = textColor;
        }
    }

    void positionAndContent(int step) //positions next tutorial step
    {
        switch (step)
        {
            case 0: //earth
                gameObject.transform.position = new Vector3(0f, 0f, 0f);
                gameObject.GetComponentInChildren<TextMesh>().text
                    = "ASTEROIDS ARE HEADING TOWARDS EARTH! \nYOUR OBJECTIVE IS TO PROTECT EARTH \nFROM HARM USING OUR <color=red>FREQUENCY CANON</color>, \nWHICH ALLOWS US TO DESTROY ASTEROIDS \nWITH THE POWER OF SOUND!";
                selection.transform.localPosition = new Vector3(.01f, -.5f, 0f);
                selection.transform.localScale = new Vector3(1f, .6f, 1f);

                break;
            case 1: //keys
                gameObject.transform.position = new Vector3(-13f, -4.5f, 0f);
                gameObject.GetComponentInChildren<TextMesh>().text
                    = "KEYBOARD <color=yellow>KEYS 1 - 8</color> WILL ALLOW YOU TO \nPLAY THE NOTES, AS WELL AS READY THEM \nAS A SEQUENCE FOR LOADING. ONLY THE \n<color=yellow>FIRST THREE NOTES</color> YOU PLAY WILL BE \nCHOSEN AS THE SEQUENCE.  ";
                selection.transform.localPosition = new Vector3(1.4f, -0.62f, 0f);
                selection.transform.localScale = new Vector3(1.6f, .75f, 1f);
                break;
            case 2: //load/reload/sequence
                gameObject.transform.position = new Vector3(13f, -4.5f, 0f);
                gameObject.GetComponentInChildren<TextMesh>().text
                    = "THE <color=red>BLUE PANEL</color> SHOWS THE SEQUENCE \nTHAT IS CURRENTLY WAITING TO BE LOADED \nINTO THE CANON. IF YOU'RE SATISFIED WITH \nYOUR SEQUENCE, YOU CAN <color=yellow>LOAD</color> IT INTO THE \nCANON, OR YOU CAN SIMPLY <color=yellow>RESET</color> IT.";
                selection.transform.localPosition = new Vector3(0f, -0.6f, 0f);
                selection.transform.localScale = new Vector3(0.6f, 0.75f, 1f);
                break;
            case 3: //Score
                gameObject.transform.position = new Vector3(-22.5f, 10f, 0f);
                gameObject.GetComponentInChildren<TextMesh>().text
                    = "THIS IS WHERE YOUR CURRENT <color=red>SCORE</color>, AND \nYOUR <color=red>HIGH SCORE</color> WILL BE DISPLAYED. THE \nLARGER THE ASTEROID, THE MORE POINTS IT \nGIVES WHEN DESTROYED. YOUR POINTS WILL \nBE HALVED IF YOU GET A SEQUENCE WRONG.";
                selection.transform.localPosition = new Vector3(-0.22f, 0.425f, 0f);
                selection.transform.localScale = new Vector3(0.8f, 0.3f, 1f);
                break;
            case 4:
                //ASTEROID
                gameManager.GetComponent<asteroidManager>().enabled = true;
                gameObject.transform.position = new Vector3(0f, 1f, 0f);
                gameObject.GetComponentInChildren<TextMesh>().text
                    = "USE <color=yellow>LEFT MOUSE BUTTON</color> ON AN ASTEROID \nTO LISTEN TO ITS SEQUENCE. THIS SEQUENCE \nWILL BE WHAT DESTROYS THE ASTEROID. \n<color=yellow>LOAD</color> IT INTO YOUR CANON, <color=red>AIM</color>, THEN <color=red>FIRE</color> \nUSING <color=yellow>LEFT MOUSE BUTTON</color>.";
                selection.transform.localPosition = new Vector3(0f, 0.65f, 0f);
                selection.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 5:
                tutorialAsteroid = GameObject.FindGameObjectWithTag("Asteroid");
                break;
        }
    }

}
