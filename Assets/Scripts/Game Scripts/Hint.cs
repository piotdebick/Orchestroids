using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Hint : MonoBehaviour
{
    GameObject asteroid;
    GameObject earth;
    public string noteSequenceString;
    public Vector3 diffPosition;
    public Vector3 showHelp;
    bool done, isClicked;
    static bool hintsDisabled;
    int length;
    // Use this for initialization
    void Start()
    {
        if (hintsDisabled)
        {
            gameObject.GetComponent<Hint>().enabled = false;
        }
        asteroid = transform.parent.gameObject;
        length = asteroid.GetComponent<GenerateSequence>().sizeOfAsteroid;
        earth = GameObject.Find("Player Earth");
        diffPosition = new Vector3(0f, 0f, 0f);
        showHelp = new Vector3(20f, -10f, 20f);
        done = false;
    }
    // Update is called once per frame
    void Update()
    {
        isClicked = asteroid.GetComponent<OnMouseClick>().isClicked;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (earth != null)
        {
            diffPosition = earth.transform.position - asteroid.transform.position;
        }
        if (diffPosition.y > showHelp.y && !done && isClicked)
        {
            for (int i = 0; i < length; i++)
            {
                noteSequenceString += asteroid.GetComponent<GenerateSequence>().sequence[i];
            }
            GetComponent<TextMesh>().text = noteSequenceString;
            done = true;
        }
    }

    public void disableHints()
    {
        if (hintsDisabled)
            hintsDisabled = false;
        else hintsDisabled = true;
    }
}