using UnityEngine;
using System.Collections;

public class RedBulletScript : MonoBehaviour {
    public float speed = 25;
    public float decay = 3;
    public int damage = 25;
    public Rigidbody2D bullet;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        bullet.velocity = transform.up * speed;
    }

    void FixedUpdate()
    {
        
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(decay);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            other.SendMessage("TakeDamage", damage);
        }
            
    }
}
