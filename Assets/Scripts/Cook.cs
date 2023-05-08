using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Cook : MonoBehaviour
{
    public static int mark = 0;
    [SerializeField] Transform des = null,data = null;
    [SerializeField] Slider slider = null;
    public TextMeshPro beau = null, full = null;
    [SerializeField] Color colorStart = Color.white, colorEnd = Color.white;
    [SerializeField] GameObject[] neighbor = null;
    [SerializeField] string name = null;
    [SerializeField] float beauty = 0, fullness = 0, flavor = 0, time = 0;
    [SerializeField] bool colorChangable = false;
    Collider2D collider = null;
    int order = 0, parentOrder = 0;
    int[] sisOrder;
    string next1 = null, next2 = null;
    bool ready = false, clickable = false, wait4Release = false;
    [SerializeField]public bool isOn = false;//用来控制烤煮切显形，isOn则透明度为1，否则为0，不能进行拖动
    Vector3 screenPosition, mousePositionOnScreen, mousePositionInWorld, defaultPosition, dfFull, dfBeau, dfData, dfDataPos;
    float duration = 15f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Competition")
        {
            data = transform.Find("data");
            data.localPosition = new Vector3(-0.8f, -1, 0);
            beau = data.Find("beauty").gameObject.GetComponent<TextMeshPro>();
            full = data.Find("full").gameObject.GetComponent<TextMeshPro>();
            dfBeau = beau.transform.localScale;
            dfFull = beau.transform.localScale;
            dfData = data.localScale;
            data.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            beau.gameObject.GetComponent<MeshRenderer>().sortingOrder = 30;
            full.gameObject.GetComponent<MeshRenderer>().sortingOrder = 30;
        }
        /*if (gameObject.tag == "meatInPlate" || gameObject.tag == "meatInBowl" || gameObject.tag == "mrInPlate"
                || gameObject.tag == "mrInBowl" || gameObject.tag == "vgInPlate"
                || gameObject.tag == "vgInBowl" || gameObject.tag == "frInBowl")
        {
            parentOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            parentDefault = transform.parent.position;
            for (int i = 0; i <= transform.parent.childCount; i++)
            {
                Debug.Log(transform.parent.gameObject.GetComponent<Transform>().name);
                sisOrder[i] = transform.parent.gameObject.GetComponentsInChildren<SpriteRenderer>()[i].sortingOrder;
            }
        }*/
        order = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        defaultPosition = transform.position;
        if (name == "rawMeat")
        {
            set(0, 0, 0, "dicedMeat", null,false);
        }
        else if(name == "dicedMeat")
        {
            set(0, 0, 0, "bakedMeat", "boiledMeat", false);
        }
        else if(name == "bakedMeat")
        {
            set(0, 0, 0, "meatInPlate", null, false);
        }
        else if (name == "boiledMeat")
        {
            set(0, 0, 0, "meatInBowl", null, false);
        }
        else if (name == "meatInPlate")
        {
            set(0, 0, 0, "customer", null,true);
        }
        else if (name == "meatInBowl")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if (name == "mr")
        {
            set(0, 0, 0, "dicedMr", null, false);
        }
        else if (name == "dicedMr")
        {
            set(0, 0, 0, "bakedMr", "boiledMr", false);
        }
        else if (name == "bakedMr")
        {
            set(0, 0, 0, "mrInPlate", null, false);
        }
        else if (name == "boiledMr")
        {
            set(0, 0, 0, "mrInBowl", null, false);
        }
        else if (name == "mrInPlate")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if (name == "mrInBowl")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if (name == "vg")
        {
            set(0, 0, 0, "dicedVg", null, false);
        }
        else if (name == "dicedVg")
        {
            set(0, 0, 0,  "boiledVg", "vgInPlate", false);
        }
        else if (name == "boiledVg")
        {
            set(0, 0, 0, "vgInBowl", null, false);
        }
        else if (name == "vgInPlate")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if (name == "vgInBowl")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if (name == "fr")
        {
            set(0, 0, 0, "boiledFr", null, true);
        }
        else if (name == "boiledFr")
        {
            set(0, 0, 0, "frInBowl", null, true);
        }
        else if (name == "frInBowl")
        {
            set(0, 0, 0, "customer", null, true);
        }
        else if(name == "mr2")
        {
            set(0, 0, 0, "bakedMr2", null, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Competition")
        {
            dataCtl();
        }
        if(mark == 10)
        {
            SceneManager.LoadScene("Win");
        }
        if (!ScenesCtl.pausing)
        {
            if (isOn)
            {              
                gameObject.layer = 0;
                if (name != "bakedMr3")
                {
                    move();
                }
                else{
                    transform.position = des.position;  
                }
                change2NextState(); 
                if (colorChangable && name != "bakedMr3")
                {
                    Vector3 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
                    slider.transform.position = player2DPosition + new Vector3(0, 40f, 0);
                    colorChange();
                }
            }
            else
            {
                gameObject.layer = 2;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(
                   gameObject.GetComponent<SpriteRenderer>().color.r,
                   gameObject.GetComponent<SpriteRenderer>().color.g,
                   gameObject.GetComponent<SpriteRenderer>().color.b,
                   0f);
                if (colorChangable)
                {
                    slider.value = 1f;
                    slider.transform.position = new Vector3(-1000, 1000, 0);
                }
            }
            if (name == "rawMeat" || name == "mr" || name == "vg" || name == "fr" || name == "mr2")
            {

                isOn = true;
            }
        }
    }

    void dataCtl()
    {
        if (isOn)
        {
            beau.transform.localScale = dfBeau;
            full.transform.localScale = dfFull;
            data.localScale = dfData;
        }
        else
        {
            beau.transform.localScale = new Vector3(0, 0, 0);
            full.transform.localScale = new Vector3(0, 0, 0);
            data.localScale = new Vector3(0, 0, 0);
        }
        if(name == "boiledMeat"|| name== "boiledMr"|| name == "boiledVg"|| name == "boiledFr")
        {
            beau.text = (10 + 1 - slider.value).ToString("0.0");
            full.text = (10 - 1 + slider.value).ToString("0.0");
        }
        else if(name == "bakedMeat" || name == "bakedMr")
        {
            full.text = (10 - slider.value).ToString("0.0");
            beau.text = (10 - 1 + slider.value).ToString("0.0");
        }
    }
    void move()
    {
        /*RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
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

            if (gameObject.tag == "meatInPlate" || gameObject.tag == "meatInBowl" || gameObject.tag == "mrInPlate"
                || gameObject.tag == "mrInBowl" || gameObject.tag == "vgInPlate"
                || gameObject.tag == "vgInBowl" || gameObject.tag == "frInBowl")
            {
                transform.parent.position = mousePositionInWorld;
                transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder = parentOrder + 30;
                for (int i = 0; i <= transform.parent.childCount; i++)
                {
                    transform.parent.GetComponentsInChildren<SpriteRenderer>()[i].sortingOrder = sisOrder[i] + 30;
                }
            }
            else
            {
                transform.position = mousePositionInWorld;//物体跟随鼠标移动
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = order + 30;
            }
        }
        else
        {
            clickable = false;
            if (gameObject.tag == "meatInPlate" || gameObject.tag == "meatInBowl" || gameObject.tag == "mrInPlate"
                || gameObject.tag == "mrInBowl" || gameObject.tag == "vgInPlate"
                || gameObject.tag == "vgInBowl" || gameObject.tag == "frInBowl")
            {
                transform.parent.position = parentDefault;
                transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder = parentOrder;
                for (int i = 0; i <= transform.parent.childCount; i++)
                {
                    Debug.Log(transform.parent.GetComponentsInChildren<SpriteRenderer>()[i].sortingOrder);
                    *//*transform.parent.GetComponentsInChildren<SpriteRenderer>()[i].sortingOrder = sisOrder[i];*//*
                }
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
                transform.position = defaultPosition;
            }

        }*/

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
            gameObject.GetComponent<SpriteRenderer>().sortingOrder += 30;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
            transform.position = defaultPosition;
            clickable = false;
        }
    }

    void set(float a,float b,float c,string n1,string n2,bool r)
    {
        beauty = a;
        fullness = b;
        flavor = c;
        next1 = n1;
        next2 = n2;
        ready = r;
    }
    void change2NextState()
    {
        if (wait4Release && Input.GetMouseButtonUp(0) && !inLine())
        {
            transform.position = defaultPosition;
            clickable = false;
            if(collider.gameObject.tag != "customer")
            {
                collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(
                collider.gameObject.GetComponent<SpriteRenderer>().color.r,
                collider.gameObject.GetComponent<SpriteRenderer>().color.g,
                collider.gameObject.GetComponent<SpriteRenderer>().color.b,1f);
                collider.gameObject.GetComponent<Cook>().isOn = true;
                collider.gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().material.color;
                collider.gameObject.GetComponent<Cook>().full.text = full.text;
                collider.gameObject.GetComponent<Cook>().beau.text = beau.text;
            }
            if (name != "rawMeat"|| name != "mr"|| name !="vg"|| name !="fr")
            {
                isOn = false;
            }
            wait4Release = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == next1|| other.gameObject.tag == next2 )//如果碰撞到下一个食材
        {
            collider = other;
            wait4Release = true;
            if(other.gameObject.name == "老头")
            {
                CookingPlot.served1 = true;
            }
            else if(other.gameObject.name == "族长儿子")
            {
                CookingPlot.served2 = true;
            }
            else if (other.gameObject.name == "族长")
            {
                CookingPlot.served3 = true;
            }
        }
        if(other.gameObject.tag == "plate" && gameObject.tag == "bakedMr2")
        {
            name = "bakedMr3";
            mark++;
            slider.value = 1f;
            slider.transform.position = new Vector3(-1000, -1000, 0);
        }
    }

    bool inLine()
    {
        for(int i = 0; i < neighbor.Length; i++)
        {
            if (neighbor[i].GetComponent<Cook>().isOn)
            {
                return true;
            }
        }
        return false;
    }

    void colorChange()
    {
        if (timer <= duration && name!= "bakedMr3")
        {
            slider.value -= Time.deltaTime / duration;
            timer += Time.deltaTime/duration;
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(colorStart, colorEnd, timer);
        }
            
    }
}