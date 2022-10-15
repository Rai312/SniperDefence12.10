using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool IsReach { get; private set; } = false;

    public event Action Reached;

    public void Set()
    {
        IsReach = true;
    }
}
