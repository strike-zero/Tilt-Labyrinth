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
        Application.LoadLevel("TestLevelGenerator");
    }

    public void exitGame()
    {
        Application.Quit();
    }
    
}
