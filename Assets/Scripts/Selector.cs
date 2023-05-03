using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    private Camera cam;

    public static Selector Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        cam = Camera.main;
    }

    public Vector3 GetCurTilePosition()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return new Vector3(0, -99, 0);
        }
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float rayOut = 0.0f;
        if(plane.Raycast(ray, out rayOut))
        {
            Vector3 newPositon = ray.GetPoint(rayOut) - new Vector3(0.5f, 0.0f, 0.5f);
            newPositon = new Vector3(Mathf.CeilToInt(newPositon.x), 0.0f, Mathf.CeilToInt(newPositon.z));
            return newPositon;
        }
        return new Vector3(0, -99, 0);
    }
}
