using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Piano : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject pianocu;
    public bool basi = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float pianoDistance = Vector3.Distance(player.transform.position, this.transform.position);

        if (pianoDistance <= 5 && !basi && Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
            pianocu.SetActive(true);
            StartCoroutine(PianoStop());
            basi = true;
           
            
        }
    }

    IEnumerator PianoStop()
    {
        yield return new WaitForSeconds(179);
        player.SetActive(true);
        Destroy(pianocu);
        

    }
}
