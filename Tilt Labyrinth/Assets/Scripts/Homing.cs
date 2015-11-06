using UnityEngine;
using System.Collections;

public class Homing : MonoBehaviour {
    public float missileVelocity = 100;
    public float turn = 20;
    public Rigidbody2D homingMissile;
    public float fuseDelay;
    public float delay;
    private Transform target;
    private float distance = Mathf.Infinity;

    void Start()
    {

        Fire();
        StartCoroutine(SelfDestruct());

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
        //end test code
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turn);
    }

    void Fire()

    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = player.transform.rotation * Quaternion.Euler(0, 0, 90f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
