using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    [SerializeField] private float walkSpeed = 15;
    [SerializeField] private float health = 100;

    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float walkDistance = walkSpeed * Time.deltaTime;
        //transform.position += new Vector3(horizontal, 0, vertical).normalized * walkDistance;
        _characterController.Move(new Vector3(horizontal, 0, vertical).normalized * walkDistance);

    }
}
