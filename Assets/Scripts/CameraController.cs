using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;

    public float minXRot, maxXRot;

    private float curXrot;

    public float minZoom, maxZoom;

    public float zoomSpeed;
    public float rotateSpeed;

    private float curZoom;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXrot = -50;
    }

    private void Update()
    {
        // zooming
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        cam.transform.localPosition = Vector3.up * curZoom;

        // camera look
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X") * rotateSpeed;
            float y = Input.GetAxis("Mouse Y") * rotateSpeed;
           
        }
    }
}
