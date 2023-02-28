using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //AKM GULLE
    public float force = 100;
    float acceleration;
    public float mass = 10f;
    private float gravity = -9.81f;
    float speedZ;

    private float gAcceleration;
    private float speedY;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        acceleration = force / mass;
        speedZ += acceleration * Time.deltaTime;

        gAcceleration = gravity / mass;
        speedY += gAcceleration * Time.deltaTime;


        this.transform.Translate(0, speedY, speedZ);
        force = 0;
        
    }
}
