using UnityEngine;
using System.Collections;

public class BulletLauncher : MonoBehaviour {
    public Rigidbody2D projectile;
    public Rigidbody2D player;
    //public float speed = 10;

    void LaunchProjectile()
    {
        Quaternion q = Quaternion.Euler(0, 0, player.rotation);
        Instantiate(projectile,player.position,q);
        //instance.position = player.position;
        //instance.velocity = Vector2.up * speed;
    }

    void Fire()
    {
        Invoke("LaunchProjectile", 0.5f);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            LaunchProjectile();
        }
    }


}
