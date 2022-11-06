using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    private CameraRotator _cameraRotator;
    private PlayableDirector _playableDirector;
    private CameraMove _cameraMove;

    public CameraRotator CameraRotator => _cameraRotator;
    public CameraMove CameraMove => _cameraMove;

    public event Action PlayableDirectorFinished;

    private void Awake()
    {
        _cameraMove = GetComponent<CameraMove>();
        _cameraRotator = GetComponent<CameraRotator>();
        _playableDirector = GetComponent<PlayableDirector>();
    }

    private IEnumerator ShowSniper()
    {
        float delay = (float)_playableDirector.duration;
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        _playableDirector.Play();
        yield return waitForSeconds;
        PlayableDirectorFinished?.Invoke();
    }

    public void ActivateShowSniperRoutine()
    {
        StartCoroutine(ShowSniper());
    }
}