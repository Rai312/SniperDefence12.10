using UnityEngine;

public class TeamContainer : MonoBehaviour
{
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
