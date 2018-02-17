using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropaneSpawner : MonoBehaviour
{
    public GameObject PropanePrefab;
    private float speed;
    private float timeElapsed;
    // Use this for initialization
    void Start()
    {
        speed = Random.Range(20f, 50f) * -1;
        speed = -180;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed % 20 < 0.1)
        {
            Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 5f), 0f);
            var enemy = (GameObject)Instantiate(PropanePrefab,
                transform.position + spawnOffset, transform.rotation);
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));
        }

    }
}
