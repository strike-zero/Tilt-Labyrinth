using UnityEngine;
using System.Collections;

public class RedBulletScript : MonoBehaviour {
    public float speed = 25;
    public float decay = 3;
    public float damage = 5;
    public float multiplier = 0.25f;
    public Rigidbody2D bullet;
    private GameObject playerCamera;
    public GameObject explosion;

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("levelNum");
        damage = damage + (damage * currentLevel * multiplier);
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        bullet.velocity = transform.up * speed;
        Destroy(gameObject, decay);
    }

    void Update()
    {
        decay -= Time.deltaTime;
        if (decay <= 0)
            Instantiate(explosion, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "EnemyProjectile")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.gameObject.tag == "Player")
            {
                GameObject target = other.gameObject;
                target.SendMessageUpwards("TakeDamage", damage);
                playerCamera.SendMessage("Shake");
            }
            Destroy(gameObject);
        }
    }
}
