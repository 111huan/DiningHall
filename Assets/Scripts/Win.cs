using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    int order = 0;
    [SerializeField] Transform square, pos1, pos2, pos3, box1, box2, debri;
    float speed = 5f;
    float step = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(order);
        step = speed * Time.deltaTime;
        if (order == 0)
        {
            Invoke("plot1", 1.5f);
           
            if (box2.position.y >= 1.8f)
            {
                order++;
            }
        }
        else if(order == 1)
        {
            Invoke("openBox", 1f);
            /*box1.position = new Vector3(0, -3, 0);
            box2.position = new Vector3(0, 3, 0);*/
            if (box1.position.y <= -3f)
            {
                order++;
            }
        }
        else if(order == 2)
        {

        }
    }
        

    void plot1()
    {
        square.gameObject.GetComponent<SpriteRenderer>().color =
          new Color(square.gameObject.GetComponent<SpriteRenderer>().color.r,
          square.gameObject.GetComponent<SpriteRenderer>().color.g,
          square.gameObject.GetComponent<SpriteRenderer>().color.b, 0.8f);
        pos1.localScale = new Vector3(0, 0, 0);
        pos2.localScale = new Vector3(0, 0, 0);
        pos3.localScale = new Vector3(0, 0, 0);
        Invoke("method", 1f);
        box1.position = Vector3.MoveTowards(box1.position, new Vector3(0, 0, 0), step);
        box2.position = Vector3.MoveTowards(box2.position, new Vector3(0, 1.8f, 0), step);
        debri.position = new Vector3(box2.position.x, box2.position.y - 1, 0);
    }

    

    void openBox()
    {
        box1.position = Vector3.MoveTowards(box1.position, new Vector3(0, -3, 0), step);
        box2.position = Vector3.MoveTowards(box2.position, new Vector3(0, 3, 0), step);
        /*box1.position = new Vector3(0, -3, 0);
        box2.position = new Vector3(0, 3, 0);*/
    }

    void method()
    {

    }
}
