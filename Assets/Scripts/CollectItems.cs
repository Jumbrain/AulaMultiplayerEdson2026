using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public int points;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("moeda"))
        { 
            Destroy(other.gameObject);
            points++;
        }
    }
}
