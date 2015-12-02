using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem partSys = GetComponent<ParticleSystem>();
        Destroy(gameObject, partSys.duration + partSys.startLifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
