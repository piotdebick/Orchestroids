using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    GameObject player, asteroid, asteroidClone, wrongEffect, rightEffect, playerSatelite, loadButton;
    public char[] playerNoteSequence;
    public char[] asteroidNoteSequence;
    public int correctCount, length;
    public string playerNoteSequenceString;
    public string asteroidNoteSequenceString;
    public string currentPlayerNoteSequence;
    public int asteroidSequenceLength;
    int score;

    // Use this for initialization
    void Start()
    {
        rightEffect = Resources.Load("RightEffect") as GameObject;
        wrongEffect = Resources.Load("WrongEffect") as GameObject;
        loadButton = GameObject.Find("Load Button");
        player = GameObject.Find("Player Earth");
        asteroidClone = GameObject.Find("Game Manager");
        playerSatelite = GameObject.Find("playerSatelite");
        length = asteroidClone.GetComponent<asteroidManager>().sizeOfAsteroid;
        playerNoteSequence = new char[length];
        asteroidNoteSequence = new char[length];
        correctCount = 0;
        asteroidSequenceLength = 1;
        if(gameObject.tag == "Asteroid")
            asteroid = gameObject;

    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Asteroid" && currentPlayerNoteSequence.Length <= 3 && player != null)
        {
            asteroidNoteSequenceString = asteroid.GetComponent<GenerateSequence>().sequenceString;
            asteroidSequenceLength = asteroidNoteSequenceString.Length;
            playerNoteSequenceString = player.GetComponent<DestroyObject>().playerNoteSequenceString;
            currentPlayerNoteSequence = player.GetComponent<DestroyObject>().currentPlayerNoteSequence;
        }

        if (gameObject.tag == "Asteroid" && gameObject.transform.position.y <= -13)
            gameObject.GetComponent<SphereCollider>().enabled = false;

    }
    void OnCollisionEnter(Collision col)
    {

        switch (col.gameObject.tag)
        {
            case "Asteroid":
                if (gameObject.tag != "Asteroid" && gameObject.tag != "Player")
                {
                    gameObject.GetComponent<Renderer>().enabled = false;
                    Destroy(gameObject);
                }
                else if (gameObject.tag == "Player")
                {
                    
                    AudioSource audio = GetComponent<AudioSource>();
                    audio.Play();
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponent<Detonator>().Explode();
                    Destroy(transform.FindChild("sphere").FindChild("playerSatelite").gameObject);
                }
                break;
            case "Projectile":

                if (currentPlayerNoteSequence == asteroidNoteSequenceString)
                {
                    //for main game
                    GameObject RightEffect = Instantiate(rightEffect) as GameObject;
                    RightEffect.transform.position = transform.position;
                    Destroy(RightEffect, 2);

                    AudioSource audio = GetComponent<AudioSource>();
                    gameObject.GetComponent<Renderer>().enabled = false;
                    gameObject.GetComponent<Detonator>().Explode();
                    audio.Play();
                    Destroy(gameObject, 4);
                    Destroy(transform.FindChild("Hint Text").gameObject);
                    gameObject.GetComponent<SphereCollider>().enabled = false;

                    // increment score when destroyed
                    if (GetComponent<GenerateSequence>().sizeOfAsteroid == 1)
                    {
                        score = 110 - GetComponent<OnMouseClick>().clickCount * 10;
                        asteroidClone.GetComponent<GameManager>().incrementScore(score);
                    }
                    else if (GetComponent<GenerateSequence>().sizeOfAsteroid == 2)
                    {
                        score = 550 - GetComponent<OnMouseClick>().clickCount * 50;
                        asteroidClone.GetComponent<GameManager>().incrementScore(score);
                    }
                    else if (GetComponent<GenerateSequence>().sizeOfAsteroid == 3)
                    {
                        score = 1100 - GetComponent<OnMouseClick>().clickCount * 100;
                        asteroidClone.GetComponent<GameManager>().incrementScore(score);
                    }


                }
                else if(SceneManager.GetActiveScene().name == "RealTutorialScene")
                {
                    GameObject WrongEffect = Instantiate(wrongEffect) as GameObject;
                    WrongEffect.transform.position = transform.position;
                    Destroy(WrongEffect, 2);
                    asteroidClone.GetComponent<GameManager>().divideScore();
                }
                else
                {
                    GameObject WrongEffect = Instantiate(wrongEffect) as GameObject;
                    WrongEffect.transform.position = transform.position;
                    Destroy(WrongEffect, 2);
                    asteroidClone.GetComponent<GameManager>().divideScore();
                    Destroy(gameObject, 5);
                    gameObject.GetComponent<SphereCollider>().enabled = false;
                }
                //for tutorial
                clearCurrentInput();
                break;
        }
        
    }

    public void reload()
    {
        playerNoteSequenceString = "";
        currentPlayerNoteSequence = "";
        playerSatelite.GetComponent<ProjectileShooter>().isLoaded = false;
        playerSatelite.GetComponent<ProjectileShooter>().disablePlayerMove();
        DestroyObject(GameObject.Find("Charge_01.3 Fairydust(Clone)"));
        loadButton.GetComponent<Button>().interactable = false;
    }

    public void clearCurrentInput()
    {
        player.GetComponent<DestroyObject>().currentPlayerNoteSequence = "";
    }

    public void clearInput()
    {
        playerNoteSequenceString = "";
    }




}