using System;
using UnityEngine;

/// <summary>
/// 行進の親にのせる
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(ObjectActionForPool))]
public class March : ObjectBase
{
    [SerializeField] float _maxSpeed = 2f;
    [SerializeField] float _minSpeed = 0.5f;

    Rigidbody2D _rb2d;
    Action _pauseVel, _resumeVel;

    Vector3 _direction;

    float _moveX;
    float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetUp();
    }

    private void OnEnable()
    {
        SetGameFlowFunc();
        SetVelocity();
    }

    private void OnDisable()
    {
        UnsetGameFlowFunc();
    }

    protected override void SetGameFlowFunc()
    {
        base.SetGameFlowFunc();
        _pauseVel = () => _rb2d.linearVelocity = Vector3.zero;
        _resumeVel = () => _rb2d.linearVelocity = _direction * _speed;
        GameFlowSign.PauseAct += _pauseVel;
        GameFlowSign.ResumeAct += _resumeVel;
    }

    protected override void UnsetGameFlowFunc()
    {
        base.UnsetGameFlowFunc();
        GameFlowSign.PauseAct -= _pauseVel;
        GameFlowSign.ResumeAct -= _resumeVel;
    }

    /// <summary>
    /// 初期設定を行う関数
    /// </summary>
    void SetUp()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.freezeRotation = true;
        if (tag != GameManager.WeddingTag)
        {
            tag = GameManager.WeddingTag;
        }
    }

    void SetVelocity()
    {
        _speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        _moveX = 0;
        _moveX = Vector3.zero.x - transform.position.x;
        _direction = new Vector3(_moveX, 0, 0).normalized;
        _rb2d.linearVelocity = _direction * _speed;
    }
}
