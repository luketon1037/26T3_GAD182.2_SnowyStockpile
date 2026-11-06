using UnityEngine;

public class HidingTarget : MonoBehaviour
{
    public bool isSuspect = false;

    public void SetSuspectActive(bool active)
    {
        isSuspect = active;
    }

    public WatchThisManager manager;

    private void OnMouseDown()
    {
        manager.CheckSuspectClicked(this);
    }
}