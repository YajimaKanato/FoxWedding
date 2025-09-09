using UnityEngine;
using Wedding;

[RequireComponent(typeof(Rigidbody2D))]
public class Fox : WeddingBase
{
    [SerializeField] Sprite _humanSprite;
    [SerializeField] Sprite _foxSprite;
    [SerializeField] Animator _animator;
    [SerializeField] int _willowispRate = 10;

    SpriteRenderer _spriteRenderer;
    WeddingManager _weddingManager;

    float _rand;

    private void Start()
    {
        base.SetUp();
        SetUp();
    }

    private void Update()
    {
        //ChangeSprite();
        _rand = Random.Range(0, 100);
        if (0 <= _rand && _rand < _willowispRate)
        {
            //_animator.Play("");
        }
    }

    void FixedUpdate()
    {
        base.SetVelocity();
    }

    protected override void SetUp()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _weddingManager = FindFirstObjectByType<WeddingManager>();
    }

    /// <summary>
    /// 天気によってスプライトを変化させる関数
    /// </summary>
    void ChangeSprite()
    {
        switch (_weddingManager.WeddingState)
        {
            case WeddingWeather.SunShower:
                _spriteRenderer.sprite = _humanSprite;
                break;
            case WeddingWeather.Sunny:
                _spriteRenderer.sprite = _foxSprite;
                break;
        }
    }
}
