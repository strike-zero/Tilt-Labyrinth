using UnityEngine;
using System.Collections;

public class GreyTankScript : MonoBehaviour {
	public float hitPoints = 50;
	public GameObject ringSmoke;
	public GameObject damaged;
	public GameObject smoke;
	public GameObject scriptManager;
	public float score = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
            scriptManager.GetComponent<Tutorial2Manager>().EnemyDown();
            scriptManager.GetComponent<Tutorial2Manager>().Score(score);
            Instantiate(ringSmoke, transform.position, Quaternion.identity);
            ParticleSystem part = damaged.GetComponent<ParticleSystem>();
            part.enableEmission = false;
            
            Destroy(damaged, part.duration + part.startLifetime);
        }
        else if (hitPoints <= 25)
            damaged = Instantiate(smoke);
    }	
}
