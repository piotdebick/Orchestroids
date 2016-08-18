using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultySelection : MonoBehaviour
{

    static bool isClicked;
    static string selection;
    GameObject easyButton, mediumButton, hardButton;
    // Use this for initialization
    void Start()
    {   
        easyButton = GameObject.Find("Easy Button");
        mediumButton = GameObject.Find("Medium Button");
        hardButton = GameObject.Find("Hard Button");
        if (isClicked && gameObject.name == "Disable Hints Button")
        {
            GetComponentInChildren<Text>().text = "ASTEROID HINTS: <color=red>OFF</color>";
        }
        if(selection == "easy" && gameObject.name == "Easy Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>EASY</color>";
            mediumButton.GetComponentInChildren<Text>().text = "<color=white>MEDIUM</color>";
            hardButton.GetComponentInChildren<Text>().text = "<color=white>HARD</color>";
        }
        if (selection == "medium" && gameObject.name == "Medium Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>MEDIUM</color>";
            easyButton.GetComponentInChildren<Text>().text = "<color=white>EASY</color>";
            hardButton.GetComponentInChildren<Text>().text = "<color=white>HARD</color>";
        }
        if (selection == "hard" && gameObject.name == "Hard Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>HARD</color>";
            mediumButton.GetComponentInChildren<Text>().text = "<color=white>MEDIUM</color>";
            easyButton.GetComponentInChildren<Text>().text = "<color=white>EASY</color>";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (gameObject.name == "Easy Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>EASY</color>";
            mediumButton.GetComponentInChildren<Text>().text = "<color=white>MEDIUM</color>";
            hardButton.GetComponentInChildren<Text>().text = "<color=white>HARD</color>";
            selection = "easy";
        }

        if (gameObject.name == "Medium Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>MEDIUM</color>";
            easyButton.GetComponentInChildren<Text>().text = "<color=white>EASY</color>";
            hardButton.GetComponentInChildren<Text>().text = "<color=white>HARD</color>";
            selection = "medium";
        }

        if (gameObject.name == "Hard Button")
        {
            GetComponentInChildren<Text>().text = "<color=red>HARD</color>";
            mediumButton.GetComponentInChildren<Text>().text = "<color=white>MEDIUM</color>";
            easyButton.GetComponentInChildren<Text>().text = "<color=white>EASY</color>";
            selection = "hard";
        }
        if (gameObject.name == "Disable Hints Button")
        {
            if (isClicked)
            {
                GetComponentInChildren<Text>().text = "ASTEROID HINTS: <color=white>ON</color>";
                isClicked = false;
            }
            else
            {
                GetComponentInChildren<Text>().text = "ASTEROID HINTS: <color=red>OFF</color>";
                isClicked = true;
            }
        }
    }
}
