using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPlot : MonoBehaviour
{
    [SerializeField] Transform man ,bigMan,square,player,boy,bigBoy,master,bigMaster;
    [SerializeField] Transform pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10,pos11,pos12,pos13,pos14,pos15,pos16,pos17,pos18,pos19;
    public static bool served1 = false, served2 = false, served3 = false;
    int now = 0;
    float speed = 5f, step = 0, speed1 = 50f, step1 = 0;
    public static int order = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("传送").transform;
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 50;
        player.position = new Vector3(-20f, 0, 0);
        player.localScale = new Vector3(-0.45f,0.45f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(order);
        step = speed * Time.deltaTime;
        step1 = speed1 * Time.deltaTime;
        if (order == 0)
        {
            plotStart();
            if (man.position.x < 3.1)
            {
                order++;
            }
        }
        else if(order == 1)
        {
            Invoke("plot1", 0.5f);
            order++;
        }
        else if(order == 2)
        {
            if (bigMan.position.x <= 7.1)
            {
                Invoke("method", 1f);
                chat();
            }
            
        }
        else if(order == 3)
        {
            if (served1)
            {
                now = 0;
                order++;
            }
        }
        else if(order == 4)
        {
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.78f);
            //�������
            bigMan.position = new Vector3(7f, bigMan.position.y, 0);
            player.position = new Vector3(-9f, player.position.y, 0);
            if (player.position.x <= 7.1f)
            {
                chat2();
            }
        }
        else if(order == 5)
        {
            boy.position = Vector3.MoveTowards(boy.position, new Vector3(3f, boy.position.y, 0), step);
            if (boy.position.x <= 3.1f)
            {
                now = 0;
                order++;
            }
        }
        else if(order == 6)
        {
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.78f);
            //�������
            bigBoy.position = new Vector3(7f, bigBoy.position.y, 0);
            player.position = new Vector3(-9f, player.position.y, 0);
            if (player.position.x <= 9.1f)
            {
                chat3();
            }
        }
        else if (order == 7)
        {
            if (served2)
            {
                now = 0;
                order++;
            }
        }
        else if (order == 8)
        {
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.78f);
            //�������
            bigBoy.position = new Vector3(7f, bigBoy.position.y, 0);
            player.position = new Vector3(-9f, player.position.y, 0);
            if (player.position.x <= 9.1f)
            {
                chat4();
            }
        }
        else if (order == 9)
        {
            master.position = Vector3.MoveTowards(master.position, new Vector3(0f, master.position.y, 0), step);
            if (master.position.x <= 0.1f)
            {
                now = 0;
                order++;
            }
        }
        else if (order == 10)
        {
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.78f);
            //�������
            bigMaster.position = new Vector3(4f, bigMaster.position.y, 0);
            player.position = new Vector3(-9f, player.position.y, 0);
            if(bigMaster.position.x <= 4.1f)
            {
                //Debug.Log("aaaaaa");
                chat5();
            }
        }
        else if (order == 11)
        {
            if (served3)
            {
                now = 0;
                order++;
            }
        }
        else if (order == 12)
        {
            
        }
    }

    void plotStart()
    {
        man.position = Vector3.MoveTowards(man.position, new Vector3(3f, man.position.y, 0), step);
    }

    void plot1()
    {
        int cov = 0;
        //��ʾ�ɰ�
        square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.78f);
        //�������
        bigMan.position = new Vector3(7f, bigMan.position.y, 0);
        player.position = new Vector3(-9f, player.position.y, 0);
    }

    void chat()
    {
        pos1.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos2.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos3.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos4.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos5.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        if (Input.anyKeyDown && now<=10)
        {
            now++;
        }
        if (now == 0)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 2, 0), step1);
        }
        else if (now == 1)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 20f, 0), step1);
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 1f, 0), step1);
        }
        else if (now == 2)
        {
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 20f, 0), step1);
            pos3.position = Vector3.MoveTowards(pos3.position, new Vector3(pos3.position.x, 1f, 0), step1);
        }
        else if (now == 3)
        {
            pos3.position = Vector3.MoveTowards(pos3.position, new Vector3(pos3.position.x, 20f, 0), step1);
            pos4.position = Vector3.MoveTowards(pos4.position, new Vector3(pos4.position.x, 1f, 0), step1);
        }
        else if (now == 4)
        {
            pos4.position = Vector3.MoveTowards(pos4.position, new Vector3(pos4.position.x, 20f, 0), step1);
            pos5.position = Vector3.MoveTowards(pos5.position, new Vector3(pos5.position.x, 1f, 0), step1);
        }
        else if(now == 5)
        {
            Debug.Log("aaaa");
            pos5.position = new Vector3(pos5.position.x, 20f, 0);
            bigMan.position = new Vector3(20f, bigMan.position.y, 0);
            player.position = new Vector3(-20f, player.position.y, 0);
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            order++;
        }
    }

    void chat2()
    {
        pos6.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos7.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        if (Input.anyKeyDown && now <= 2)
        {
            now++;
        }
        if (now == 0)
        {
            pos6.position = Vector3.MoveTowards(pos6.position, new Vector3(pos6.position.x, 2, 0), step1);
        }
        else if (now == 1)
        {
            pos6.position = Vector3.MoveTowards(pos6.position, new Vector3(pos6.position.x, 20f, 0), step1);
            pos7.position = Vector3.MoveTowards(pos7.position, new Vector3(pos7.position.x, 1f, 0), step1);
        }
        else if (now == 2)
        {
            pos7.position = new Vector3(pos7.position.x, 20f, 0);
            bigMan.position = new Vector3(20f, bigMan.position.y, 0);
            player.position = new Vector3(-20f, player.position.y, 0);
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            man.position = Vector3.MoveTowards(man.position, new Vector3(-20f, man.position.y, 0), step);
            if (man.position.x <= -19.9f)
            {
                order++;
            }
        }
    }

    void chat3()
    {
        pos8.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos9.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos10.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        if (Input.anyKeyDown && now <= 3)
        {
            now++;
        }
        if (now == 0)
        {
            pos8.position = Vector3.MoveTowards(pos8.position, new Vector3(pos8.position.x, 2, 0), step1);
        }
        else if (now == 1)
        {
            pos8.position = Vector3.MoveTowards(pos8.position, new Vector3(pos8.position.x, 20f, 0), step1);
            pos9.position = Vector3.MoveTowards(pos9.position, new Vector3(pos9.position.x, 1f, 0), step1);
        }
        else if (now == 2)
        {
            pos9.position = Vector3.MoveTowards(pos9.position, new Vector3(pos9.position.x, 20f, 0), step1);
            pos10.position = Vector3.MoveTowards(pos10.position, new Vector3(pos10.position.x, 1f, 0), step1);
        }
        else if (now == 3)
        {
            pos10.position = Vector3.MoveTowards(pos10.position, new Vector3(pos10.position.x, 20f, 0), step1);
            if (pos10.position.y >= 19.9f)
            {
                bigBoy.position = new Vector3(20f, bigMan.position.y, 0);
                player.position = new Vector3(-20f, player.position.y, 0);
                square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                order++;
            }
        }
    }

    void chat4()
    {
        pos11.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos12.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        if (Input.anyKeyDown && now < 2)
        {
            now++;
        }
        if (now == 0)
        {
            pos11.position = Vector3.MoveTowards(pos11.position, new Vector3(pos11.position.x, 2, 0), step1);
        }
        else if (now == 1)
        {
            pos11.position = Vector3.MoveTowards(pos11.position, new Vector3(pos11.position.x, 20f, 0), step1);
            pos12.position = Vector3.MoveTowards(pos12.position, new Vector3(pos12.position.x, 1f, 0), step1);
        }
        else if (now == 2)
        {
            pos12.position = new Vector3(pos12.position.x, 20f, 0);
            bigBoy.position = new Vector3(20f, bigBoy.position.y, 0);
            player.position = new Vector3(-20f, player.position.y, 0);
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            boy.position = Vector3.MoveTowards(man.position, new Vector3(-20f, man.position.y, 0), step);
            if (boy.position.x <= 19.9f)
            {
                order++;
            }
        }
    }

    void chat5()
    {
        pos13.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos14.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos15.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos16.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos17.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos18.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        pos19.gameObject.GetComponent<MeshRenderer>().sortingOrder = 34;
        if (Input.anyKeyDown && now < 7)
        {
            now++;
        }
        if (now == 0)
        {
            pos13.position = Vector3.MoveTowards(pos13.position, new Vector3(pos13.position.x, 2, 0), step1);
        }
        else if (now == 1)
        {
            pos13.position = Vector3.MoveTowards(pos13.position, new Vector3(pos13.position.x, 20f, 0), step1);
            pos14.position = Vector3.MoveTowards(pos14.position, new Vector3(pos14.position.x, 1f, 0), step1);
        }
        else if (now == 2)
        {
            pos14.position = Vector3.MoveTowards(pos14.position, new Vector3(pos14.position.x, 20f, 0), step1);
            pos15.position = Vector3.MoveTowards(pos15.position, new Vector3(pos15.position.x, 1f, 0), step1);
        }
        else if (now == 3)
        {
            pos15.position = Vector3.MoveTowards(pos15.position, new Vector3(pos15.position.x, 20f, 0), step1);
            pos16.position = Vector3.MoveTowards(pos16.position, new Vector3(pos16.position.x, 1f, 0), step1);
        }
        else if (now == 4)
        {
            pos16.position = Vector3.MoveTowards(pos16.position, new Vector3(pos16.position.x, 20f, 0), step1);
            pos17.position = Vector3.MoveTowards(pos17.position, new Vector3(pos17.position.x, 1f, 0), step1);
        }
        else if (now == 5)
        {
            pos17.position = Vector3.MoveTowards(pos17.position, new Vector3(pos17.position.x, 20f, 0), step1);
            pos18.position = Vector3.MoveTowards(pos18.position, new Vector3(pos18.position.x, 1f, 0), step1);
        }
        else if (now == 6)
        {
            pos18.position = Vector3.MoveTowards(pos18.position, new Vector3(pos18.position.x, 20f, 0), step1);
            pos19.position = Vector3.MoveTowards(pos19.position, new Vector3(pos19.position.x, 1f, 0), step1);
        }
        else if (now == 7)
        {
            pos19.position = new Vector3(pos19.position.x, 20f, 0);
            bigMaster.position = new Vector3(20f, bigMaster.position.y, 0);
            player.position = new Vector3(-20f, player.position.y, 0);
            square.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            order++;
        }
    }
    void method()
    {

    }
}
