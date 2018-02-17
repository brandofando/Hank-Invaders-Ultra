using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSOund : MonoBehaviour {

    public AudioSource explosion;
   void Awake()
    {
        if (gameObject != null)
        {


            explosion.Play();
        }
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
