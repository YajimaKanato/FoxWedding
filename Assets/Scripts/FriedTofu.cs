using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(ObjectActionForPool))]
public class FriedTofu : MonoBehaviour
{
    [SerializeField] float _gravity = 3;

    Rigidbody2D _rb2d;
    BoxCollider2D _bc2d;
    ObjectActionForPool _pool;
    GameObject _bride;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _bc2d = GetComponent<BoxCollider2D>();
        _pool = GetComponent<ObjectActionForPool>();

        if (tag != GameManager.FriedTofuName)
        {
            tag = GameManager.FriedTofuName;
        }
    }

    public void UseTofu()
    {
        if (_bride)
        {
            Debug.Log("Use");
        }
        else
        {

        }

        _pool.ReleaseToPool();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == GameManager.FoxName)
        {
            if (!_bride)
            {
                _bride = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_bride)
        {
            _bride = null;
        }
    }
}
