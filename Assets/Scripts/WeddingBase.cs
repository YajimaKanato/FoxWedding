using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WeddingBase : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 5f;
    [SerializeField] float _minSpeed = 1f;
    Rigidbody2D _rb2d;

    Vector3 _direction;

    float _moveX;
    float _speed;

    /// <summary>
    /// ‰Šúİ’è‚ğs‚¤ŠÖ”
    /// </summary>
    protected virtual void SetUp()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.freezeRotation = true;
        _moveX = Vector3.zero.x - transform.position.x;
        _direction = new Vector3(_moveX, 0, 0).normalized;
        _speed = Random.Range(_minSpeed, _maxSpeed);
        if (tag != GameManager.WeddingName)
        {
            tag = GameManager.WeddingName;
        }
    }

    /// <summary>
    /// ‘¬“x‚ğŒˆ‚ß‚éŠÖ”
    /// </summary>
    protected virtual void SetVelocity()
    {
        if (transform.parent != null)
        {
            _rb2d.linearVelocity = Vector3.zero;
        }
        else
        {
            _rb2d.linearVelocity = _direction * _speed;
        }
    }
}
