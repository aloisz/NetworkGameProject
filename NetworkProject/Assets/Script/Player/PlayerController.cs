using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    [SerializeField] private float walkSpeed = 15;
    [SerializeField] private float rotationSpeed = 3;
    [SerializeField] private float health = 100;

    private Vector3 playerDirection;

    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        GameObject camera = Instantiate(GameManager.instance.camera, transform.position, Quaternion.identity);
        camera.GetComponent<CinemachineVirtualCamera>().Follow = transform;
    }

    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        
        Movement();
        HandleInputRotation();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float walkDistance = walkSpeed * Time.deltaTime;
        playerDirection = new Vector3(horizontal, 0, vertical);
        playerDirection.Normalize();
        
        _characterController.Move(playerDirection * walkDistance);
    }   

    private void HandleInputRotation()
    {
        if (playerDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }
    }
}
