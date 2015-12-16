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
    public float turretSpeed = 3;
    public GameObject smoke;
    private GameObject damaged;
    public GameObject ringSmoke;
    private GameObject scriptManager;
    public float score = 100;

	// Use this for initialization
	void Start () {
        Invoke("ChangeRotation", 0);
        scriptManager = GameObject.FindGameObjectWithTag("ScriptManager");
        
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
                turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, aimRotation, Time.deltaTime * turretSpeed);

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
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, transform.rotation, Time.deltaTime * turretSpeed);
        cooldown -= Time.deltaTime;

        if (damaged != null)
            damaged.transform.position = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Projectile")
            TurnAround();
    }

    void Fire()
    {
        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    void ChangeRotation()
    {
        targetRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Invoke("ChangeRotation", Random.Range(1f, 3.5f));
    }

    void TurnAround()
    {
        targetRotation = targetRotation * Quaternion.Euler(0, 0, Random.Range(90f,270f));
        transform.rotation = targetRotation;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            scriptManager.GetComponent<GameManager>().EnemyDown();
            scriptManager.GetComponent<GameManager>().Score(score);
            Instantiate(ringSmoke, transform.position, Quaternion.identity);
            ParticleSystem part = damaged.GetComponent<ParticleSystem>();
            part.enableEmission = false;
            
            Destroy(damaged, part.duration + part.startLifetime);
        }
        else if (hitPoints <= 25)
            damaged = Instantiate(smoke);
    }
}
