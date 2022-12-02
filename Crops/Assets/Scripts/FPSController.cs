using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Player stats")]
    public float moveSpeed;
    public float jumpForce;
    [Header("camera info")]
    public float lookSensitivity;
    public float maxLookx;
    public float minLookx;
    public float rotx;
    [Header("private variables")]
    private Camera camera;
    private Rigidbody rb;

    void Awake()
    {
        //get components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        //Freeze and disable cusor
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraLook();

        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        //moveSpeed layer in realatoon to the camera direction
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }
    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotx = Mathf.Clamp(rotx, minLookx, maxLookx);// clamp verticle rotation of hte player so player dosent do front flips and stuff
        // applies rotation to player
        camera.transform.localRotation = Quaternion.Euler(-rotx, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
    void PlayerJump()
    {
        //ray cast for ground detection
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
    public void GiveHealth(int amount)
    {

    }
    public void GiveAmmo(int amount)
    {

    }
}
