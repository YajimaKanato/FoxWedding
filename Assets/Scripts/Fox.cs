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
    [SerializeField] int _score = 100;

    SpriteRenderer _spriteRenderer;
    WeatherManager _weatherManager;
    CapsuleCollider2D _cc2d;

    float _rand;
    bool _exit;
    static bool _found = false;
    public static bool Found { get { return _found; } set { _found = value; } }

    private void Awake()
    {
        SetUp();
    }
    private void OnEnable()
    {
        SetDefault();
    }

    private void Update()
    {
        if (!_exit)
        {
            ChangeSprite();
            _rand = Random.Range(0, 100);
            if (0 <= _rand && _rand < _willowispRate)
            {
                //_willowispAnimator.Play("");
            }
        }
    }

    void SetUp()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.sprite= _humanSprite;
        _weatherManager = FindFirstObjectByType<WeatherManager>();
        _cc2d = GetComponent<CapsuleCollider2D>();
        _cc2d.isTrigger = true;
        if (tag != GameManager.FoxTag)
        {
            tag = GameManager.FoxTag;
        }
    }

    void SetDefault()
    {
        _spriteRenderer.color = Color.red;
        _exit = false;
    }

    /// <summary>
    /// 条件によってスプライトを変化させる関数
    /// </summary>
    void ChangeSprite()
    {
        if (_found)
        {
            _spriteRenderer.color = Color.yellow;
            return;
        }

        switch (_weatherManager.WeddingState)
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
    public void OnExit()
    {
        //GameObject.FindWithTag(GameManager.ExitObjectSpawnerTag).GetComponent<ObjectPoolAndSpawn>().Spawn(_exitObj, transform.position, Quaternion.identity);
        Debug.Log("F:Exit");
        _spriteRenderer.color = Color.clear;
        _exit = true;
        ScoreManager.Score = _score;
    }
}
