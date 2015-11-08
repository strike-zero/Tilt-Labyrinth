using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {
    public float speed = 25;
    public float decay = 2;
    public float damage = 25;
    public Rigidbody2D bullet;

	void Start () {
        StartCoroutine(SelfDestruct());
        bullet.velocity = transform.up * speed;
    }
	
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(decay);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.tag != "Player")
        {
            //other.gameObject.SendMessage("TakeDamage", damage);
            other.gameObject.GetComponent<RedTankScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}