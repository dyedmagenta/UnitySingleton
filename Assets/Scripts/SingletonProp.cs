using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonProp : MonoBehaviour {
    //SingletonProp is just implementation of singleton pattern

    //When the gameobject is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //Singleton gameObject is persistent through scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //Saves Instance in static property and it can be set only by SingletonProp instance itself
    public static SingletonProp Instance { get; private set; }


}
