using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToneCtl : MonoBehaviour
{
    public Slider slider;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 1.0 / 5)
        {
            sp.color = new Color32(255, 255, 255,255);
           
        }
        else if (slider.value <= 2.0 / 5)
        {
           sp.color = new Color32(243, 226, 211,255);

        }
        else if (slider.value <= 3.0 / 5)
        {
            sp.color = new Color32(185, 165, 155,255);
            
        }
        else if (slider.value <= 4.0 / 5)
        {
            sp.color = new Color32(176, 138, 101,255);
            
        }
        else if (slider.value <= 5.0 / 5)
        {
            sp.color = new Color32(142, 96, 84,255);
        }
    }
}
