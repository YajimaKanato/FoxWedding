using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Ray _ray2d;
    RaycastHit2D _hit;
    /// <summary>マウスの座標</summary>
    Vector3 _mousePos;

    bool _isClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //マウス座標をスクリーン座標からワールド座標に変換
        _mousePos = Input.mousePosition;
        _mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(_mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            _ray2d = Camera.main.ScreenPointToRay(Input.mousePosition);
            _hit = Physics2D.Raycast(_ray2d.origin, _ray2d.direction);
            if (_hit && _hit.collider.tag == GameManager.FriedTofuName)
            {
                _hit.collider.transform.SetParent(this.transform);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (transform.childCount > 0)
            {
                transform.GetChild(0).SetParent(null);
            }
        }
    }
}
