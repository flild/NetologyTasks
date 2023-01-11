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
    [SerializeField] private Ball _ball;

    private List<GameObject> _levelBlocks;
    private List<int> _usedNumbers = new List<int>();
    private int _level = 0;
    private bool _isLevelCreate;
    

    private void Start()
    {
        _isLevelCreate = false;
        SpawnLevel();
        
    }
    private void SpawnLevel()
    {
        _level++;
        ZeroParametrs();
        Debug.Log("Уровень" + _level);
        _levelBlocks = new List<GameObject>();
        for(int i = 0; i<4+_level*2; i++)
        {
            var rand_blocks = _blocks[Random.Range(0, _blocks.Length)];
            var rand_materials = _materials[Random.Range(0, _materials.Length)];
            Quaternion rand_rotation = Quaternion.Euler(Random.Range(-15, 15),
                                                        Random.Range(-15, 15),
                                                        Random.Range(-15, 15));
            int rand_index = GetRandomIndex();
            _levelBlocks.Add(Instantiate(rand_blocks, _spawnPoints[rand_index].position, rand_rotation));
        }
        _isLevelCreate = true;
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

    private void ZeroParametrs()
    {
        _isLevelCreate = false;
        _ball.FreezeBallToShoot();
        _usedNumbers = new List<int>();
        _levelBlocks = new List<GameObject>();
        
    }

    public void ReduceLevelBlocks(GameObject block)
    {
        _levelBlocks.Remove(block);
        Destroy(block);
        if (_levelBlocks.Count == 0)
        {
            SpawnLevel();
        }
    }

    public void ResetGame()
    {
        foreach(var block in _levelBlocks)
        {
            Destroy(block);
        }
        _levelBlocks.Clear();
        _level = 0;
        SpawnLevel();
    }

    

}
