using UnityEngine;
using UnityEngine.Playables;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    private int _pathPointIndex = 0;

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
