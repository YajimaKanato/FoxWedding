using UnityEngine;
using System.Collections.Generic;

public class WeddingSpawner : MonoBehaviour
{
    [System.Serializable]
    class WeddingData
    {
        [SerializeField] GameObject _prefab;
        [SerializeField] int _rate;
        public GameObject Prefab { get { return _prefab; } }
        public int Rate { get { return _rate; } }
    }

    [SerializeField] List<WeddingData> _weddingList;
    [SerializeField] int _posMaxY;
    [SerializeField] int _posMinY;
    [SerializeField] int[] _posX;
    [SerializeField] float _spawnInterval = 0.5f;

    float _delta;
    float _maxWeight;
    float _currentWeight;
    float _randWeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        _delta += Time.deltaTime;
        if (_delta > _spawnInterval)
        {
            _delta = 0;
            Spawner();
        }
    }

    /// <summary>
    /// 初期設定を行う関数
    /// </summary>
    void SetUp()
    {
        foreach (var weight in _weddingList)
        {
            _maxWeight += weight.Rate;
        }
    }

    /// <summary>
    /// スポーンを管理する関数
    /// </summary>
    void Spawner()
    {
        _randWeight = Random.Range(0, _maxWeight);
        foreach (var weight in _weddingList)
        {
            _currentWeight += weight.Rate;
            if (_currentWeight >= _randWeight)
            {
                int y = Random.Range(_posMinY, _posMaxY);
                int x = Random.Range(0, 2);
                Instantiate(weight.Prefab, new Vector3(_posX[x], y), Quaternion.identity);
                break;
            }
        }
    }
}
