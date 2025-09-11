using UnityEngine;

/// <summary>
/// 行進の親にのせる
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(ObjectActionForPool))]
public class March : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 2f;
    [SerializeField] float _minSpeed = 0.5f;

    Rigidbody2D _rb2d;
    ObjectActionForPool _objAct;

    Vector3 _direction;

    float _moveX;
    float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp();
    }

    /// <summary>
    /// 初期設定を行う関数
    /// </summary>
    void SetUp()
    {
        _objAct = GetComponent<ObjectActionForPool>();
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.freezeRotation = true;
        _moveX = Vector3.zero.x - transform.position.x;
        _direction = new Vector3(_moveX, 0, 0).normalized;
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _rb2d.linearVelocity = _direction * _speed;
        if (tag != GameManager.WeddingName)
        {
            tag = GameManager.WeddingName;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GameManager.DestroyObjName)
        {
            _objAct.ReleaseToPool();
        }
    }
}
