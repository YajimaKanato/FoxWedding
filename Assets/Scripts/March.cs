using System;
using UnityEngine;

/// <summary>
/// 行進の親にのせる
/// </summary>
[RequireComponent(typeof(CapsuleCollider2D),typeof(Rigidbody2D), typeof(ObjectActionForPool))]
public abstract class March : ObjectBase
{
    [SerializeField] float _maxSpeed = 2f;
    [SerializeField] float _minSpeed = 0.5f;

    Rigidbody2D _rb2d;
    CapsuleCollider2D _cc2d;
    Action _pauseVel, _resumeVel;
    protected ObjectActionForPool _pool;

    Vector3 _direction;

    float _moveX;
    float _speed;

    private void OnDisable()
    {
        UnSetGameFlowFunc();
    }

    protected override void SetGameFlowFunc()
    {
        base.SetGameFlowFunc();
        _pauseVel = () => _rb2d.linearVelocity = Vector3.zero;
        _resumeVel = () => _rb2d.linearVelocity = _direction * _speed;
        GameFlowSign.PauseAct += _pauseVel;
        GameFlowSign.ResumeAct += _resumeVel;
    }

    protected override void UnSetGameFlowFunc()
    {
        base.UnSetGameFlowFunc();
        GameFlowSign.PauseAct -= _pauseVel;
        GameFlowSign.ResumeAct -= _resumeVel;
    }

    /// <summary>
    /// 初期設定を行う関数
    /// </summary>
    protected virtual void SetUp()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0;
        _rb2d.freezeRotation = true;
        _cc2d = GetComponent<CapsuleCollider2D>();
        _cc2d.isTrigger = true;
        _pool = GetComponent<ObjectActionForPool>();
    }

    protected void SetVelocity()
    {
        _speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        _moveX = Vector3.zero.x - transform.position.x;
        _direction = new Vector3(_moveX, 0, 0).normalized;
        _rb2d.linearVelocity = _direction * _speed;
    }

    public abstract void GetFriedTofu();
}
