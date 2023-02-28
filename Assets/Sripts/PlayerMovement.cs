using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speedSprint = 15f;
    public float speed = 6f;
    public float speedAim = 2f;
    public float gravity = -9.81f;

    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float jumpHeight = 3f;
    public GameObject gun;
    public GameObject gunAim;
    public GameObject pointL1;
    public GameObject pointL2;
    public bool isFlashLightActive = false;



    public float health = 100f;

    Vector3 velocity;

    bool isOnGround;

   

    // Update is called once per frame
    void Update()
    {


        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // eger yerde olsa
        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;



        // hoppanmaq ucun fizika dusturu
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            velocity.y = Mathf.Sqrt(-0.5f * jumpHeight * gravity);
        }

        // cazibe ucun fizika dusturu
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); // asagi dusmeyi ucun

        if (Input.GetKey(KeyCode.Mouse1))
        {
            gun.SetActive(false);
            gunAim.SetActive(true);
            controller.Move(move * speedAim * Time.deltaTime); // gezmeyi ucun
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            gun.SetActive(true);
            gunAim.SetActive(false);
            controller.Move(move * speedSprint * Time.deltaTime); // gezmeyi ucun
        }
        else
        {
            gun.SetActive(true);
            gunAim.SetActive(false);
            controller.Move(move * speed * Time.deltaTime); // gezmeyi ucun

        }

        if (Input.GetKeyDown(KeyCode.F) && isFlashLightActive == false)
        {
            pointL1.SetActive(true);
            pointL2.SetActive(true);
            isFlashLightActive = true;
        }else if(Input.GetKeyDown(KeyCode.F) && isFlashLightActive == true)
        {
            pointL1.SetActive(false);
            pointL2.SetActive(false);
            isFlashLightActive = false;
        }
    }


    
}
