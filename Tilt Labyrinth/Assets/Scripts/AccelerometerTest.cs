using UnityEngine;
using System.Collections;

public class AccelerometerTest : MonoBehaviour {

    public static float speed = 30;
    public static Vector3 initTilt;
    public GameObject body;
    void Start()
    {
        Reorient();
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.y = Input.acceleration.y - initTilt.y;
        dir.x = Input.acceleration.x - initTilt.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        if (dir != Vector3.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            body.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward) * Quaternion.Euler(0, 0, 90);
        }


        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
        
    }

    public void Reorient()
    {
        initTilt = Vector3.zero;
        initTilt.y = Input.acceleration.y;
        initTilt.x = Input.acceleration.x;
    }
}
