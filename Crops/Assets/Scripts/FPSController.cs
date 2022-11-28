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

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }
    void CameraLook()
    {
        float y = Input.GetAxid("Mouse X") * lookSensitivity;
        rotx += Input.GetAxis("mouse Y") * lookSensitivity;

    }
}
