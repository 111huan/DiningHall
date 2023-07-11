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
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);//获取鼠标在场景中坐标
            mousePositionOnScreen = Input.mousePosition;//让场景中的Z=鼠标坐标的Z
            mousePositionOnScreen.z = screenPosition.z;//将相机中的坐标转化为世界坐标
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
            transform.position = mousePositionInWorld;//物体跟随鼠标移动
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
        if (other.gameObject.name == "老头")
        {
            CookingPlot.served1 = true;
        }
        else if (other.gameObject.name == "族长儿子")
        {
            CookingPlot.served2 = true;
        }
        else if (other.gameObject.name == "族长")
        {
            CookingPlot.served3 = true;
        }
    }
}
