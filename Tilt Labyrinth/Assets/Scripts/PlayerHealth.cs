using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Slider lifeBar;
    public Image fill;
    public Color maxHealthColor = Color.green;
    public Color midHealthColor = Color.yellow;
    public Color minHealthColor = Color.red;
    public static float hitPoints;
    public float maxHitPoints;
    public GameObject gameManager;
    public GameObject ringSmoke;

    void Start()
    {
        hitPoints = PlayerPrefs.GetFloat("hitPoints");
        maxHitPoints = PlayerPrefs.GetFloat("maxHitPoints");
        PlayerPrefs.Save();
        TakeDamage(0);
    }

    public static float GetHitPoints()
    {
        return hitPoints;
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        hitPoints = Mathf.Clamp(hitPoints, 0, maxHitPoints);
        lifeBar.value = hitPoints / maxHitPoints;
        LifebarColor();
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            Instantiate(ringSmoke, transform.position, Quaternion.identity);
            gameManager.GetComponent<GameManager>().GameOver();
        }

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
