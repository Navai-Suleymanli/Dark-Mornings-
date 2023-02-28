using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystemAim : MonoBehaviour
{
    public GameObject Gun;
    private Gun gun;
    public PlayerManager pullet;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gun.isAuto && pullet.bullet>0)
        {
            animator.SetBool("AimAutoFire", true);
            //StartCoroutine(startRecoilAuto());
            //Gun.GetComponent<Animator>().Play("AKMAUTORECOILanim");
            


        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("AimAutoFire", false);
        }
        if (pullet.bullet <= 0)
        {
            animator.SetBool("AimAutoFire", false);
        }
        if (Input.GetMouseButtonDown(0) && !gun.isAuto)
        {
            StartCoroutine(startRecoil());
            //Gun.GetComponent<Animator>().Play("RecoilAnimation");
            //Gun.GetComponent<Animator>().Play("New State");
        }


    }

    IEnumerator startRecoil()
    {
        if (pullet.bullet!=0)
        {
            Gun.GetComponent<Animator>().Play("akmaimrecoil");
            yield return new WaitForSeconds(0.10f);
            Gun.GetComponent<Animator>().Play("New State");
        }
        
    }
   /* IEnumerator startRecoilAuto()
    {
        if (pullet.bullet!=0)
        {
            Gun.GetComponent<Animator>().Play("AKMAUTORECOILanim");
            yield return new WaitForSeconds(0.10f);
            Gun.GetComponent<Animator>().Play("New State");
        }
       
    }*/
}
