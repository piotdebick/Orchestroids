using UnityEngine;
using System.Collections;
public class OnMouseClick : MonoBehaviour
{
    public AudioSource[] AudioClips = null;
    GameObject asteroidParticle, asteroidClone; //astertoidClone gets asteroidManager info
    int randNum, length;
    public int audiovalue, counter, sizeOfAsteroid, clickCount;
    public char[] noteSequence;
    public bool resetPlay = false, sequenceFinishedPlaying = false;
    public bool isClicked = false;
    public float playTimer, time;
    char note;

    void Start()
    {
        clickCount = 0;
        asteroidParticle = Resources.Load("AsteroidEffect") as GameObject;
        asteroidClone = GameObject.Find("Game Manager");
        length = asteroidClone.GetComponent<asteroidManager>().sizeOfAsteroid;
        noteSequence = new char[length];
        counter = 0;
        time = 0f;
        sizeOfAsteroid = GetComponent<GenerateSequence>().sizeOfAsteroid;
        switch (sizeOfAsteroid)
        {
            case 1:
                playTimer = 1f;
                break;
            case 2:
                playTimer = 2f;
                break;
            case 3:
                playTimer = 2f;
                break;
        }
    }
    void Update()
    {
        if (sequenceFinishedPlaying)  
            time += Time.fixedDeltaTime;

        if (time >= 1f * length)
        {
            //Time.timeScale = 1f;
            sequenceFinishedPlaying = false;
            time = 0;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
    }
    void OnMouseDown() // Insert anything to be done below (object must have a collider)
    {
        if(clickCount < 10)
            clickCount++;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        isClicked = true;
        if (!resetPlay && !sequenceFinishedPlaying)
        {
            sequenceFinishedPlaying = true;
            //Time.timeScale = .25f;
            //get generated sequence
            for (int i = 0; i < length; i++)
            {
                noteSequence[i] = GetComponent<GenerateSequence>().sequence[i];
            }
            //play generated sequence at a note/1.5s
            for (int i = 0; i < length; i++)
            {
                resetPlay = true;
                Invoke("playSound", i);
                if (i == length - 1)
                {
                    resetPlay = false;
                    counter = 0;
                }
            }
        }

    }
    void playSound()
    {
        GameObject particleObject = Instantiate(asteroidParticle) as GameObject;
        particleObject.transform.position = transform.position;
        Destroy(particleObject, 1);

        note = noteSequence[counter];
        switch (note)
        {
            case 'C'://C
                playSeq(0);
                break;
            case 'D'://D
                playSeq(1);
                break;
            case 'E'://E
                playSeq(2);
                break;
            case 'F'://F
                playSeq(3);
                break;
            case 'G'://G
                playSeq(4);
                break;
            case 'A'://A
                playSeq(5);
                break;
            case 'B'://B
                playSeq(6);
                break;
            case 'c'://C(Hi)
                playSeq(7);
                break;
        }
    }
    void playSeq(int seq)
    {
        AudioClips[seq].Play();
        counter++;
    }
}