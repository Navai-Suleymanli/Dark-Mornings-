using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge : MonoBehaviour
{
    public Rigidbody catridgeRb;



    // Update is called once per frame
    void Update()
    {
        catridgeRb.AddForce(Vector3.forward * Time.deltaTime * 20, ForceMode.Impulse);
    }
}
