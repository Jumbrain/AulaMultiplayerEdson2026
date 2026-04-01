using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : NetworkBehaviour
{
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public override void Spawned()
    {
        if(HasInputAuthority)
        {
            mainCamera.enabled = true;
            mainCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            mainCamera.enabled = false;
            mainCamera.GetComponent<AudioListener>().enabled = false;
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        mainCamera.gameObject.SetActive(false);
    }
}
