using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderCtl : MonoBehaviour
{
    Toggle tg;
    public GameObject body, body1;
    // Start is called before the first frame update
    void Start()
    {
        tg = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tg.isOn)
        {
            body.transform.localScale = new Vector3(0, 0, 0);
            body1.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            body1.transform.localScale = new Vector3(0, 0, 0);
            body.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
