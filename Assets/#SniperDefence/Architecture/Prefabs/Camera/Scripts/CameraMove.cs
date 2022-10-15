
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private List<Transform> _path;

    private int _pathPointIndex = 0;
    
    private void Update()
    {
        if (_playableDirector. == _path[_pathPointIndex].position)
        {
            PausedAnimation();
            _pathPointIndex ++;
        }
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
