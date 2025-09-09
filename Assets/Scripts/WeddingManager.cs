using UnityEngine;
using Wedding;

public class WeddingManager : MonoBehaviour
{
    [SerializeField, Tooltip("晴れの最大持続時間")] float _maxSunnyTime = 15;
    [SerializeField, Tooltip("晴れの最小持続時間")] float _minSunnyTime = 5;
    [SerializeField, Tooltip("晴れになる確率（％）")] float _sunRate = 10;

    /// <summary>天気の状態</summary>
    WeddingWeather _weddingState = WeddingWeather.SunShower;
    /// <summary>天気の状態を受け取るプロパティ</summary>
    public WeddingWeather WeddingState { get { return _weddingState; } }

    /// <summary>晴れの時間を計る</summary>
    float _delta;
    /// <summary>晴れにするかどうかを決める乱数</summary>
    float _rand;
    /// <summary>晴れの持続時間</summary>
    float _sunnyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeatherManage();
    }

    /// <summary>
    /// 天気を管理する関数
    /// </summary>
    void WeatherManage()
    {
        switch (_weddingState)
        {
            case WeddingWeather.Sunny:
                //晴れになった瞬間に晴れの持続時間を設定
                if (_delta == 0)
                {
                    _sunnyTime = Random.Range(_minSunnyTime, _maxSunnyTime);
                }

                //晴れの時間計測
                _delta += Time.deltaTime;
                if (_delta > _sunnyTime)
                {
                    _delta = 0;
                    _weddingState = WeddingWeather.SunShower;
                    Debug.Log("It's SunShower");
                }
                break;
            case WeddingWeather.SunShower:
                //毎フレーム晴れにするかどうかを決める
                _rand = Random.Range(0, 100);
                if (0 <= _rand && _rand < _sunRate)
                {
                    _weddingState = WeddingWeather.Sunny;
                    Debug.Log("It's Sunny");
                }
                break;
            default:
                break;
        }
    }
}

namespace Wedding
{
    public enum WeddingWeather
    {
        Sunny,
        SunShower
    }
}