using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosition;
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
        if (Input.GetMouseButton(0))
        {
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);//获取鼠标在场景中坐标
            mousePositionOnScreen = Input.mousePosition;//让场景中的Z=鼠标坐标的Z
            mousePositionOnScreen.z = screenPosition.z;//将相机中的坐标转化为世界坐标
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
            transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0);//物体跟随鼠标移动
        }
    }

}
