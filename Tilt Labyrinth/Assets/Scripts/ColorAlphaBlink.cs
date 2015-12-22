using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorAlphaBlink : MonoBehaviour {
	bool isBlinking;
	float blinkRate = 0.7f;
	// Use this for initialization
	void Start () {
		isBlinking = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isBlinking)
			Blink();
	}

	void Blink () {
		float alpha = Mathf.PingPong(Time.time * blinkRate, 0.5f);
		Color thisColor = gameObject.GetComponent<Image>().color;
		thisColor.a = alpha;
		GetComponent<Image>().color = thisColor;
		//color.a = Mathf.PingPong(Time.time, 0.5f);
	}
}
