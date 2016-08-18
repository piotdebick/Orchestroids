using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class asteroidManager : MonoBehaviour
{
    
    GameObject MainAsteroid;
    static int difficulty = 1;
    public float respawnTimer;
    public float delayTimer;
    public float gameTime = 0;
    public int asteroidPick, asteroidRange;
    public float asteroidSpeed, difficultySpeed;
    public bool assignedRange1 = false, assignedRange2 = false;
    public int sizeOfAsteroid, score;
    Vector3 earthPosition;
    // Use this for initialization
    void Start()
    {
        score = 0;
        MainAsteroid = Resources.Load("Main Asteroid") as GameObject;
        asteroidRange = 2;
        delayTimer = 15f;
        earthPosition = new Vector3(0, -21, 0);

        switch (difficulty)
        {
            case 1:
                delayTimer = 15f;
                difficultySpeed = 1f;
                break;
            case 2:
                delayTimer = 10f;
                difficultySpeed = 1.25f;
                break;
            case 3:
                delayTimer = 8f;
                difficultySpeed = 1.5f;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "RealTutorialScene")
            delayTimer = 0;

        score = GetComponent<GameManager>().score;

        respawnTimer += Time.deltaTime;
        gameTime += Time.deltaTime;
        if (respawnTimer >= delayTimer)
        {
            if (SceneManager.GetActiveScene().name == "RealTutorialScene")
                asteroidPick = 4;
			else asteroidPick = Random.Range(1, asteroidRange); // change 4 to asteroid range

            switch (asteroidPick)
            {
                case 1:
                    makeAsteroid(MainAsteroid, "small");
                    break;
                case 2:
                    makeAsteroid(MainAsteroid, "medium");
                    break;
                case 3: //doesn't get called until asteroidRange gets updated
                    makeAsteroid(MainAsteroid, "large");
                    break;
                case 4:
                    makeAsteroid(MainAsteroid, "tutorial");
                    break;
            }
            
            respawnTimer = 0f;


            if (score >= 100 && !assignedRange1)
            {
                asteroidRange = 3;
                assignedRange1 = true;
            }
            if (score >= 500 && !assignedRange2)
            {
                asteroidRange = 4;
                assignedRange2 = true;
            }
        }
    }
    void makeAsteroid(GameObject asteroid, string type)
    {
        GameObject newAsteroid = Instantiate(asteroid) as GameObject;
        newAsteroid.transform.position = new Vector3(Random.Range(-25.0F, 25.0F), 20, 0);
        Rigidbody rigidBody = newAsteroid.GetComponent<Rigidbody>();
        
        switch (type)
        {
            case "small": //small asteroid
                sizeOfAsteroid = 1;
                asteroidSpeed = -2f * difficultySpeed;
                newAsteroid.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                break;
            case "medium": // medium asteroid
                sizeOfAsteroid = 2;
                asteroidSpeed = -1.50f * difficultySpeed;
                newAsteroid.transform.localScale = new Vector3(2.25f, 2.25f, 2.25f);
                break;
            case "large": //large asteroid
                sizeOfAsteroid = 3;
                asteroidSpeed = -1.1f * difficultySpeed;
                newAsteroid.transform.localScale = new Vector3(3.25f, 3.25f, 3.25f);
                break;
            case "tutorial": //tutorial asteroid
                sizeOfAsteroid = 1;
                asteroidSpeed = 0f;
                newAsteroid.transform.position = new Vector3(-0.03f, 10f, 0f);
                newAsteroid.transform.localScale = new Vector3(2.25f, 2.25f, 2.25f);
                rigidBody.isKinematic = true;
                GetComponent<asteroidManager>().enabled = false;
                break;
        }

        rigidBody.AddForce(Vector3.MoveTowards(newAsteroid.transform.position, earthPosition, 1f) * asteroidSpeed);
    }

    public void setDifficulty(int num) //sets difficulty through options
    {
        difficulty = num;
    }
}