using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pianocu : MonoBehaviour
{
    Animator animator;
    //[SerializeField] GameObject player;
    private AudioSource pianoAudio;

    // Start is called before the first frame update
    void Start()
    {
        pianoAudio = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();

        StartCoroutine(PianoPlay());
    }

    IEnumerator PianoPlay()
    {
        yield return new WaitForSeconds(10);
        animator.SetBool("Pianocu", true);
        pianoAudio.Play();
    }
}
