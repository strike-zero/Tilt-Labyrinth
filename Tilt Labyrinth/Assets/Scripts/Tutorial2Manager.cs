using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial2Manager : MonoBehaviour {
	public GameObject leftScreen;
	public GameObject rightScreen;
	public Text instructions;
	public GameObject theEnd;
	private int phase;
	private int enemyCount;

	private int leftFinger = -1;
    private int rightFinger = -1;

    public Text scoreText;
    private float playerScore;
    public static int scoreMultiplier;
    private float timer;
    public Text multiplierText;
    public Slider multiplierSlider;
    //private Vector2 touchLeft = Vector2.zero;
    //private Vector2 touchRight = Vector2.zero;

	// Use this for initialization
	void Start () {
		leftScreen.SetActive(true);
		phase = 1;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.touchCount > 0 && Time.timeScale != 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        leftFinger = touch.fingerId;
                    }

                    if (touch.position.x > Screen.width / 2)
                    {
                        rightFinger = touch.fingerId;
                        if (phase == 2) {
                        	rightScreen.SetActive(false);
                        	phase = 3;
                        }
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    if (touch.fingerId == leftFinger)
                    {
                    	if (phase == 1) {
                    		leftScreen.SetActive(false);
                    		rightScreen.SetActive(true);
                    		instructions.text = "TAP RIGHT SIDE OF SCREEN TO FIRE\nDESTROY ALL ENEMIES";
                    		phase = 2;
                    	}
                    }
                    if (touch.fingerId == rightFinger)
                    {
                        
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
                        rightFinger = -1;
                    }
                }
            }
        }
	}

    public void EnemyDown()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("enemy left = " + enemyCount);
        if (enemyCount <= 3)
        {
            EndTutorial();
        }
    }

    void EndTutorial() {
    	instructions.gameObject.SetActive(false);
    	theEnd.SetActive(true);
    }

    public void Score(float score) {
        playerScore = playerScore + (score * scoreMultiplier);
        timer = 5;
        scoreMultiplier = Mathf.Clamp(++scoreMultiplier,1,10);
        multiplierText.text = "X" + scoreMultiplier;
        scoreText.text = playerScore.ToString("00000000");
    }

    public void MultiplierTimer() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            scoreMultiplier = 1;
            timer = 5;
            multiplierText.text = "X" + scoreMultiplier;
        }
        multiplierSlider.value = timer;
    }

}
