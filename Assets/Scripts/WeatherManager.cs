using UnityEngine;
using Wedding;

public class WeatherManager : MonoBehaviour
{
    [SerializeField, Tooltip("�V�C�J�̍ő厝������")] float _maxSunShowerTime = 20;
    [SerializeField, Tooltip("�V�C�J�̍ŏ���������")] float _minSunShowerTime = 10;
    [SerializeField, Tooltip("����̍ő厝������")] float _maxSunnyTime = 15;
    [SerializeField, Tooltip("����̍ŏ���������")] float _minSunnyTime = 5;

    /// <summary>�V�C�̏��</summary>
    WeddingWeather _weddingState = WeddingWeather.SunShower;
    /// <summary>�V�C�̏�Ԃ��󂯎��v���p�e�B</summary>
    public WeddingWeather WeddingState { get { return _weddingState; } }

    /// <summary>�V�C�J�̎��Ԃ��v��</summary>
    float _sunShowerDelta;
    /// <summary>�V�C�J�̎�������</summary>
    float _sunShowerTime;
    /// <summary>����̎��Ԃ��v��</summary>
    float _sunnyDelta;
    /// <summary>����̎�������</summary>
    float _sunnyTime;

    // Update is called once per frame
    void Update()
    {
        WeatherManage();
    }

    /// <summary>
    /// �V�C���Ǘ�����֐�
    /// </summary>
    void WeatherManage()
    {
        switch (_weddingState)
        {
            case WeddingWeather.Sunny:
                //����ɂȂ����u�Ԃɐ���̎������Ԃ�ݒ�
                if (_sunnyDelta == 0)
                {
                    _sunnyTime = Random.Range(_minSunnyTime, _maxSunnyTime);
                }

                //����̎��Ԍv��
                _sunnyDelta += Time.deltaTime;
                if (_sunnyDelta > _sunnyTime)
                {
                    _sunnyDelta = 0;
                    _weddingState = WeddingWeather.SunShower;
                    Debug.Log("It's SunShower");
                }
                break;
            case WeddingWeather.SunShower:
                //�V�C�J�ɂȂ����u�Ԃɐ���̎������Ԃ�ݒ�
                if (_sunShowerDelta == 0)
                {
                    _sunShowerTime = Random.Range(_minSunShowerTime, _maxSunShowerTime);
                }

                //�V�C�J�̎��Ԍv��
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