using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonProp : MonoBehaviour {

    //When the gameobject is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //Singleton gameObject is persisten through scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //Saves Instance in static property it can be set only by Singleton itself
    public static SingletonProp Instance { get; private set; }


}
