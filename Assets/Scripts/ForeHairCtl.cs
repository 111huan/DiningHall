using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForeHairCtl : MonoBehaviour
{
    Slider slider;
    float sliderValue;
    public GameObject bh1, bh2, bh3, bh4, bh5;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 1.0 / 5)
        {
            bh1.transform.localScale = new Vector3(1, 1, 1);
            bh2.transform.localScale = new Vector3(0, 1, 1);
            bh3.transform.localScale = new Vector3(0, 1, 1);
            bh4.transform.localScale = new Vector3(0, 1, 1);
            bh5.transform.localScale = new Vector3(0, 1, 1);
        }
        else if (slider.value <= 2.0 / 5)
        {
            bh1.transform.localScale = new Vector3(0, 1, 1);
            bh2.transform.localScale = new Vector3(1, 1, 1);
            bh3.transform.localScale = new Vector3(0, 1, 1);
            bh4.transform.localScale = new Vector3(0, 1, 1);
            bh5.transform.localScale = new Vector3(0, 1, 1);
        }
        else if (slider.value <= 3.0 / 5)
        {
            bh1.transform.localScale = new Vector3(0, 1, 1);
            bh2.transform.localScale = new Vector3(0, 1, 1);
            bh3.transform.localScale = new Vector3(1, 1, 1);
            bh4.transform.localScale = new Vector3(0, 1, 1);
            bh5.transform.localScale = new Vector3(0, 1, 1);
        }
        else if (slider.value <= 4.0 / 5)
        {
            bh1.transform.localScale = new Vector3(0, 1, 1);
            bh2.transform.localScale = new Vector3(0, 1, 1);
            bh3.transform.localScale = new Vector3(0, 1, 1);
            bh4.transform.localScale = new Vector3(1, 1, 1);
            bh5.transform.localScale = new Vector3(0, 1, 1);
        }
        else if (slider.value <= 5.0 / 5)
        {
            bh1.transform.localScale = new Vector3(0, 1, 1);
            bh2.transform.localScale = new Vector3(0, 1, 1);
            bh3.transform.localScale = new Vector3(0, 1, 1);
            bh4.transform.localScale = new Vector3(0, 1, 1);
            bh5.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
