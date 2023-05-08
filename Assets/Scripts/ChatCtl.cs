using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChatCtl : MonoBehaviour
{
    float move = 0,now = 0,speed = 50f;
    [SerializeField] Transform pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10, master;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.anyKeyDown && now < 10)
        {
            now++;
        }
        if (now == 0)
        {
           pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 1f, 0), step);
        }
        else if (now == 1)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 10f, 0), step);
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 1f, 0), step);
            master.position = Vector3.MoveTowards(master.position, new Vector3(4, -1f, 0), step);
        }
        else if (now == 2)
        {
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 10f, 0), step);
            pos3.position = Vector3.MoveTowards(pos3.position, new Vector3(pos3.position.x, 1f, 0), step);
        }
        else if (now == 3)
        {
            pos3.position = Vector3.MoveTowards(pos3.position, new Vector3(pos3.position.x, 10f, 0), step);
            pos4.position = Vector3.MoveTowards(pos4.position, new Vector3(pos4.position.x, 1f, 0), step);
        }
        else if (now == 4)
        {
            pos4.position = Vector3.MoveTowards(pos4.position, new Vector3(pos4.position.x, 10f, 0), step);
            pos5.position = Vector3.MoveTowards(pos5.position, new Vector3(pos5.position.x, 1f, 0), step);
        }
        else if (now == 5)
        {
            pos5.position = Vector3.MoveTowards(pos5.position, new Vector3(pos5.position.x, 10f, 0), step);
            pos6.position = Vector3.MoveTowards(pos6.position, new Vector3(pos6.position.x, 1f, 0), step);
        }
        else if (now == 6)
        {
            pos6.position = Vector3.MoveTowards(pos6.position, new Vector3(pos6.position.x, 10f, 0), step);
            pos7.position = Vector3.MoveTowards(pos7.position, new Vector3(pos7.position.x, 1f, 0), step);
        }
        else if (now == 7)
        {
            pos7.position = Vector3.MoveTowards(pos7.position, new Vector3(pos7.position.x, 10f, 0), step);
            pos8.position = Vector3.MoveTowards(pos8.position, new Vector3(pos8.position.x, 1f, 0), step);
        }
        else if (now == 8)
        {
            ScenesCtl.toDressing();
        }
    }
}
