using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCAM : MonoBehaviour
{
    private const float Y_angle_min = 0.0f;
    private const float Y_angle_max = 50.0f;
    public Transform LookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    private void Update()
    {
        currentX += Input.GetAxisRaw("Mouse X");
        currentY += Input.GetAxisRaw("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_angle_min, Y_angle_max);
    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0,-distance);
        Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
        camTransform.position = LookAt.position + rotation * dir;
        camTransform.LookAt(LookAt.position);
    }
}
