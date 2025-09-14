using UnityEngine;
using System.Collections.Generic;

public class WeddingSpawner : ObjectBase
{
    [System.Serializable]
    class WeddingData
    {
        [SerializeField] WeddingType _type;
        [SerializeField] GameObject _prefab;
        [SerializeField] int _rate;
        public WeddingType Type { get { return _type; } }
        public GameObject Prefab { get { return _prefab; } }
        public int Rate { get { return _rate; } }

        public enum WeddingType
        {
            Fox,
            Bride
        }
    }

    [SerializeField] List<WeddingData> _weddingList;
    [SerializeField] int _posMaxY;
    [SerializeField] int _posMinY;
    [SerializeField] int[] _posX;
    [SerializeField] float _spawnInterval = 0.5f;
    [SerializeField] ObjectPoolAndSpawn _foxPool, _bridePool;

    float _delta;
    float _maxWeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart && !_isEnd)
        {
            if (!_isPause)
            {
                _delta += Time.deltaTime;
                if (_delta > _spawnInterval)
                {
                    _delta = 0;
                    Spawner();
                }
            }
        }
    }

    private void OnEnable()
    {
        SetGameFlowFunc();
    }

    private void OnDisable()
    {
        UnsetGameFlowFunc();
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
        float _currentWeight = 0;
        float _randWeight = Random.Range(0, _maxWeight);
        foreach (var weight in _weddingList)
        {
            _currentWeight += weight.Rate;
            if (_currentWeight >= _randWeight)
            {
                int y = Random.Range(_posMinY, _posMaxY);
                int x = Random.Range(0, 2);
                switch (weight.Type)
                {
                    case WeddingData.WeddingType.Bride:
                        _bridePool.Spawn(weight.Prefab, new Vector3(_posX[x], y), Quaternion.identity);
                        break;
                    case WeddingData.WeddingType.Fox:
                        _foxPool.Spawn(weight.Prefab, new Vector3(_posX[x], y), Quaternion.identity);
                        break;
                }
                return;
            }
        }
    }
}
