using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatCtl : MonoBehaviour
{
    float scroll = 0,move = 0,now = 0,speed = 1;
    Transform pos1, pos2, pos3, pos4,pos5,pos6;
    Transform [] pos;
    void Start()
    {
        pos1 = transform.Find("Conv1");
        pos2 = transform.Find("Conv2");
        pos3 = transform.Find("Conv3");
        pos4 = transform.Find("Conv4");
        pos5 = transform.Find("Conv5");
        pos6 = transform.Find("Conv6");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && now < 6)
        {
            now++;
            if (now > 4)
            {
                moveUp();
            }
        }
        if (now == 1)
        {
            float step = speed * Time.deltaTime;
           pos1.position = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0,1.5f, 0), step);
            /*pos1.localScale = new Vector3(0, 0, 0);
            pos2.localScale = new Vector3(0, 0, 0);
            pos3.localScale = new Vector3(0, 0, 0);
            pos4.localScale = new Vector3(0, 0, 0);
            pos5.localScale = new Vector3(0, 0, 0);
            pos6.localScale = new Vector3(0, 0, 0);*/
        }
        else if (now == 2)
        {
            pos1.localScale = new Vector3(1, 1, 0);
            pos2.localScale = new Vector3(1, 1, 0);
            pos3.localScale = new Vector3(0, 0, 0);
            pos4.localScale = new Vector3(0, 0, 0);
            pos5.localScale = new Vector3(0, 0, 0);
            pos6.localScale = new Vector3(0, 0, 0);
        }
        else if (now == 3)
        {
            pos1.localScale = new Vector3(1, 1, 0);
            pos2.localScale = new Vector3(1, 1, 0);
            pos3.localScale = new Vector3(1, 1, 0);
            pos4.localScale = new Vector3(0, 0, 0);
            pos5.localScale = new Vector3(0, 0, 0);
            pos6.localScale = new Vector3(0, 0, 0);
        }
        else if (now == 4)
        {
            pos1.localScale = new Vector3(1, 1, 0);
            pos2.localScale = new Vector3(1, 1, 0);
            pos3.localScale = new Vector3(1, 1, 0);
            pos4.localScale = new Vector3(1, 1, 0);
            pos5.localScale = new Vector3(0, 0, 0);
            pos6.localScale = new Vector3(0, 0, 0);
        }
        else if (now == 5)
        {
            pos1.localScale = new Vector3(1, 1, 0);
            pos2.localScale = new Vector3(1, 1, 0);
            pos3.localScale = new Vector3(1, 1, 0);
            pos4.localScale = new Vector3(1, 1, 0);
            pos5.localScale = new Vector3(1, 1, 0);
            pos6.localScale = new Vector3(0, 0, 0);
        }
        else if (now == 6)
        {
            pos1.localScale = new Vector3(1, 1, 0);
            pos2.localScale = new Vector3(1, 1, 0);
            pos3.localScale = new Vector3(1, 1, 0);
            pos4.localScale = new Vector3(1, 1, 0);
            pos5.localScale = new Vector3(1, 1, 0);
            pos6.localScale = new Vector3(1, 1, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && move >0 && now>4)
        {
            move--;
            moveDown();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && move < now && now >4)
        {
            move++;
            moveUp();
        }
    }

    void moveUp()
    {
        transform.Find("Conv1").position = new Vector3(0, pos1.position.y + 1, 0);
        transform.Find("Conv2").position = new Vector3(0, pos2.position.y + 1, 0);
        transform.Find("Conv3").position = new Vector3(0, pos3.position.y + 1, 0);
        transform.Find("Conv4").position = new Vector3(0, pos4.position.y + 1, 0);
        transform.Find("Conv5").position = new Vector3(0, pos5.position.y + 1, 0);
        transform.Find("Conv6").position = new Vector3(0, pos6.position.y + 1, 0);
    }

    void moveDown()
    {
        transform.Find("Conv1").position = new Vector3(0, pos1.position.y - 1, 0);
        transform.Find("Conv2").position = new Vector3(0, pos2.position.y - 1, 0);
        transform.Find("Conv3").position = new Vector3(0, pos3.position.y - 1, 0);
        transform.Find("Conv4").position = new Vector3(0, pos4.position.y - 1, 0);
        transform.Find("Conv5").position = new Vector3(0, pos5.position.y - 1, 0);
        transform.Find("Conv6").position = new Vector3(0, pos6.position.y - 1, 0);
    }
}
