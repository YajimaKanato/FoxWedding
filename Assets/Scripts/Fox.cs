using TMPro;
using UnityEngine;
using Wedding;

public class Fox : March
{
    [SerializeField] Sprite _humanSprite;
    [SerializeField] Sprite _foxSprite;
    [SerializeField] GameObject _exitObj;
    [SerializeField] int _score = 100;

    SpriteRenderer _spriteRenderer;
    WeatherManager _weatherManager;
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
        SetVelocity();
        SetGameFlowFunc();
    }

    private void Update()
    {
        if (!_exit)
        {
            ChangeSprite();
        }
    }

    protected override void SetUp()
    {
        base.SetUp();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.sprite= _humanSprite;
        _weatherManager = FindFirstObjectByType<WeatherManager>();
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

    public override void GetFriedTofu()
    {
        //バグったらフラグに変更
        if (!_exit)
        {
            //GameObject.FindWithTag(GameManager.ExitObjectSpawnerTag).GetComponent<ObjectPoolAndSpawn>().Spawn(_exitObj, transform.position, Quaternion.identity);
            Debug.Log("F:Exit");
            _spriteRenderer.color = Color.clear;
            _exit = true;
            ScoreManager.Score = _score;
        }
        gameObject.SetActive(false);
    }
}
