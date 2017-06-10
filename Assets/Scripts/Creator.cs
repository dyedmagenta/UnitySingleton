using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Creator : MonoBehaviour
{
    
    //How many props will be spawned with one stream
    public int StreamSize = 400;
    //How strong the stream will be
    public int StreamForce = 10;
    //Max time between spawns in single stream
    public float MaxSpawnTime = 0.1f;
    //Min time between spawns in single stream
    public float MinSpawnTime = 0.05f;

    //Basic Simple Props
    public GameObject[] Props;
    //Singleton Props Only one of those can be instantiated at the same time
    public GameObject[] SingletonProps;

    private List<GameObject> _propsList;
    private void Start()
    {
        _propsList = Props.ToList();
        _propsList.AddRange(SingletonProps);
    }
    //Starts stream of random props
    public void RandomStream()
    {
        StartCoroutine(SpawnRandomStream());
    }
    //Spawns single singleton prop
    public void SpawnSingletonProp()
    {
        var rng = (int)(Random.value * 100) % SingletonProps.Length;
        var prop = Instantiate(SingletonProps[rng], transform.localPosition, transform.localRotation);
        EjectProp(prop);
    }
    //Spawns single basic prop
    public void SpawnProp()
    {
        var rng = (int)(Random.value * 100) % Props.Length;
        var prop = Instantiate(Props[rng], transform.localPosition, transform.localRotation);
        EjectProp(prop);
    }
    //Spawns stream of random props
    private IEnumerator SpawnRandomStream()
    {
        var waitTime = Random.Range(MinSpawnTime, MaxSpawnTime);

        for (int i = 0; i < StreamSize; i++)
        {
            var rng = (int)(Random.value * 100) % _propsList.Count;
            var prop = Instantiate(_propsList[rng], transform.localPosition, transform.localRotation);
            EjectProp(prop);

            yield return new WaitForSeconds(waitTime);
        }
    }
    //Ejects and rotates prop with given speed
    private void EjectProp(GameObject prop)
    {
        var propRigidbody = prop.GetComponent<Rigidbody>();
        propRigidbody.velocity = transform.up * StreamForce;
        propRigidbody.angularVelocity = Random.onUnitSphere * StreamForce;
    }


}
