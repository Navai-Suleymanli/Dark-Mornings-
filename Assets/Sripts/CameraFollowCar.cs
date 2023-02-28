using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{
    public Transform sedan;
    private Rigidbody sedanRB;
    public Vector3 Offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sedanRB = sedan.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerForward = (sedanRB.velocity + sedanRB.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position,
            sedan.position + sedan.transform.TransformVector(Offset)
            + playerForward * (-5f),
            speed * Time.deltaTime);
        transform.LookAt(sedan);
    }
}