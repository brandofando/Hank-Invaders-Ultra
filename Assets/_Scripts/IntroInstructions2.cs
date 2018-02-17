using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroInstructions2 : MonoBehaviour
{

    public Text instructions;
    public float time = 4;

    // Use this for initialization
    void Start()
    {
        Destroy(instructions, time);
    }



    // Update is called once per frame
    void Update()
    {

    }
}

