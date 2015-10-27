using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
    public float speed = 25;
    public float decay = 3;
    public Rigidbody2D bullet;

	void Start () {
        StartCoroutine(SelfDestruct());
        //Quaternion q = Quaternion.AngleAxis(player.rotation, Vector3.forward);
        //bullet.rotation = player.rotation;
        bullet.velocity = transform.up * speed;
    }
	
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(decay);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }


}
