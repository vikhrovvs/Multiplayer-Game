using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class MoveController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 1f;

    public Transform camera;

    Vector3 direction;
    Rigidbody myRigidbody;

    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody> ();
    }

    //private Vector3 moveInput;
    //private Vector3 cameraForward;
    void Update()
    {
        //cameraForward = camera.forward;
        //moveInput = new Vector3 (cameraForward.x * Input.GetAxisRaw ("Horizontal"), 0, forward.z * Input.GetAxisRaw("Vertical"));
        direction = camera.forward * Input.GetAxisRaw("Vertical") + camera.right * Input.GetAxisRaw("Horizontal");
        transform.localEulerAngles = new Vector3(0f , camera.rotation.eulerAngles.y , 0f);
        
        myRigidbody.MovePosition (myRigidbody.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);

        if(Input.GetKeyDown(KeyCode.Space)) myRigidbody.AddForce(transform.up * 100);
        //moveVelocity = moveInput.normalized * moveSpeed;
    }
}