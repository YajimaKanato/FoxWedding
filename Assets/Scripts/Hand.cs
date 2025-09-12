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

    [SerializeField] FriedTofuGenerator _gene;

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
            if (_hit)
            {
                Debug.Log(_hit.collider.name);
                if (_hit.collider.tag == GameManager.FriedTofuName)
                {
                    _state = HandState.Catch;
                    _hit.collider.transform.SetParent(this.transform);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_state == HandState.Catch)
            {
                _state = HandState.Release;
                _hit.collider.gameObject.GetComponent<FriedTofu>().UseTofu();
                _hit.collider.transform.SetParent(null);
            }
        }
    }
}
