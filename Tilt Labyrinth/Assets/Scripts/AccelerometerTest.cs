using UnityEngine;
using System.Collections;

public class AccelerometerTest : MonoBehaviour {

    public static float speed = 30;
    public static Vector3 initTilt;
    public GameObject body;
    public float maxSpeed = 3;
    public float deadZone = 0.05f;
    void Start()
    {
        Reorient();
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.y = Input.acceleration.y - initTilt.y;
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        if (dir != Vector3.zero && dir.magnitude > deadZone)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            body.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, 90);
        }

        if (dir.magnitude > deadZone) {
            dir *= Time.deltaTime;
            transform.Translate(Vector3.ClampMagnitude((dir * speed),maxSpeed));
        } 
    }

    public void Reorient()
    {
        initTilt = Vector3.zero;
        initTilt.y = Input.acceleration.y;
        initTilt.x = Input.acceleration.x;
    }
}
