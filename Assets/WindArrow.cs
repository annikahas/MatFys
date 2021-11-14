using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArrow : MonoBehaviour
{
    public Wind wind; 

    private void Start()
    {
        
    }
    void Update()
    {
        if (Wind.windNumber < 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        } else if (Wind.windNumber >= 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
        }
    }

}
