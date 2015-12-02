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
        PlayerPrefs.SetFloat("enemyDmgMultiplier", 1);
        PlayerPrefs.SetInt("levelSize", 1);
        PlayerPrefs.SetFloat("hitPoints", 250);
        PlayerPrefs.SetFloat("maxHitPoints", 250);
        PlayerPrefs.Save();
        Application.LoadLevel("TestLevelGenerator");
    }

    public void goToContinue()
    {
        Application.LoadLevel("TestLevelGenerator");
    }

    public void quitToMenu()
    {
        PlayerPrefs.DeleteAll();
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
