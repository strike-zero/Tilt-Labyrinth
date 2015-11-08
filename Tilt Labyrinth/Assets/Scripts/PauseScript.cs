using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public GameObject AmmoUI;
    public Slider slider;
    public float maxSpeed = 60;

    public void ResumeGame()
    {
        GamePaused(false);
        SetSensitivity();
        ReorientDevice();
        Time.timeScale = 1;
    }

    public void goToMenu()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePaused(true);
    }

    void SetSensitivity()
    {
        AccelerometerTest.speed = maxSpeed * slider.value;
    }

    void ReorientDevice()
    {
        AccelerometerTest.initTilt = Vector3.zero;
        AccelerometerTest.initTilt.y = Input.acceleration.y;
        AccelerometerTest.initTilt.x = Input.acceleration.x;
    }

    void GamePaused(bool active)
    {
        PauseScreen.SetActive(active);
        PauseButton.SetActive(!active);
        AmmoUI.SetActive(!active);
    }
}
