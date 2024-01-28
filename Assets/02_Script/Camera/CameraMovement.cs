using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float wheelSpeed;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;

    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float panBorderThickness = 10f;

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
        //Vector2 inputAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //rb.velocity = inputAxis * moveSpeed;

        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime; // Move forward
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime; // Move backward
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime; // Move right
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime; // Move left
        }

        transform.position = pos;
    }

    private void CameraWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * -wheelSpeed;

        if (vcam.m_Lens.FieldOfView >= maxSize && scroll > 0) //√÷¥Î ¡‹æ∆øÙ
        {
            vcam.m_Lens.FieldOfView = maxSize;
        }
        else if (vcam.m_Lens.FieldOfView <= minSize && scroll < 0) //√÷¥Î ¡‹¿Œ
        {
            vcam.m_Lens.FieldOfView = minSize;
        }
        else
            vcam.m_Lens.FieldOfView += scroll;
    }
}
