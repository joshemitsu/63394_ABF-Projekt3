using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.08f;

    private Rigidbody rb;
    private Camera camera;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        camera = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //Vector3 movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, Input.GetAxis("Vertical") * speed);
        Vector3 movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * new Vector3(horizontalMovement * speed, 0.0f, verticalMovement * speed);

        //rb.AddForce(movement * speed);
        gameObject.transform.Translate(movement);
    }
}
