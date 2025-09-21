using System;
using UnityEngine;

public class WilloWisp : ObjectBase
{
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    Action _pauseAct, _resumeAct;

    int _rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPause)
        {
            _rand = UnityEngine.Random.Range(0, 100);
            //_animator.SetInteger("", _rand);
            if (_rand <= 10)
            {
                _spriteRenderer.color = Color.white;
            }
            else
            {
                _spriteRenderer.color = Color.clear;
            }
        }
    }

    private void OnEnable()
    {
        SetGameFlowFunc();
    }

    private void OnDisable()
    {
        UnSetGameFlowFunc();
    }

    protected override void SetGameFlowFunc()
    {
        base.SetGameFlowFunc();
        //_pauseAct = () => _animator.speed = 0;
        //_resumeAct = () => _animator.speed = 1;
        //GameFlowSign.PauseAct += _pauseAct;
        //GameFlowSign.ResumeAct += _resumeAct;
    }

    protected override void UnSetGameFlowFunc()
    {
        base.UnSetGameFlowFunc();
        //GameFlowSign.PauseAct -= _pauseAct;
        //GameFlowSign.ResumeAct -= _resumeAct;
    }
}
