using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletHole : MonoBehaviour
{
    public GameObject bulletHole;
    public float distance = 10f;
    public GameObject hole;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetButtonDown("Fire1"))
    {
        // Tạo một ray từ vị trí của camera đi qua vị trí con trỏ chuột
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Kiểm tra xem ray có va chạm với bất kỳ đối tượng nào không
        if (Physics.Raycast(ray, out hit, distance))
        {
            // Lấy thông tin vị trí và hướng của va chạm
            Vector3 hitPosition = hit.point;
            Vector3 hitNormal = hit.normal;

            // Tạo một lỗ đạn tại vị trí va chạm và xoay nó theo hướng của bề mặt va chạm
            GameObject bulletHoleInstance = Instantiate(bulletHole, hitPosition, Quaternion.LookRotation(-hitNormal));

            // Gắn lỗ đạn vào parent để quản lý và xóa sau khi cần thiết
            bulletHoleInstance.transform.parent = hole.transform;
            
            // Xóa lỗ đạn sau 5 giây
            Destroy(bulletHoleInstance, 2f);
        }
    }
}
}