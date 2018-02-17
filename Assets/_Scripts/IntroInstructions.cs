using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroInstructions : MonoBehaviour
{

    public Text instructions;
    public float time = 5;
    private float timeElapsed;

    // Use this for initialization
    void Start()
    {
        Destroy(instructions, time);
    }


}
