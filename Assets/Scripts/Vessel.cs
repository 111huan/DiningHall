using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.transform.name);
        if (other.gameObject.name == "��ͷ")
        {
            CookingPlot.served1 = true;
        }
        else if (other.gameObject.name == "�峤����")
        {
            CookingPlot.served2 = true;
        }
        else if (other.gameObject.name == "�峤")
        {
            CookingPlot.served3 = true;
        }
    }
}
