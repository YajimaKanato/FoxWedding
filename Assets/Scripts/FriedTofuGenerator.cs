using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ObjectPoolAndSpawn))]
public class FriedTofuGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> _friedTofuImage;

    Queue<GameObject> _friedTofuQueue = new Queue<GameObject>();
    ObjectPoolAndSpawn _pool;

    Vector3 _tofuPos;

    private void Start()
    {
        _pool = GetComponent<ObjectPoolAndSpawn>();
        foreach (var friedTofu in _friedTofuImage)
        {
            friedTofu.SetActive(false);
            _friedTofuQueue.Enqueue(friedTofu);
        }
    }

    /// <summary>
    /// ���g���̃C���[�W�����֐�
    /// </summary>
    public void FriedTofuImageSpawn()
    {
        //���X�g�̏�Ԃ����܂����ƕω�������K�v������
        _friedTofuQueue.Peek().SetActive(true);
        _friedTofuQueue.Enqueue(_friedTofuQueue.Dequeue());
    }

    /// <summary>
    /// ���g���̎��Ԃ𐶐�����֐�
    /// </summary>
    /// <param name="tofu"></param>
    public void FriedTofuSpawn(GameObject tofu)
    {
        _tofuPos = transform.position;
        _tofuPos.z = 10;
        _pool.Spawn(tofu, Camera.main.ScreenToWorldPoint(_tofuPos), Quaternion.identity);
        _friedTofuQueue.Peek().SetActive(false);
    }
}
