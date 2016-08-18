using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 
    public int highScore;
    string highScoreKey = "highScore";
    public int score;
    public Text scoreText;
    public Text highScoreText;

    
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        if (SceneManager.GetActiveScene().name == "fruitSnacks" || SceneManager.GetActiveScene().name == "RealTutorialScene")
        {
            scoreText.text = ("Score: " + score.ToString());
			if (SceneManager.GetActiveScene ().name == "fruitSnacks") {
				highScoreText.text = ("High Score: " + highScore.ToString ());
			}
        }
    }

    IEnumerator FadeToNextLevel(string sceneName)
    {
        float fadetime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadetime * 6);
        SceneManager.LoadScene(sceneName);
    }

    public void loadGameScene(string sceneName)
    {
        Time.timeScale = 1f;
        StartCoroutine(FadeToNextLevel(sceneName));
    }

    public void enableSkybox()
    {
        GameObject skybox = GameObject.FindGameObjectWithTag("GameController");
        skybox.GetComponent<SkyboxRotate>().enableSkybox();
    }

    public void incrementScore(int scoreAmmount)
    {
        score += scoreAmmount;
        if(score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void divideScore()
    {
        score = score / 2;
        scoreText.text = "Score: " + score.ToString();
    }
    
}
