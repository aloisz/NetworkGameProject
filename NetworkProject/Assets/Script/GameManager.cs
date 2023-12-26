using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject camera;

    [SerializeField] private Button btnHost;
    [SerializeField] private Button btnClient;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        btnHost.onClick.AddListener(HostConnect);
        btnClient.onClick.AddListener(ClientConnect);

    }

    void HostConnect()
    {
        NetworkManager.Singleton.StartHost();
        
    }
    
    void ClientConnect()
    {
        NetworkManager.Singleton.StartClient();
    }
    
}
