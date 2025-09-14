using UnityEngine;

public class Hand : MonoBehaviour
{
    public enum HandState
    {
        Catch,
        Release
    }
    HandState _state = HandState.Release;
    public HandState State { get { return _state; } }

    [SerializeField] ObjectPoolAndSpawn _tofuSpawner;

    GameObject _tofu;

    /// <summary>�}�E�X�̍��W</summary>
    Vector3 _mousePos;

    bool _isStart = false;
    bool _isEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameFlowSign.StartAct += () => _isStart = true;
        GameFlowSign.EndAct += () => _isEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart && !_isEnd)
        {
            //�}�E�X���W���X�N���[�����W���烏�[���h���W�ɕϊ�
            _mousePos = Input.mousePosition;
            _mousePos.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(_mousePos);

            if (Input.GetMouseButtonDown(0))
            {
                _tofu = GetTofu();
                if (_tofu)
                {
                    _state = HandState.Catch;
                    _tofu.transform.SetParent(transform);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_state == HandState.Catch)
                {
                    _state = HandState.Release;
                    _tofu.GetComponent<FriedTofu>().UseTofu();
                    _tofu.transform.SetParent(null);
                }
            }
        }
    }

    /// <summary>
    /// �G�ꂽ���g�����擾����֐�
    /// </summary>
    /// <returns></returns>
    GameObject GetTofu()
    {
        foreach (var tofu in _tofuSpawner.ActiveList)
        {
            if (Vector3.Distance(transform.position, tofu.transform.position) <= GameManager.FriedTofuRadius)
            {
                return tofu;
            }
        }

        return null;
    }
}
