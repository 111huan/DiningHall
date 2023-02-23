using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State3 : MonoBehaviour
{
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosotion;
    bool clickable = false, inCustomer = false;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosotion = transform.position;
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("state=" + State2.state);
        if (State2.state == 3)//��ʾ
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
            else if (!Input.GetMouseButton(0) && clickable && inCustomer)
            {
                clickable = false;
                State2.state = 1;
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
        if (collision.gameObject.tag == "Customer")
        {
            inCustomer = true;
            Debug.Log("111");
        }
    }
}
