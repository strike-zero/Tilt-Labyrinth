using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
    private int leftFinger = -1;
    private int rightFinger = -1;
    private Vector2 touchLeft = Vector2.zero;
    private Vector2 touchRight = Vector2.zero;
    public Rigidbody2D missile;
    public Rigidbody2D bullet;
    public Rigidbody2D bomb;
    public int missileCount = 20;
    public int bombCount = 20;
    public int ammoType = 0;
    public float swipeLength = 15;
    private float swipeDist = 0;
    public Text ammo;


    void Start()
    {
        swipeLength = Screen.dpi / 3;
        Debug.Log("threshold: " + swipeLength);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Time.timeScale != 0)
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        leftFinger = touch.fingerId;
                        touchLeft = touch.position;
                    }

                    if (touch.position.x > Screen.width / 2)
                    {
                        rightFinger = touch.fingerId;
                        touchRight = touch.position;
                        swipeDist = 0;
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    if (touch.fingerId == leftFinger)
                    {
                        Vector2 vectorToTarget = touch.position - touchLeft;
                        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1) * Quaternion.Euler(0, 0, -90);
                    }
                    if (touch.fingerId == rightFinger)
                    {
                        swipeDist = touch.position.y - touchRight.y;
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (touch.fingerId == leftFinger)
                    {
                        leftFinger = -1;
                    }

                    if (touch.fingerId == rightFinger)
                    {
                        //swipe motion up
                        if (swipeDist > swipeLength)
                        {
                            //change up ammo
                            if (ammoType != 2)
                                ammoType++;
                            else
                                ammoType = 0;
                            ammoName(ammoType);
                            Debug.Log("ammoType " + ammoType + " dist: " + swipeDist + " threshold: " + swipeLength);
                        }
                        //swipe motion down
                        else if (swipeDist < -swipeLength)
                        {
                            //change down ammo
                            if (ammoType != 0)
                                ammoType--;
                            else
                                ammoType = 2;
                            ammoName(ammoType);
                            Debug.Log("ammoType " + ammoType + " dist: " + swipeDist + " threshold: " + swipeLength);
                        }
                        else
                        {
                            switch (ammoType)
                            {
                                case 0:
                                    Instantiate(bullet, transform.position, transform.rotation);
                                    break;
                                case 1:
                                    if (missileCount > 0)
                                    {
                                        Instantiate(missile, transform.position, transform.rotation);
                                        missileCount--;
                                        ammo.text = "MISSILES x " + missileCount;
                                    }
                                    break;
                                case 2:
                                    if (bombCount > 0)
                                    {
                                        Instantiate(bomb, transform.position, transform.rotation);
                                        bombCount--;
                                        ammo.text = "BOMBS x " + bombCount;
                                    }
                                    break;
                            }
                            rightFinger = -1;
                        }
                    }
                }
            }
        }
    }

    void ammoName(int type)
    {
        switch (type)
        {
            case 0:
                ammo.text = "BULLETS";
                break;
            case 1:
                ammo.text = "MISSILES x " + missileCount;
                break;
            case 2:
                ammo.text = "BOMBS x " + bombCount;
                break;
        }
    }
}
