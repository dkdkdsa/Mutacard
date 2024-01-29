using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -10f;
    [SerializeField] private float maxY = 10f;

    [Header("Zoom")]
    [SerializeField] private float wheelSpeed;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;

    private CinemachineVirtualCamera vcam;
    private Rigidbody2D rb;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CameraMove();
        CameraWheel();
    }

    private void CameraMove()
    {
        Vector3 pos = transform.position;

        //위쪽
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            pos.y += panSpeed * Time.deltaTime;

        //아래쪽
        if (Input.mousePosition.y <= panBorderThickness)
            pos.y -= panSpeed * Time.deltaTime;

        //오른쪽
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            pos.x += panSpeed * Time.deltaTime;

        //왼쪽
        if (Input.mousePosition.x <= panBorderThickness)
            pos.x -= panSpeed * Time.deltaTime;

        //최대, 최소
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    private void CameraWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * -wheelSpeed;

        if (vcam.m_Lens.FieldOfView >= maxSize && scroll > 0) //최대 줌아웃
        {
            vcam.m_Lens.FieldOfView = maxSize;
        }
        else if (vcam.m_Lens.FieldOfView <= minSize && scroll < 0) //최대 줌인
        {
            vcam.m_Lens.FieldOfView = minSize;
        }
        else
            vcam.m_Lens.FieldOfView += scroll;
    }
}
