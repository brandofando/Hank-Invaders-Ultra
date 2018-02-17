using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public static ShipController instance;

    public float speed = 5f;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject explosion;
    private Rigidbody2D rb;
    public Text txtAmmo;
    private int ammoCount;
    public int initAmmo = 200;
    public AudioSource laserFire;
    public Text txtLives;
    private int livesCount;
    public int initLives = 3;
    public AudioSource propaneSound;
    public AudioSource hitSound;
   

    // Use this for initialization
    void Start()
    {
        livesCount = initLives;
        txtLives.text = "Lives: " + livesCount;

        ammoCount = initAmmo;
        txtAmmo.text = "Ammo: " + ammoCount;
        rb = gameObject.GetComponent<Rigidbody2D>();


    }
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

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
		
			Debug.Log ("Left arrow key pressed");
		}
		*/

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // Debug.Log ("Horizontal: " + moveH);
        // Debug.Log ("Vertical: " + moveV);

        Vector2 motion = new Vector2(moveH, moveV);

        rb.AddForce(motion * speed);

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
        {
            Fire();
        }
     

    }


    void Fire()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            txtAmmo.text = "Ammo: " + ammoCount;
            laserFire.Play();
            var bullet = (GameObject)Instantiate(bulletPrefab,
                bulletSpawn.position, bulletSpawn.rotation);

            Vector2 bulletMotion = new Vector2(10f, 0f);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
            Destroy(bullet, 4f);


        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (livesCount > 0)
        {
            if (other.tag.Equals("enemy") || other.tag.Equals("enemybullet"))
            {
                livesCount--;
                txtLives.text = "Lives: " + livesCount;
                hitSound.Play();
                
                Destroy(other.gameObject);


            }
            else if(other.tag.Equals("asteroid"))
            {
                propaneSound.Play();
                livesCount++;
                txtLives.text = "Lives: " + livesCount;
                Destroy(other.gameObject);
            }
        }
        else
        {
        
            Instantiate(explosion, transform.position, rotation: transform.rotation);
            Destroy(gameObject);
            gameOver = true;
            
            


        }
        
    }
    private void OnBecameInvisible()
    {
            gameOver = true;
      
    }
    
}