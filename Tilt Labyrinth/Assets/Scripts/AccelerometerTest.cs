using UnityEngine;
using System.Collections;

public class AccelerometerTest : MonoBehaviour {

    public static float speed = 30;
    public static Vector3 initTilt;
    void Start()
    {
        initTilt = Vector3.zero;
        initTilt.y = Input.acceleration.y;
        initTilt.x = Input.acceleration.x;
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.y = Input.acceleration.y - initTilt.y;
        dir.x = Input.acceleration.x - initTilt.x;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

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
