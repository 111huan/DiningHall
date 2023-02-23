using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State2 : MonoBehaviour
{
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosotion;
    bool clickable = false, inBowl = false;
    public static int state = 1;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosotion = transform.position;
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 2)//��ʾ
        {
            transform.localScale = new Vector3(1, 1, 1);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                clickable = true;
            }
            if (Input.GetMouseButton(0) && clickable)
            {
                screenPosition = Camera.main.WorldToScreenPoint(transform.position);//��ȡ����ڳ���������
                mousePositionOnScreen = Input.mousePosition;//�ó����е�Z=��������Z
                mousePositionOnScreen.z = screenPosition.z;//������е�����ת��Ϊ��������
                mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
                transform.position = mousePositionInWorld;//�����������ƶ�
            }
            else if (!Input.GetMouseButton(0) && clickable && inBowl)
            {
                clickable = false;
                state = 3;
            }
            else
            //if(!baking)
            {
                transform.position = defaultPosotion;
                clickable = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(0, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bowl")
        {
            inBowl = true;
        }
    }
}
