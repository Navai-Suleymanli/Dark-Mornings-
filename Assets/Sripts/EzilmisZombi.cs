using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzilmisZombi : MonoBehaviour
{

    public Animator animator;
    private target target;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target.health <=0)
        {
            animator.SetBool("Death", true);
            
        }
       
    }
}
