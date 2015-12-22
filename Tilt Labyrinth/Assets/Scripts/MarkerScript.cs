using UnityEngine;
using System.Collections;

public class MarkerScript : MonoBehaviour {
	public GameObject scriptManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0,0,-2));
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player"){
			scriptManager.GetComponent<TutorialManager>().Waypoints();
			Destroy(gameObject);
		}
	}
}
