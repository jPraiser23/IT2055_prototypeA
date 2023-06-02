using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float steerSpeed = 20;
    public float shiftMultiplier = 2;
    public float jumpSpeed = 5 ;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        float steerValue = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float gasValue =     Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Shift Key Accelerates
        if(Input.GetKey(KeyCode.LeftShift)){
          gasValue = gasValue * shiftMultiplier;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,jumpSpeed,0), ForceMode.Impulse);
        }

        Vector3 positionChange = Vector3.forward * gasValue;

        // positionChange += Vector3.right * steerValue;
        transform.Rotate(Vector3.up, steerValue);
        transform.Translate(positionChange);
    }
}
