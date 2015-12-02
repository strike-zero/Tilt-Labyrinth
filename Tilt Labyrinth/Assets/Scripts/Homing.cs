using UnityEngine;
using System.Collections;

public class Homing : MonoBehaviour {
    public float missileVelocity = 100;
    public float turn = 20;
    public Rigidbody2D homingMissile;
    public float damage = 25;
    public float delay;
    private Transform target;
    private float distance = Mathf.Infinity;
    public GameObject explosion;
    public GameObject smoke;
    private GameObject smokeHolder;

    void Start()
    { 
        Fire();
        smokeHolder = Instantiate(smoke);
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        smokeHolder.transform.position = transform.position;
    }

    void FixedUpdate()
    {
        if (homingMissile == null)
            return;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float diff = (go.transform.position - transform.position).sqrMagnitude;

            if (diff < distance)
            {
                distance = diff;
                target = go.transform;
            }
        }

        if (target == null)
        {
            homingMissile.velocity = transform.right * missileVelocity;
            return;
        }

        homingMissile.velocity = transform.right * missileVelocity;

        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turn);
    }

    void Fire()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 90f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            GameObject boom = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
            ParticleSystem boomParticle = boom.GetComponent<ParticleSystem>();
            Destroy(boom, boomParticle.duration + boomParticle.startLifetime);
            Destroy(gameObject);
            FadeNDestroy(smokeHolder);
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponentInParent<RedTankScript>().TakeDamage(damage);
                Debug.Log("Enemy hit!");
            }
        }

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(delay);
        FadeNDestroy(smokeHolder);
        Destroy(gameObject);
    }

    void FadeNDestroy(GameObject go)
    {
        ParticleSystem part = go.GetComponent<ParticleSystem>();
        part.enableEmission = false;

        float decay = part.duration + part.startLifetime;
        Destroy(go, decay);
    }
}
