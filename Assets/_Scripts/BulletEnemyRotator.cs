using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyRotator : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(
            new Vector2(360f, 0f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Bullet hit " + other.tag);
        if (other.tag.Equals("spaceship"))
        {
             
            Destroy(gameObject); // Destroy bullet
        }
        if (other.tag.Equals("playerbullet"))
        {
            Destroy(other.gameObject);  // Destroy enemy spacecraft
            Destroy(gameObject); // Destroy bullet
        }
    }
}