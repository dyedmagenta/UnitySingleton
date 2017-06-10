using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorManager : MonoBehaviour
{
    private Creator[] _creators;

	void Start ()
	{
	    _creators = GetComponentsInChildren<Creator>();
	}
    public void RandomStream()
    {
        foreach (var creator in _creators)
        {
            creator.RandomStream();
        }
    }
    public void SpawnSingletonProps()
    {
        foreach (var creator in _creators)
        {
            creator.SpawnSingletonProp();
        }
    }
    public void SpawnBasicProp()
    {
        foreach (var creator in _creators)
        {
            creator.SpawnProp();
        }
    }
    //Finds and deletes all props
    public void ClearProps()
    {
        foreach (var prop in GameObject.FindGameObjectsWithTag("Prop"))
        {
            Destroy(prop);
        }
    }
}
