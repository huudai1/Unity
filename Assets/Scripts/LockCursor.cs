using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.G))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}