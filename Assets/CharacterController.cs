using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update

    float camRotation = 0.0f;
    GameObject cam;

    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;


    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame

    float maxSpeed = 1.0f;
    float rotation = 0.0f;
    void Update()
    {
        transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical"));

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
    }
}
