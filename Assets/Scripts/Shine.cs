using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    bool clickable = true;
    int order = 0;
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosition, dfFull, dfBeau, dfData, dfDataPos;
    [SerializeField] GameObject meat1,meat2,meat3,bowl,plat,pot;

    float alpha = 1f;
    bool isTrans = true;
    float transSpeed = 0.02f;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        //order = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(state == 0)
        {
            shine(meat1);
            if (meat1.GetComponent<Cook>().shining)
            {
                meat1.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
                shine(plat);
            }
        }*/
        move();
    }

    void move()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);//获取鼠标在场景中坐标
            mousePositionOnScreen = Input.mousePosition;//让场景中的Z=鼠标坐标的Z
            mousePositionOnScreen.z = screenPosition.z;//将相机中的坐标转化为世界坐标
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        if (meat1.GetComponent<Cook>().shining) 
        {
            Debug.Log(111);
            shine(plat);
        }
        else if (meat2.GetComponent<Cook>().shining)
        {
            shine(pot);
        }
        else if (meat3.GetComponent<Cook>().shining)
        {
            shine(bowl);
        }
        else
        {
            pot.GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f);
            plat.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
            bowl.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f);
        }
    }

    void shine(GameObject obj)
    {
        if (alpha >= 1)
        {
            isTrans = true;
            alpha = 1;
        }
        if (isTrans)
        {
            alpha -= transSpeed * Time.deltaTime * 60;
        }
        if (alpha <= 0)
        {
            isTrans = false;
            alpha = 0;
        }
        if (!isTrans)
        {
            alpha += transSpeed * Time.deltaTime * 30;
        }
        
        obj.GetComponent<SpriteRenderer>().material.color = new Color(obj.GetComponent<SpriteRenderer>().material.color.r, obj.GetComponent<SpriteRenderer>().material.color.g, obj.GetComponent<SpriteRenderer>().material.color.b, alpha);
    }
}
