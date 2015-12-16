using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    private float enemyCount;
    public GameObject gameOverObject;
    public GameObject victoryText;
    public GameObject victoryObject;
    public Text scoreText;
    public Slider multiplierSlider;
    private bool gameEnded;
    private float playerScore;
    public static int scoreMultiplier;
    private float timer;
    public Text multiplierText;
    public Text levelText;
    public Text endScore;


	void Start () {
        gameEnded = false;
        scoreMultiplier = 1;
        timer = 5;
        int level = PlayerPrefs.GetInt("levelNum");
        playerScore = PlayerPrefs.GetFloat("playerScore");
        levelText.text = "LEVEL " + level;
        scoreText.text = playerScore.ToString("00000000");
	}
	
	void FixedUpdate () {
	    if (gameEnded)
            Time.timeScale = Mathf.Lerp(1f, 0.25f, Time.deltaTime * 70);

        if (scoreMultiplier > 1)
            MultiplierTimer();
	}

    public void EnemyDown()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("enemy left = " + enemyCount);
        if (enemyCount <= 3)
        {
            GameVictory();
        }
    }

    public void MultiplierTimer() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            scoreMultiplier = 1;
            timer = 5;
            multiplierText.text = "X" + scoreMultiplier;
        }
        multiplierSlider.value = timer;
    }

    public void Score(float score) {
        playerScore = playerScore + (score * scoreMultiplier);
        timer = 5;
        scoreMultiplier = Mathf.Clamp(++scoreMultiplier,1,10);
        multiplierText.text = "X" + scoreMultiplier;
        scoreText.text = playerScore.ToString("00000000");
    }

    public static int GetMultiplier() {
        return scoreMultiplier;
    }

    public void GameVictory()
    {
        gameEnded = true;
        //increment size
        int currentLevel = PlayerPrefs.GetInt("levelNum");
        currentLevel++;
        float maxHitPoints = PlayerPrefs.GetFloat("maxHitPoints");
        float extraHitPoints = maxHitPoints * 0.25f;
        maxHitPoints = maxHitPoints * 1.15f;
        float hitPoints = Mathf.Clamp(PlayerHealth.GetHitPoints() + extraHitPoints, 0, maxHitPoints);

        PlayerPrefs.SetFloat("hitPoints", hitPoints);
        PlayerPrefs.SetFloat("maxHitPoints", maxHitPoints);
        PlayerPrefs.SetInt("levelNum", currentLevel);
        PlayerPrefs.SetFloat("playerScore", playerScore);
        PlayerPrefs.Save();

        string message = "YOUR TIME IS " + FormatTime(Time.timeSinceLevelLoad);
        victoryText.GetComponent<Text>().text = message;
        victoryObject.SetActive(true);
    }

    public void GameOver()
    {
        gameEnded = true;
        gameOverObject.SetActive(true);

        if (PlayerPrefs.HasKey("highScore")){
            float highScore = PlayerPrefs.GetFloat("highScore");
            if (playerScore > highScore) {
                PlayerPrefs.SetFloat("highScore", playerScore);
                PlayerPrefs.Save();
                endScore.text = "NEW HIGH SCORE: " + playerScore.ToString("00000000");
            } else {
                endScore.text = "YOUR SCORE IS: " + playerScore.ToString("00000000");
            }
        } else {
            PlayerPrefs.SetFloat("highScore", playerScore);
            PlayerPrefs.Save();
            endScore.text = "NEW HIGH SCORE: " + playerScore.ToString("00000000");
        }

    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 10;
        fraction = fraction % 10;

        string timeText = minutes.ToString("00") + ":";
        timeText += seconds.ToString("00");
        timeText += "." + fraction.ToString("0");
        return timeText;
    }
}
