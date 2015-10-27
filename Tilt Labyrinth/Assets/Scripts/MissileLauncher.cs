using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour
{
    public Rigidbody2D missile;
    float touchPos = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(missile, transform.position, transform.rotation);
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPos = touch.position.y;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    float swipeDist = touch.position.y - touchPos;
                    if (swipeDist > 100)
                    {
                        //add change ammo up code here
                    } else if (swipeDist < -100)
                    {
                        //add change ammo down code here
                    } else
                    {
                        Instantiate(missile, transform.position, transform.rotation);
                    }
                    break;
                    
            }
        }
    }

}