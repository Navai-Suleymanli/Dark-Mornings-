using UnityEngine;
using System.Collections;


public class Gun : MonoBehaviour
{
    public float damage = 35f;
    public float shootRange = 100f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject impactEffectBlood;
    public GameObject fpsCam;
    public float fireRate = 10f;
    public float impactForce = 30;
    //public Animator animator;
    public bool hitt = false;
    public Camera cam;


    private float nextTimeToShoot;

    public bool isAuto;

    public AudioClip gunSound;
    public AudioClip emptySound;
    private AudioSource playerAudio;

    public GameObject shell;
   // public GameObject cartridge;
    public GameObject gulle1;
    //public GameObject cixanYer;

    public PlayerManager pullet;

    Animator otherAnimator;





    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        

        

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToShoot && isAuto && pullet.bullet>=1)
        {
            
            nextTimeToShoot = Time.time + 1f / fireRate;
            Shoot();
            pullet.bullet-= 2;
            if (pullet.bullet % 2 != 0)
            {
                pullet.bullet --;
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAuto && pullet.bullet > 0)
        {
            Shoot();
            pullet.bullet--;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && pullet.bullet <=0)
        {

            emptyShot();
        }

        if (Input.GetKeyDown(KeyCode.V) && isAuto)
        {
            isAuto = false;
        }
        else if (Input.GetKeyDown(KeyCode.V) && isAuto == false)
        {
            isAuto = true;
        }
       
    }

   

 



    private void emptyShot()
    {
        playerAudio.PlayOneShot(emptySound, 1f);
    }

    private void Shoot()
    {
        muzzleFlash.Play();


        var cloneShell = Instantiate(shell, gulle1.transform.position, gulle1.transform.rotation);


       
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, shootRange))
        {
            Debug.Log(hit.transform.name);

            //can aparma
            target target1 = hit.transform.GetComponent<target>();
            if (target1 != null)
            {
                
                
                target1.TakeDamage(damage);
            }

            if (hit.transform.tag == "Enemy")
            {
                GameObject impactBlood = Instantiate(impactEffectBlood, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactBlood, 2f);

            }
            else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }

            //vurduqdan sonra itelemek
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
      
            

            //deydiyi yerden effect cixmasi
            
        }
        playerAudio.PlayOneShot(gunSound, 1f);

        Destroy(cloneShell, 3f);
    }
}
