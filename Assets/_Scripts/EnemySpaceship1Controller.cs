using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpaceship1Controller : MonoBehaviour
{
    public Transform enemybulletSpawn;
    public GameObject enemybulletPrefab;
    public GameObject explosion;


    private float timeElapsed;
    

   

    // Use this for initialization

    void Start()
    {
     
    }
    void EnemyFire()
    {
        var bullet = (GameObject)Instantiate(enemybulletPrefab,
                enemybulletSpawn.position, enemybulletSpawn.rotation);

        Vector2 bulletMotion = new Vector2(10f, 0f);
        bullet.GetComponent<Rigidbody2D>().AddForce(-bulletMotion * 50);
        Destroy(bullet, 4f);
    }
    // Update is called once per frame
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed % 4 < .03)

        {
            EnemyFire();
        }
        transform.Rotate(new Vector2(0f, 90f) * 0.03f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("playerbullet") || (other.tag.Equals("spaceship")))
        {
           
            
            Instantiate(explosion, transform.position, rotation: transform.rotation);
            Destroy(gameObject);
            
        }
        
    }

}