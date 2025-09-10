using UnityEngine;
using Wedding;

public class WeatherManager : MonoBehaviour
{
    [SerializeField, Tooltip("天気雨の最大持続時間")] float _maxSunShowerTime = 20;
    [SerializeField, Tooltip("天気雨の最小持続時間")] float _minSunShowerTime = 10;
    [SerializeField, Tooltip("晴れの最大持続時間")] float _maxSunnyTime = 15;
    [SerializeField, Tooltip("晴れの最小持続時間")] float _minSunnyTime = 5;

    /// <summary>天気の状態</summary>
    WeddingWeather _weddingState = WeddingWeather.SunShower;
    /// <summary>天気の状態を受け取るプロパティ</summary>
    public WeddingWeather WeddingState { get { return _weddingState; } }

    /// <summary>天気雨の時間を計る</summary>
    float _sunShowerDelta;
    /// <summary>天気雨の持続時間</summary>
    float _sunShowerTime;
    /// <summary>晴れの時間を計る</summary>
    float _sunnyDelta;
    /// <summary>晴れの持続時間</summary>
    float _sunnyTime;

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
                if (_sunnyDelta == 0)
                {
                    _sunnyTime = Random.Range(_minSunnyTime, _maxSunnyTime);
                }

                //晴れの時間計測
                _sunnyDelta += Time.deltaTime;
                if (_sunnyDelta > _sunnyTime)
                {
                    _sunnyDelta = 0;
                    _weddingState = WeddingWeather.SunShower;
                    Debug.Log("It's SunShower");
                }
                break;
            case WeddingWeather.SunShower:
                //天気雨になった瞬間に晴れの持続時間を設定
                if (_sunShowerDelta == 0)
                {
                    _sunShowerTime = Random.Range(_minSunShowerTime, _maxSunShowerTime);
                }

                //天気雨の時間計測
                _sunShowerDelta += Time.deltaTime;
                if (_sunShowerDelta > _sunShowerTime)
                {
                    _sunShowerDelta = 0;
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