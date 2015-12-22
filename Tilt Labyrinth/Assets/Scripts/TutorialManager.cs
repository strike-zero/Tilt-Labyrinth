using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	public int markers = 7;
	public Text instructions;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Waypoints() {
		if (markers == 7) {
			instructions.text = "REACH ALL WAYPOINTS";
		} else if (markers <= 1) {
			Application.LoadLevel("Tutorial2");
		}
		markers--;
	}
}
