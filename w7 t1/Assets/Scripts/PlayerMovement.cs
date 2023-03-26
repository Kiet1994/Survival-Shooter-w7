using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed variables
    [SerializeField] private float speed = 500f;
    private Vector3 movement;
    private CharacterAnimation anim;
    private Rigidbody PlayerRigitbody;
    private void Start()
    {
        anim = GetComponent<CharacterAnimation>();
        PlayerRigitbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
 
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // set a float to control horizontal input
        float vertical = Input.GetAxisRaw("Vertical"); // set a float to control vertical input
        PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
        Animating(horizontal, vertical);
    }

    private void PlayerMove(float h, float v)
    {
        movement.Set(h, 0f, v);
        PlayerRigitbody.velocity = movement.normalized * speed * Time.deltaTime;
    }

    private void Animating(float h, float v)
	{
        anim._animRun = h != 0f || v != 0f;
    }
}
