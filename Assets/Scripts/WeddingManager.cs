using UnityEngine;
using Wedding;

public class WeddingManager : MonoBehaviour
{
    [SerializeField, Tooltip("����̍ő厝������")] float _maxSunnyTime = 15;
    [SerializeField, Tooltip("����̍ŏ���������")] float _minSunnyTime = 5;
    [SerializeField, Tooltip("����ɂȂ�m���i���j")] float _sunRate = 10;

    /// <summary>�V�C�̏��</summary>
    WeddingWeather _weddingState = WeddingWeather.SunShower;
    /// <summary>�V�C�̏�Ԃ��󂯎��v���p�e�B</summary>
    public WeddingWeather WeddingState { get { return _weddingState; } }

    /// <summary>����̎��Ԃ��v��</summary>
    float _delta;
    /// <summary>����ɂ��邩�ǂ��������߂闐��</summary>
    float _rand;
    /// <summary>����̎�������</summary>
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
    /// �V�C���Ǘ�����֐�
    /// </summary>
    void WeatherManage()
    {
        switch (_weddingState)
        {
            case WeddingWeather.Sunny:
                //����ɂȂ����u�Ԃɐ���̎������Ԃ�ݒ�
                if (_delta == 0)
                {
                    _sunnyTime = Random.Range(_minSunnyTime, _maxSunnyTime);
                }

                //����̎��Ԍv��
                _delta += Time.deltaTime;
                if (_delta > _sunnyTime)
                {
                    _delta = 0;
                    _weddingState = WeddingWeather.SunShower;
                    Debug.Log("It's SunShower");
                }
                break;
            case WeddingWeather.SunShower:
                //���t���[������ɂ��邩�ǂ��������߂�
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