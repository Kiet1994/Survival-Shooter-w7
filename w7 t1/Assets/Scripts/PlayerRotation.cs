using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    private Camera cam;
    public Vector3 point;
    private Rigidbody playerRigidbody;
    public int floorMask;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition; // vị trí chuột
        Ray rayOrigin = cam.ScreenPointToRay(mousePos);// chiếu tia từ camera tới chuột
        Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 100, Color.yellow); //vẽ tia chíu từ camera tới chuột
        RaycastHit hitInfo;
        
        if (Physics.Raycast(rayOrigin, out hitInfo, 100, floorMask)) //tia này gặp layer. chứ nó hok bị xuyên qua và player xoay vòng vòng
        {
            if (hitInfo.collider) //not-null if it hit a Collider.
            {
                //point = hitInfo.point; //The impact point in world space where the ray hit the collider.
                Vector3 playerToMouse = hitInfo.point - transform.position;//
                playerToMouse.y = 0f;

                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                playerRigidbody.MoveRotation(newRotation);
            }
        }
        //else
        //{
        //    point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, maxDistance)); //
        //    Debug.Log(point);
        //}

        //transform.LookAt(new Vector3(point.x,0, point.z));
        //Debug.Log(mousePos);

    }

}
