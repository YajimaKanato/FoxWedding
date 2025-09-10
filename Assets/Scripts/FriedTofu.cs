using UnityEngine;

public class FriedTofu : MonoBehaviour
{
    Vector3 _mousePos;
    private void Update()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(_mousePos);
    }
}
