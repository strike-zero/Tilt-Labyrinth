using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
    public float speed = 25;
    public float decay = 2;
    public float damage = 25;
    public Rigidbody2D bullet;
    public GameObject explosion;

	void Start () {
        Destroy(gameObject, decay);
        bullet.velocity = transform.up * speed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Projectile")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.gameObject.tag == "Enemy")
            {
                GameObject target = other.gameObject;
                target.SendMessageUpwards("TakeDamage", damage);
                //Destroy(gameObject);
            }
            Destroy(gameObject);
        }

    }
}