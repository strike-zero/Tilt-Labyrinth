using UnityEngine;
using System.Collections;

public class ContinueScript : MonoBehaviour {
    public GameObject continueButton;

	void Start () {
        if (PlayerPrefs.HasKey("levelSize"))
            continueButton.SetActive(true);

        }
}
