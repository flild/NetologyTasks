using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabPlatforms;
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private GameObject _player;

    private int _current_index = 0;
    private Vector3 _spawnPoint = new Vector3(0, 0, 0);

    private GameObject[] _ActivePlatforms = new GameObject[5];

    private void Start()
    {
        _ActivePlatforms[0] = SpawnPlatform(_startPlatform);
        Instantiate(_player,new Vector3(0, 1.38f, -3.56999993f), Quaternion.Euler(0, 0, 0),transform); 
        for (int index = 1;index < _ActivePlatforms.Length;index++)
        {
            _ActivePlatforms[index] = SpawnPlatform(_prefabPlatforms[Random.Range(0, _prefabPlatforms.Length)]);

        }

        
    }
    private GameObject SpawnPlatform(GameObject platform)
    {
        GameObject createdPlatform =  Instantiate(platform, _spawnPoint, Quaternion.Euler(0, 0, 0));
        _spawnPoint.z += 10;
        return createdPlatform;
    }

    public void SpawnNextPlatform()
    {
        Destroy(_ActivePlatforms[_current_index]);
        _ActivePlatforms[_current_index] = SpawnPlatform(_prefabPlatforms[Random.Range(0, _prefabPlatforms.Length)]);
        _current_index++;
        if (_current_index >= _ActivePlatforms.Length) _current_index = 0;
    }
}
