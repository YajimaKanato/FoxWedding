using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GameManager.FoxTag || collision.tag == GameManager.BrideTag)
        {
            collision.GetComponent<ObjectActionForPool>().ReleaseToPool();
        }
    }
}
