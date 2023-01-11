using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private Material[] _materials;
    [SerializeField] private List<Transform> _spawnPoints;
    private List<int> _usedNumbers = new List<int>();
    private int _level = 3;
    

    private void Start()
    {
        SpawnLevel();
        
    }

    private void SpawnLevel()
    {
        Debug.Log("Первый уровень");
        for(int i = 0; i<5+_level*2; i++)
        {
            var rand_blocks = _blocks[Random.Range(0, _blocks.Length)];
            var rand_materials = _materials[Random.Range(0, _materials.Length)];
            Quaternion rand_rotation = Quaternion.Euler(Random.Range(-15, 15),
                                                        Random.Range(-15, 15),
                                                        Random.Range(-15, 15));
            int rand_index = GetRandomIndex();
            Instantiate(rand_blocks, _spawnPoints[rand_index].position, rand_rotation);
        }
    }

    private int GetRandomIndex()
    {
        int index = Random.Range(0, _spawnPoints.Count);
        int itterCount = 0;
        while (_usedNumbers.Contains(index)&& itterCount < _spawnPoints.Count)
        {
            index = Random.Range(0, _spawnPoints.Count);
            itterCount++;
        }
        if(_usedNumbers.Contains(index)) 
            throw new Exception("Кончилось место для спавна блоков");
        _usedNumbers.Add(index);
        return index;
    }

    

}
