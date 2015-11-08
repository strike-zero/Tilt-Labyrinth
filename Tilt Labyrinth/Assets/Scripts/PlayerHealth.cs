﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Slider lifeBar;
    public Image fill;
    public Color maxHealthColor = Color.green;
    public Color midHealthColor = Color.yellow;
    public Color minHealthColor = Color.red;
    public float hitPoints = 100;

    void FixedUpdate()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Life:" + hitPoints);
    }

    public void LifebarColor ()
    {
        if (lifeBar.value > 0.5)
            fill.color = Color.Lerp(midHealthColor, maxHealthColor, (lifeBar.value - 0.5f) * 2);
        else
            fill.color = Color.Lerp(minHealthColor, midHealthColor, lifeBar.value * 2);
    }

}
