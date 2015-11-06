using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
    public GameObject PauseScreen;
    public GameObject PauseButton;
    public Slider slider;
    public float maxSpeed = 60;

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
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
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
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
}
