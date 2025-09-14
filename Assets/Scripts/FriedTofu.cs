using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(ObjectActionForPool))]
public class FriedTofu : MonoBehaviour
{
    [SerializeField] float _gravity = 3;

    Rigidbody2D _rb2d;
    BoxCollider2D _bc2d;
    ObjectActionForPool _pool;
    GameObject _nearestObj;
    List<GameObject> _objs = new List<GameObject>();

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _bc2d = GetComponent<BoxCollider2D>();
        _pool = GetComponent<ObjectActionForPool>();

        if (tag != GameManager.FriedTofuTag)
        {
            tag = GameManager.FriedTofuTag;
        }
    }

    /// <summary>
    /// お揚げを使用するときに呼び出す関数
    /// </summary>
    public void UseTofu()
    {
        if (_nearestObj)
        {
            if (_nearestObj.tag == GameManager.FoxTag)
            {
                _nearestObj.GetComponent<Fox>().OnExit();
                Debug.Log("Used to Fox");
            }
            else if (_nearestObj.tag == GameManager.BrideTag)
            {
                _nearestObj.GetComponent<Bride>().OnExit();
                Debug.Log("Used to Bride");
            }
        }
        else
        {
            Debug.Log("Unused");
        }

        _nearestObj = null;
        _pool.ReleaseToPool();
    }

    /// <summary>
    /// 一番近いオブジェクトを設定する関数
    /// </summary>
    void SetNearest()
    {
        _nearestObj = null;
        foreach (GameObject obj in _objs)
        {
            if (!_nearestObj)
            {
                _nearestObj = obj;
            }
            else
            {
                if (Vector3.Distance(_nearestObj.transform.position, transform.position) > Vector3.Distance(obj.transform.position, transform.position))
                {
                    _nearestObj = obj;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GameManager.FoxTag || collision.tag == GameManager.BrideTag)
        {
            _objs.Add(collision.gameObject);
            SetNearest();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GameManager.FoxTag || collision.tag == GameManager.BrideTag)
        {
            _objs.Remove(collision.gameObject);
            SetNearest();
        }
    }
}
