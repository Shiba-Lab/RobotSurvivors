using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSingleton : MonoBehaviour
{
    public static ItemSingleton instance;
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
