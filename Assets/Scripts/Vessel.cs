using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    bool clickable = true;
    int order;
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosition, dfFull, dfBeau, dfData, dfDataPos;
    // Start is called before the first frame update
    void Start()
    {
        order = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
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
            //gameObject.GetComponent<SpriteRenderer>().sortingOrder += 30;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
            transform.position = defaultPosition;
            clickable = false;
        }
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
