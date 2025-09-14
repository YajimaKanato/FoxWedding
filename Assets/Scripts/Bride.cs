using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Bride : MonoBehaviour
{
    [SerializeField] int _score = -50;
    CapsuleCollider2D _cc2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cc2d = GetComponent<CapsuleCollider2D>();
        _cc2d.isTrigger = true;
        if (tag != GameManager.BrideTag)
        {
            tag = GameManager.BrideTag;
        }
    }

    /// <summary>
    /// Á‚¦‚é‚ÉŒÄ‚Ño‚³‚ê‚éŠÖ”
    /// </summary>
    public void OnExit()
    {
        ScoreManager.Score = _score;
        Debug.Log("B:Exit");
    }
}
