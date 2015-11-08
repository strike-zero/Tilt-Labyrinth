using UnityEngine;
using System.Collections;

public class RandomTilt : MonoBehaviour {
    private float tilt = 0;
    public float turn = 2;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Tilting", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion q = Quaternion.AngleAxis(tilt, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turn);
    }

    void Tilting()
    {
        tilt = Random.Range(-15, 15);
    }
}
