using UnityEngine;
using Wedding;

[RequireComponent(typeof(CapsuleCollider2D))]
public class Fox : MonoBehaviour
{
    [SerializeField] Sprite _humanSprite;
    [SerializeField] Sprite _foxSprite;
    [SerializeField] GameObject _exitObj;
    [SerializeField] Animator _willowispAnimator;
    [SerializeField] int _willowispRate = 10;

    SpriteRenderer _spriteRenderer;
    WeatherManager _weddingManager;
    CapsuleCollider2D _cc2d;

    float _rand;

    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        ChangeSprite();
        _rand = Random.Range(0, 100);
        if (0 <= _rand && _rand < _willowispRate)
        {
            //_willowispAnimator.Play("");
        }
    }

    void SetUp()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.sprite= _humanSprite;
        _spriteRenderer.color = Color.red;
        _weddingManager = FindFirstObjectByType<WeatherManager>();
        _cc2d = GetComponent<CapsuleCollider2D>();
        _cc2d.isTrigger = true;
        if (tag != GameManager.FoxName)
        {
            tag = GameManager.FoxName;
        }
    }

    /// <summary>
    /// 天気によってスプライトを変化させる関数
    /// </summary>
    void ChangeSprite()
    {
        switch (_weddingManager.WeddingState)
        {
            case WeddingWeather.SunShower:
                //人間に化ける
                //_spriteRenderer.sprite = _humanSprite;
                _spriteRenderer.color = Color.red;
                break;
            case WeddingWeather.Sunny:
                //狐になる
                //_spriteRenderer.sprite = _foxSprite;
                _spriteRenderer.color = Color.yellow;
                break;
        }
    }

    /// <summary>
    /// 消える時に呼び出される関数
    /// </summary>
    public void SpawnExitObj()
    {
        GameObject.FindWithTag(GameManager.ExitObjectSpawnerName).GetComponent<ObjectPoolAndSpawn>().Spawn(_exitObj, transform.position, Quaternion.identity);
    }
}
