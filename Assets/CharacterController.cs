using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update

    float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    public float jumpForce = 300.0f;

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;

    Animator myAnim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myAnim = GetComponentInChildren<Animator>();
        
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();

        musicPlayer.clip = backgroundMusic;
        musicPlayer.loop = true;
        musicPlayer.Play();
        

      //locking cursor and making it non vissable
        //Cursor.visible = false;
        
    }

    
    public float maxSpeed = 1.0f;
    public float rotation = 0.0f;
// Update is called once per frame

    void Update()
    {

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        myAnim.SetBool("isOnGround", isOnGround);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("jumped");
            myRigidbody.AddForce(transform.up * jumpForce);
        }
        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myAnim.SetFloat("speed", newVelocity.magnitude);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

    }
}
