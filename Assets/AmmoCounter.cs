using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TMP_Text ammoText;
    public Text ammoText2;

    public int ammo = 10;
    public int maxAmmo = 10;
    
    void Start()
    {
        ammoText2.text = ammo.ToString() + "/10";
    }

    // Update is called once per frame
    void Update()
    {
        //ammoText.text = ammo.ToString();
    }

    public void ReduceAmmo(int number)
    {       
        if (ammo > 0)
        {
            ammo -= number;
            ammoText2.text = ammo.ToString() + "/10";
        }
    }

    public void MaxAmmo()
    {
        ammo = maxAmmo;
        ammoText2.text = ammo.ToString() + "/10";
    }
}
