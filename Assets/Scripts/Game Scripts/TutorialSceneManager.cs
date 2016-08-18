using UnityEngine;
using System.Collections;

public class TutorialSceneManager : MonoBehaviour
{
    GameObject mainCanvas;
    GameObject[] tutorialTip;
    GameObject tutorialResource;
    Color color, childColor, selectorColor;
    public int tutNum = 0;
    public bool isNextButtonPressed, fadeInFinished, fadeOutFinished;
    // Use this for initialization
    void Start()
    {
        
        mainCanvas = GameObject.Find("Main Canvas");
        fadeInFinished = false;
        fadeOutFinished = false;
        isNextButtonPressed = false;
        tutorialTip = new GameObject[5];
        tutorialResource = Resources.Load("Tutorial Gadget") as GameObject;
        for (int i = 0; i < 5; i++)
        {
            tutorialTip[i] = Instantiate(tutorialResource) as GameObject;
            tutorialTip[i].transform.parent = mainCanvas.transform;
            noShowOnStart(i);
        }
        setTutorials();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isNextButtonPressed)
        {
            fadeOut(tutNum);
            if (fadeOutFinished)
            {
                isNextButtonPressed = false;
                if(tutNum < 5)
                    tutNum++;
                fadeOutFinished = false;
            }
        }
        else
        {
            fadeIn(tutNum);

        }
    }

    public void checkForPressedButton()
    {
        isNextButtonPressed = true;
    }

    void setTutorials()
    {
        //bottom left for note playing instructions
        tutorialTip[0].transform.position = new Vector3(0f, 0f, 0f);
        tutorialTip[0].GetComponentInChildren<TextMesh>().text
            = "TO LISTEN TO A SOUND WITHOUT \n GENERATING INPUT, YOU CAN \n USE KEYBOARD  NUMBERS 1-8! \n OTHERWISE, LEFT CLICK TO \n SELECT YOUR LOADING \n SEQUENCE.";

        //bottom right for input/load/reset 
        tutorialTip[1].transform.position = new Vector3(25f, -13f, 0f);
        tutorialTip[1].GetComponentInChildren<TextMesh>().text
            = "THE BLUE BOX DISPLAYS YOUR \n CURRENT SEQUENCE. 'LOAD' \n LOADS THE SEQUENCE AND \n ACTIVATES THE CANON. 'RESET' \n RESETS THE CURRENT \n SEQUENCE.";

        //Next player Earth for canon instructions
        tutorialTip[2].transform.position = new Vector3(12.5f, -5.5f, 0f);
        tutorialTip[2].GetComponentInChildren<TextMesh>().text
            = "ONCE LOADED, YOU WILL BE \nABLE TO MOVE YOUR SATELITE \nAND SHOOT YOUR SEQUENCE \nCANON. MAKE SURE YOU ARE \nLOADING THE RIGHT SEQUENCE, \nOR EARTH WILL BE IN TROUBLE!";

        //Top Right for asteroids
        tutorialTip[3].transform.position = new Vector3(25f, 13f, 0);
        tutorialTip[3].GetComponentInChildren<TextMesh>().text
            = "CLICK ON AN ASTEROID TO SLOW \nDOWN TIME AND HEAR IT'S \nSEQUENCE. YOUR OBJECTIVE IS \nTO IDENTIFY THIS SEQUENCE AND \nPLAY IT BACK AT THE ASTEROID \nTO DESTROY IT!";

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
        //selectorColor = tutorialTip[num].GetComponent<Renderer>().material.color

        color.a -= 0.05f;
        childColor.a -= 0.05f;
        tutorialTip[num].GetComponent<Renderer>().material.color = color;
        tutorialTip[num].GetComponentInChildren<MeshRenderer>().material.color = childColor;
        if (color.a == 0)
            fadeOutFinished = true;

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
        else fadeInFinished = true;
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
