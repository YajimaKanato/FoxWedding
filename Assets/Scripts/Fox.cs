using UnityEngine;
using Wedding;

[RequireComponent(typeof(Rigidbody2D))]
public class Fox : WeddingBase
{
    [SerializeField] Sprite _humanSprite;
    [SerializeField] Sprite _foxSprite;

    SpriteRenderer _spriteRenderer;
    WeddingManager _weddingManager;

    private void Start()
    {
        base.SetUp();
        SetUp();
    }

    private void Update()
    {
        //ChangeSprite();
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
