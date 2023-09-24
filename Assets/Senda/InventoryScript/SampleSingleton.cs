using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSingleton : MonoBehaviour
{
    public static SampleSingleton instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
