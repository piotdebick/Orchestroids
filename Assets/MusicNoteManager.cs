using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicNoteManager : MonoBehaviour
{
    public char note;
    public char[] noteSequence;
    public Text noteSequenceText;
    GameObject noteShockWave;
    GameObject loadButton, projectileShooter;
    public GameObject earth;
    bool isLoaded;

    // Use this for initialization
    void Start()
    {
        noteSequence = new char[3];
        noteShockWave = Resources.Load("Shockwave") as GameObject;
        earth = GameObject.Find("Player Earth");
        loadButton = GameObject.Find("Load Button");
        projectileShooter = GameObject.Find("playerSatelite");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("space"))
        {
            earth.GetComponent<DestroyObject>().reload();
        }
        */
        //reset on space bar
        if (Input.GetKeyDown("space"))
        {
            earth.GetComponent<DestroyObject>().reload();
        }
        if (Input.GetKeyDown("tab") && loadButton.GetComponent<Button>().interactable && projectileShooter.GetComponent<ProjectileShooter>().isLoaded == false)
        {
            earth.transform.FindChild("sphere").GetComponentInChildren<ProjectileShooter>().load();
            loadButton.GetComponent<AudioSource>().Play();
        }


        if (Input.GetKeyDown("1") && note == 'C')
        {
            playAndInputNote();
        }
        else if (Input.GetKeyDown("2") && note == 'D')
        {
            playAndInputNote();
        }
        else if (Input.GetKeyDown("3") && note == 'E')
        {
            playAndInputNote();
        }         
        else if (Input.GetKeyDown("4") && note == 'F')
        {
            playAndInputNote();
        }          
        else if (Input.GetKeyDown("5") && note == 'G')
        {
            playAndInputNote();
        }         
        else if (Input.GetKeyDown("6") && note == 'A')
        {
            playAndInputNote();
        }          
        else if (Input.GetKeyDown("7") && note == 'B')
        {
            playAndInputNote();
        }            
        else if (Input.GetKeyDown("8") && note == 'c')
        {
            playAndInputNote();
        }
           
    }

    void instantiateShockWave()
    {
        GameObject Shockwave = Instantiate(noteShockWave, new Vector3(transform.position.x, transform.position.y + .3f, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        DestroyObject(Shockwave, 0.8f);
    }

    void OnMouseDown() // Insert anything to be done below (object must have a collider)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        instantiateShockWave();
        loadButton.GetComponent<Button>().interactable = true;

        if (earth.GetComponent<DestroyObject>().playerNoteSequenceString.Length < 3)
        {
            earth.GetComponent<DestroyObject>().playerNoteSequenceString += note;
            earth.GetComponent<DestroyObject>().currentPlayerNoteSequence += note;
        }
    }

    void playAndInputNote()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = 0.2f;

        audio.Play();
        instantiateShockWave();
        loadButton.GetComponent<Button>().interactable = true;

        if (earth.GetComponent<DestroyObject>().playerNoteSequenceString.Length < 3)
        {
            earth.GetComponent<DestroyObject>().playerNoteSequenceString += note;
            earth.GetComponent<DestroyObject>().currentPlayerNoteSequence += note;
        }

    }

    }