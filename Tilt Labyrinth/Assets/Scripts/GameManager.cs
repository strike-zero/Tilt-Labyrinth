using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    private float enemyCount;
    public GameObject gameOverObject;
    public GameObject victoryText;
    public GameObject victoryObject;
    private bool gameEnded;


	void Start () {
        //enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        gameEnded = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameEnded)
            Time.timeScale = Mathf.Lerp(1f, 0.25f, Time.deltaTime * 70);
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

    public void GameVictory()
    {
        gameEnded = true;
        //increment size
        int currentLevel = PlayerPrefs.GetInt("levelSize");
        currentLevel++;
        //increase dmg multiplier
        float enemyDmgMultiplier = PlayerPrefs.GetFloat("enemyDmgMultiplier");
        enemyDmgMultiplier += 0.25f;

        float maxHitPoints = PlayerPrefs.GetFloat("maxHitPoints");
        float extraHitPoints = maxHitPoints * 0.25f;
        maxHitPoints = maxHitPoints * 1.15f;
        float hitPoints = Mathf.Clamp(PlayerHealth.GetHitPoints() + extraHitPoints, 0, maxHitPoints);

        PlayerPrefs.SetFloat("hitPoints", hitPoints);
        PlayerPrefs.SetInt("levelSize", currentLevel);
        PlayerPrefs.SetFloat("enemyDmgMultiplier", enemyDmgMultiplier);
        PlayerPrefs.Save();

        string message = "YOUR TIME IS " + FormatTime(Time.timeSinceLevelLoad);
        victoryText.GetComponent<Text>().text = message;
        victoryObject.SetActive(true);
    }

    public void GameOver()
    {
        gameEnded = true;
        gameOverObject.SetActive(true);
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
