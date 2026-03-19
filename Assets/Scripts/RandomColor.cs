using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private SkinnedMeshRenderer meshrend;
    public Material[] material;
    // Start is called before the first frame update
    void Start()
    {
        meshrend = GetComponent<SkinnedMeshRenderer>();
        Material randomMat = material[Random.Range(0, material.Length)];
        meshrend.material = randomMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
