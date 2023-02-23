using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State1 : MonoBehaviour
{
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld,defaultPosotion;
    bool clickable = false,baking = false;
    

    void Start()
    {
        defaultPosotion = transform.position;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            clickable = true;
        }
        if (Input.GetMouseButton(0)&&clickable)
        {
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);//��ȡ����ڳ���������
            mousePositionOnScreen = Input.mousePosition;//�ó����е�Z=��������Z
            mousePositionOnScreen.z = screenPosition.z;//������е�����ת��Ϊ��������
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
            transform.position = mousePositionInWorld;//�����������ƶ�
        }
        else if(!Input.GetMouseButton(0) && clickable && baking)
        {
            clickable = false;
            State2.state = 2;
        }
        else
        //if(!baking)
        {
            transform.position = defaultPosotion;
            clickable = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oven")
        {
            baking = true;
        }
    }
}