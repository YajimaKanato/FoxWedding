using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Human : MonoBehaviour
{
    [SerializeField] float _speed = 5;

    Rigidbody2D _rb2d;

    Vector3 _direction;

    float _theta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.freezeRotation = true;

        _theta = Random.Range(0, 2 * Mathf.PI);
        _direction = new Vector3(Mathf.Cos(_theta), Mathf.Sin(_theta));
        _rb2d.linearVelocity = _direction * _speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
