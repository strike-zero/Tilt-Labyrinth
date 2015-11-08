using UnityEngine;
using System.Collections;

public class RedTankScript : MonoBehaviour {
    public GameObject bullet;
    public float speed = 10;
    public float turnSpeed = 5;
    public float range = 20;
    public float hitPoints = 50;
    private Quaternion targetRotation;
    public Rigidbody2D body;
    public GameObject turret;
    private float cooldown = 0;
    public float fireRate = 0.75f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("ChangeRotation", 0, 2);
        
	}
	
	// Update is called once per frame
	void Update () {
        body.velocity = transform.up * speed;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        
        //player is in range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        bool inRange = false;
        foreach (Collider2D hit in hitColliders)
        {
            if (hit.gameObject.tag == "Player")
            {
                //aiming the turret
                Vector3 aimDirection = hit.transform.position - transform.position;
                float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                Quaternion aimRotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, -90);
                turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation,aimRotation, Time.deltaTime * 5);

                //controls the firing rate
                if (cooldown <= 0)
                {
                    Fire();
                    cooldown = fireRate;
                }
                inRange = true;
            }
        }
        if(!inRange)
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, transform.rotation, Time.deltaTime * 5);
        cooldown -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Bullet")
            TurnAround();
    }

    void Fire()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    void ChangeRotation()
    {
        targetRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }

    void TurnAround()
    {
        targetRotation = targetRotation * Quaternion.Euler(0, 0, Random.Range(90f,270f));
        transform.rotation = targetRotation;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
    }
}
