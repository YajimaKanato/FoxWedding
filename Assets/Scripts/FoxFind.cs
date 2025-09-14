using System.Collections;
using UnityEngine;

public class FoxFind : MonoBehaviour
{
    [SerializeField] int _findModeTime = 10;

    Coroutine _coroutine;

    public void FoxFindMode()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(FindModeCount());
        }
    }

    IEnumerator FindModeCount()
    {
        Debug.Log("FindModeStart");
        Fox.Found = true;
        yield return new WaitForSeconds(_findModeTime);
        Debug.Log("FindModeEnd");
        Fox.Found = false;
        yield break;
    }
}
