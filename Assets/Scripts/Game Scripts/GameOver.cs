using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    GameObject Earth;
    GameObject gameOverScreen;
    asteroidManager stopAsteroidManager;
    public bool IsEarthReal;
    public bool tipsOnReplay;
    // Use this for initialization
    void Start()
    {
        IsEarthReal = tipsOnReplay;
        Earth = GameObject.FindWithTag("Player");
        stopAsteroidManager = GameObject.Find("Game Manager").GetComponent<asteroidManager>();
        gameOverScreen = GameObject.Find("Game Over");
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Earth.Equals(null))
        {
            stopAsteroidManager.enabled = false;
            gameOverScreen.SetActive(true);
            tipsOnReplay = true;
            //tutManager.enabled = tipsOnReplay;
        }
    }

}
