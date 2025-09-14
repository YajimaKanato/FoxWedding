using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameFlowSign.PauseAct += PauseAct;
        GameFlowSign.ResumeAct += ResumeAct;
    }

    private void OnDisable()
    {
        GameFlowSign.PauseAct -= PauseAct;
        GameFlowSign.ResumeAct -= ResumeAct;
    }

    void PauseAct()
    {

    }

    void ResumeAct()
    {

    }
}
