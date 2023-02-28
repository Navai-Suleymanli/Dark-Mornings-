using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;
    public int health = 100;

    public GameObject zombie;

    //dusmenler
    [SerializeField] Transform dusmen1;
    [SerializeField] Transform dusmen2;

    //piano
    //[SerializeField] Transform piano;

    [SerializeField] bool d1Dirildi = false;
    [SerializeField] bool d2Dirildi = false;


    // reload system
    public int bullet = 30;
    public TextMeshProUGUI bulletText;
    Gun gun;

    

    private void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        float distance = Vector3.Distance(dusmen1.transform.position, this.transform.position);
        
        if (distance <= 30 && !d1Dirildi)
        {
            Instantiate(zombie, dusmen1.transform.position, dusmen1.transform.rotation);
            d1Dirildi = true;
        }
        

        float distance2 = Vector3.Distance(dusmen2.transform.position, this.transform.position);

        if (distance2 <= 30 && !d2Dirildi)
        {
            Instantiate(zombie, dusmen2.transform.position, dusmen2.transform.rotation);
            d2Dirildi = true;
        }

        bulletText.text = "Bullet :" + bullet + "  (R to reload)";

    }



    #endregion

    public GameObject player;
}
