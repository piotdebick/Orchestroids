using UnityEngine;
using System.Collections;
public class GenerateSequence : MonoBehaviour
{
    GameObject asteroid;
    int randNum, counter;
    public char[] sequence;
    public string sequenceString;
    public int sizeOfAsteroid;
    // Use this for initialization
    void Start()
    {
        // sequenceString = " ";
        asteroid = GameObject.Find("Game Manager");
        sizeOfAsteroid = asteroid.GetComponent<asteroidManager>().sizeOfAsteroid;
        switch (sizeOfAsteroid)
        {
            case 1:
                sequence = new char[1];
                break;
            case 2:
                sequence = new char[2];
                break;
            case 3:
                sequence = new char[3];
                break;
        }
        counter = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            genSequence();
        }
    }
    // Update is called once per frame
    /*void Update()
    {
    }*/
    void genSequence()
    {
        randNum = Random.Range(1, 8);
        switch (randNum)
        {
            case 1: //C

                sequence[counter] = 'C';
                sequenceString += 'C';
                counter++;
                break;
            case 2://D
                sequence[counter] = 'D';
                sequenceString += 'D';
                counter++;
                break;
            case 3://E
                sequence[counter] = 'E';
                sequenceString += 'E';
                counter++;
                break;
            case 4://F
                sequence[counter] = 'F';
                sequenceString += 'F';
                counter++;
                break;
            case 5://G
                sequence[counter] = 'G';
                sequenceString += 'G';
                counter++;
                break;
            case 6://A
                sequence[counter] = 'A';
                sequenceString += 'A';
                counter++;
                break;
            case 7://B
                sequence[counter] = 'B';
                sequenceString += 'B';
                counter++;
                break;
            case 8://c
                sequence[counter] = 'c';
                sequenceString += 'c';
                counter++;
                break;
        }
    }
}