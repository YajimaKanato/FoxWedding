using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(ObjectActionForPool))]
public class FriedTofu : MonoBehaviour
{
    [SerializeField] float _gravity = 3;

    Rigidbody2D _rb2d;
    BoxCollider2D _bc2d;
    ObjectActionForPool _objAct;

    Vector3 _mousePos;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = _gravity;
        _bc2d = GetComponent<BoxCollider2D>();
        _objAct = GetComponent<ObjectActionForPool>();
    }

    private void Update()
    {
        if (transform.parent.gameObject)
        {
            _rb2d.gravityScale = 0;
        }
        else
        {
            _rb2d.gravityScale = _gravity;
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
