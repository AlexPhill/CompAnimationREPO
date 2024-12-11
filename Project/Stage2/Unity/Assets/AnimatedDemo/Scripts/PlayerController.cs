using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    //player's speed
    public float moveSpeed = 10f;

    //player's rotation speed
    public float rotateSpeed = 75f;
    private float vertInput;
    private float horInput;
    private CapsuleCollider _col;
    private Rigidbody _rb;


    public Animator animator;
    bool _isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //W & S keys 
        vertInput = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else { 
            animator.SetBool("isRunning", true);
        }
        //A & D keys
        horInput = Input.GetAxis("Horizontal") * rotateSpeed;

        /*        if (_rb.velocity.magnitude > 0 )
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }*/
    }

    private void FixedUpdate()
    {
        Vector3 rotationVar = Vector3.up * horInput;
        //controls our angle using quaternions
        Quaternion angleRotation = Quaternion.Euler(rotationVar * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vertInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRotation);
    }
}
