using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ObjectPoolAndSpawn))]
public class FriedTofuGenerator : MonoBehaviour
{
    [SerializeField] GameObject _tofu;
    [SerializeField] List<GameObject> _friedTofuGenePoint;

    private void Start()
    {

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
                Instantiate(_tofu, tofu.transform.position, Quaternion.identity).transform.SetParent(tofu.transform);
                return;
            }
        }
    }
}
