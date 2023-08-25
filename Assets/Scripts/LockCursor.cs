using UnityEngine;

public class MouseLock : MonoBehaviour
{
    private bool isMouseLocked = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isMouseLocked = !isMouseLocked;
            Cursor.lockState = isMouseLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isMouseLocked;
        }
    }
}