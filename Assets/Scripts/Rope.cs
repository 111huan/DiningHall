using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosition;
    bool clickable = true;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            drag();
    }

    void drag()
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
            transform.position = new Vector3(transform.position.x, mousePositionInWorld.y,transform.position.z);//物体跟随鼠标移动
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
        }
        else
        {
            transform.position = defaultPosition;
            clickable = false;
        }
    }
}
