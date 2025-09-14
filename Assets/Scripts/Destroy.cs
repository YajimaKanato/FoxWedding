using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == GameManager.WeddingTag)
        {
            collision.GetComponent<ObjectActionForPool>().ReleaseToPool();
        }
    }
}
