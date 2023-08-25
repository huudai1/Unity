using UnityEngine;
using System.Collections;

public class ViewBobbing : MonoBehaviour
{
    public float bobbingSpeed = 0.18f; // Tốc độ của hiệu ứng nhấp nháy
    public float bobbingAmount = 0.2f; // Mức độ di chuyển của camera

    private float timer = 0.0f;
    private float midpoint = 2.0f;

    void Update()
    {
        // Lấy input từ trục di chuyển ngang và dọc (horizontal và vertical)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalInput) == 0 && Mathf.Abs(verticalInput) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            // Tính toán giá trị mới cho camera theo công thức sin(x) * y, với x là thời gian và y là mức độ di chuyển
            float waveslice = Mathf.Sin(timer);
            Vector3 newPosition = transform.localPosition;

            if (timer > Mathf.PI * 2)
            {
                timer -= Mathf.PI * 2;
            }

            if (waveslice != 0)
            {
                // Áp dụng hiệu chỉnh vào trục Y của camera để tạo hiệu quả view bobbing
                float translateChangeY = waveslice * bobbingAmount;
                newPosition.y += translateChangeY;
                
                // Áp dụng hiệu chỉnh vào trục X của camera để tạo hiệu quả view bobbing
                float translateChangeX = waveslice * bobbingAmount / 2f;
                newPosition.x += translateChangeX;
            }

            transform.localPosition = newPosition;
            timer += bobbingSpeed * Time.deltaTime;
        }
    }
}