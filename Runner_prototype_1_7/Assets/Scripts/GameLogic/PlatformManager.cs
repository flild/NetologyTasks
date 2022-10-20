using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] protected GameObject[] _prefabPlatforms;
    [SerializeField] private GameObject _startPlatform;
    protected Vector3 _spawnPoint = new Vector3(0, 0, 0);

    //я не знаю как это сделать правильно....
    protected GameObject[] _ActivePlatforms = new GameObject[5];

    private void Start()
    {
        _ActivePlatforms[0] = SpawnPlatform(_startPlatform);
        for (int index = 1;index < _ActivePlatforms.Length;index++)
        {
            _ActivePlatforms[index] = SpawnPlatform(_prefabPlatforms[Random.Range(0, _prefabPlatforms.Length)]);

        }

        
    }
    protected GameObject SpawnPlatform(GameObject platform)
    {
        GameObject createdPlatform =  Instantiate(platform, _spawnPoint, Quaternion.Euler(0, 0, 0));
        _spawnPoint.z += 10;
        Debug.Log("Spawn");
        return createdPlatform;
    }
}
