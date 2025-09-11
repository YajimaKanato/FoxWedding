using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(ObjectActionForPool))]
public class FriedTofu : MonoBehaviour
{
    [SerializeField] float _gravity = 3;

    Rigidbody2D _rb2d;
    BoxCollider2D _bc2d;

    Vector3 _mousePos;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _bc2d = GetComponent<BoxCollider2D>();

        if (tag != GameManager.FriedTofuName)
        {
            tag = GameManager.FriedTofuName;
        }
    }

    private void Update()
    {
        
    }
}
