using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ObjectPoolAndSpawn))]
public class FriedTofuGenerator : MonoBehaviour
{
    [SerializeField] GameObject _tofu;
    [SerializeField] List<GameObject> _friedTofuGenePoint;

    ObjectPoolAndSpawn _pool;

    private void Start()
    {
        _pool = GetComponent<ObjectPoolAndSpawn>();
    }

    /// <summary>
    /// Ç®ógÇ∞Çê∂ê¨Ç∑ÇÈä÷êî
    /// </summary>
    public void FriedTofuSpawn()
    {
        foreach (var tofu in _friedTofuGenePoint)
        {
            if (tofu.transform.childCount == 0)
            {
                _pool.Spawn(_tofu, tofu.transform.position, Quaternion.identity, tofu.transform);
                return;
            }
        }
    }
}
