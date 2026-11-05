using UnityEngine;

public class HidingTarget : MonoBehaviour
{
    public bool isSuspect = false;

    public WatchThisManager manager;

    private void OnMouseDown()
    {
        manager.CheckSuspectClicked(this);
    }
}