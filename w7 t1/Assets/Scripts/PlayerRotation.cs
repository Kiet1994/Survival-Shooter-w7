using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    private Camera cam;
    public Vector3 point;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition; // vị trí chuột
        Ray rayOrigin = cam.ScreenPointToRay(mousePos);// chiếu tia từ camera tới chuột
        Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 100, Color.yellow); //vẽ tia chíu từ camera tới chuột
        RaycastHit hitInfo;
        
        if (Physics.Raycast(rayOrigin, out hitInfo, Mathf.Infinity)) //If true is returned
        {
            if (hitInfo.collider) //not-null if it hit a Collider.
            {
                point = hitInfo.point; //The impact point in world space where the ray hit the collider.
            }
        }
        else
        {
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, maxDistance)); //
            Debug.Log(point);
        }

        transform.LookAt(new Vector3(point.x,0, point.z));
        //Debug.Log(mousePos);

    }

}
