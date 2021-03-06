using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed variables
    private float speed = 10f;
    private float speedHalved = 7.5f;
    private float speedOrigin = 10f;
    private CharacterAnimation anim;
    void Start()
    {
        anim = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
 
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
        float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
        PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
    }

    private void PlayerMove(float h, float v)
    {
        if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
        {
            if (h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
            {
                speed = speedHalved; // Modify the speed to adjust for moving on an angle
            }
            else // If only horizontal OR vertical are pressed individually then continue
            {
                speed = speedOrigin; // Keep speed to it's original value
            }

            Vector3 targetDirection = new Vector3(h, 0f, v); // Set a direction using Vector3 based on horizontal and vertical input
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + targetDirection * speed * Time.deltaTime); // Move the players position based on current location while adding the new targetDirection times speed
            anim._animRun = true;
        }
        else    // If horizontal or vertical are not pressed then continue
        {
            anim._animRun = false; // Disable the run animation
        }
    }
}
