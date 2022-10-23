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
    private ScoreCounter _score;

    private void Start()
    {
        _gameManager = transform.parent.gameObject;
        _manager = _gameManager.GetComponent<PlatformManager>();
        _score = _gameManager.GetComponentInChildren<ScoreCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LevelTrigger levelTrigger))
        {
            _manager.SpawnNextPlatform();
            _score.AddScore();
        }

    }
}
