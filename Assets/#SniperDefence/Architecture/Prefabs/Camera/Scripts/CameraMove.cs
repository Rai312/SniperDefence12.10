
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    private int _pathPointIndex = 0;

    // private void Update()
    // {
    //     if (Input.GetMouseButton(1)) 
    //         PlayAnimation();
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayablePaused paused))
            PausedAnimation();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Inactivate()
    {
        gameObject.SetActive(false);
    }

    public void PlayAnimation()
    {
        _playableDirector.Play();
    }

    public void PausedAnimation()
    {
        _playableDirector.Pause();
    }
}
