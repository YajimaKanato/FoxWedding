using UnityEngine;

public class Bride : March
{
    [SerializeField] int _score = -50;

    SpriteRenderer _spriteRenderer;

    bool _exit = false;
    private void Awake()
    {
        SetUp();
    }

    private void OnEnable()
    {
        SetVelocity();
        SetGameFlowFunc();
        SetDefault();
    }

    protected override void SetUp()
    {
        base.SetUp();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (tag != GameManager.BrideTag)
        {
            tag = GameManager.BrideTag;
        }
    }

    void SetDefault()
    {
        _spriteRenderer.color = Color.red;
        _exit = false;
    }

    public override void GetFriedTofu()
    {
        //バグったらフラグに変更
        if (!_exit)
        {
            ScoreManager.Score = _score;
            _spriteRenderer.color = Color.clear;
            _exit = true;
            Debug.Log("B:Exit");
        }
        gameObject.SetActive(false);
    }
}
