using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class MovimentoController : NetworkBehaviour
{
    public CharacterController character;

    public void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        if(HasStateAuthority)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(horizontal, 0, vertical);
            
            if(dir.magnitude > 0.1f)
            {
                //movimento do personagem
                character.Move(dir);
                //rotação do personagem
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
}
