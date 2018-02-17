using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject playerBullet;
    public GameObject enemyCraftPrefab;
    private float speed;
    private float timeElapsed;
    public Text txtScore;
    private int scoreCount;
    public int initScore = 0;




    public bool gameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        gameOver = false;
    }
    // Use this for initialization
    void Start()
    {
        scoreCount = initScore;
        txtScore.text = "Score: " + scoreCount;

        speed = Random.Range(20f, 50f) * -1;
        speed = -200;
        timeElapsed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed % 6 < 0.1)
        {
            Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 4f), 0f);
            var enemy = (GameObject)Instantiate(enemyCraftPrefab,
                transform.position + spawnOffset, transform.rotation);
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
        }
        
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(timeElapsed % .5 < 0.1)
        {
            scoreCount++;
            txtScore.text = "Score: " + scoreCount;
        }
        if(GameController.instance.gameOver)
        {
            scoreCount--;
            txtScore.text = "Score: " + scoreCount;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
        if (other.tag.Equals("enemy"))
            {
            Destroy(gameObject);
        }
    }

   
   

    public void PlayerDead()
    {
        gameOver = true;
    }
}