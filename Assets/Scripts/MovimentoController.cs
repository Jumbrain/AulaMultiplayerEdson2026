using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovimentoController : NetworkBehaviour
{
    public CharacterController character;
    public float speed = 2;
    public Animator anim;
    public Rigidbody rb;
    public float jumpForce;
    public float rotateSpeed;
    public float moveSpeed;

    [Networked] public int Score { get; set; }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]

    public void RPC_AddScore(int points)
    {
        Score += points;
    }

    public void Awake()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if(HasStateAuthority)
        {
            float horDir = Input.GetAxis("Horizontal");
            float verDir = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            transform.Rotate(0, horDir * rotateSpeed, 0 );
            Vector3 movement = new Vector3(0, 0, verDir);
            transform.Translate(movement * moveSpeed * Time.deltaTime);

        }
    }
}
