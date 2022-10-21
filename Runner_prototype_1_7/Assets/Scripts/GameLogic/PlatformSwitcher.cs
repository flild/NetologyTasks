using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class PlatformSwitcher : MonoBehaviour
{
    private GameObject _gameManager;
    private PlatformManager _manager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _manager = _gameManager.GetComponent<PlatformManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "LevelTrigger")
        {
            _manager.SpawnNextPlatform();
        }
    }
}
