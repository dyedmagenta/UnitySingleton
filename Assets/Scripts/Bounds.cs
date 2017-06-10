using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bounds : MonoBehaviour {
    
    //When GameObject leaves bounds it will be destroyed
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}
