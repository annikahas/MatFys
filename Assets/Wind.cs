using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wind : MonoBehaviour
{
    public TMP_Text windText;
    public static int windNumber;

    public void RandomNumber()
    {
        windNumber = Random.Range(-5, 6);
        windText.text = windNumber.ToString();
    }
}
