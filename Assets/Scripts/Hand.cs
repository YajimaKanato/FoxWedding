using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Hand : MonoBehaviour
{
    [SerializeField] float _mouseTouchTime = 0.05f;

    CircleCollider2D _cc2d;
    Coroutine _coroutine;

    /// <summary>�}�E�X�̍��W</summary>
    Vector3 _mousePos;

    bool _isClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc2d = GetComponent<CircleCollider2D>();
        _cc2d.enabled = false;
        _cc2d.isTrigger = true;
        _cc2d.radius = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X���W���X�N���[�����W���烏�[���h���W�ɕϊ�
        _mousePos = Input.mousePosition;
        _mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(_mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(ClickCoroutine());
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _cc2d.enabled = false;
            if (transform.childCount > 0)
            {
                transform.GetChild(0).SetParent(null);
            }
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    /// <summary>
    /// �N���b�N�����Ƃ��ɔ��萶�����画����ł܂ł��s���֐�
    /// </summary>
    /// <returns></returns>
    IEnumerator ClickCoroutine()
    {
        _cc2d.enabled = true;
        yield return new WaitForSeconds(_mouseTouchTime);
        _cc2d.enabled = false;
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.childCount == 0)
        {
            if (collision.tag == GameManager.WeddingName)
            {
                collision.transform.SetParent(this.transform);
            }
        }
    }
}
