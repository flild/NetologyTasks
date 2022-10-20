using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSwitcher : PlatformManager
{
    private int _current_index = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "LevelTrigger")
        {
            Destroy(_ActivePlatforms[_current_index]);
            _ActivePlatforms[_current_index] = SpawnPlatform(_prefabPlatforms[Random.Range(0, _prefabPlatforms.Length)]);
            _current_index++;
            if (_current_index >= _ActivePlatforms.Length) _current_index = 0;
        }
    }
}
