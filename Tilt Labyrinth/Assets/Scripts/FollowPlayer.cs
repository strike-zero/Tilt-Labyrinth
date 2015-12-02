using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public GameObject target;
    public float followSpeed = 10;
    public float shakeRadius = 1;
    private bool isHit = false;
    private Vector3 pointAt;
    public float shakeDuration = 0.25f;
    private float duration;

	// Update is called once per frame

    void Start()
    {
        duration = shakeDuration;
    }

	void Update () {

        if (target != null)
        {
            if (isHit)
            {
                pointAt = CameraShake();
                duration -= Time.deltaTime;
                if (duration <= 0)
                {
                    isHit = false;
                }
            }
            else
                pointAt = new Vector3(target.transform.position.x, target.transform.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, pointAt, Time.deltaTime * followSpeed);
        }
	}

    Vector3 CameraShake()
    {
        Vector2 shake = Random.insideUnitCircle * shakeRadius;
        Vector3 camShake = new Vector3(shake.x + target.transform.position.x, shake.y + target.transform.position.y, -10f);
       
        return camShake;
    }

    public void Shake()
    {
        duration = shakeDuration;
        isHit = true;
    }
}
