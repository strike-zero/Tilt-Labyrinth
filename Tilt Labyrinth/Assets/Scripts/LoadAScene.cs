using UnityEngine;
using System.Collections;

public class LoadAScene : MonoBehaviour {
    public void goToTutorial()
    {
        Application.LoadLevel("Tutorial");
    }

    public void goToMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void goToAbout()
    {
        Application.LoadLevel("About");
    }

    public void goToPlay()
    {
        Application.LoadLevel("Playmode");
    }

    public void goToTestLevel()
    {
        PlayerPrefs.SetInt("levelNum", 1);
        PlayerPrefs.SetFloat("hitPoints", 250);
        PlayerPrefs.SetFloat("maxHitPoints", 250);
        PlayerPrefs.SetFloat("playerScore",0);
        PlayerPrefs.Save();
        Application.LoadLevel("TestLevelGenerator");
    }

    public void goToContinue()
    {
        Application.LoadLevel("TestLevelGenerator");
    }

    public void quitToMenu()
    {
        PlayerPrefs.DeleteKey("levelNum");
        Application.LoadLevel("Menu");
    }

    public void nextLevel()
    {
        Application.LoadLevel("TestLevelGenerator");
    }

    public void exitGame()
    {
        Application.Quit();
    }
    
}
