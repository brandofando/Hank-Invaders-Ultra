using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeathSOund : MonoBehaviour
{

    public AudioSource chicken;
    void Awake()
    {
        if (gameObject != null)
        {


            chicken.Play();
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
