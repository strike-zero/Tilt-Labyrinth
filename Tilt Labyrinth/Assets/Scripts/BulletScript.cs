using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public Rigidbody2D rbody2d;
	// Use this for initialization
	void Start () {
        rbody2d.velocity = new Vector2(rbody2d.velocity.x,8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
