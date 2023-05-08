using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chat2 : MonoBehaviour
{
    float move = 0, now = 1, speed = 50f;
    [SerializeField] Transform pos1,pos2,pos3;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("´«ËÍ").transform;
        player.localScale = new Vector3(-0.35f, 0.35f, 0);
        player.position = new Vector3(-7.5f, -1.86f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.anyKeyDown && now < 10)
        {
            now++;
        }
        if (now == 1)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 2, 0), step);
        }
        else if (now == 2)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 20f, 0), step);
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 1f, 0), step);
        }
        else if (now == 3)
        {
            pos2.position = Vector3.MoveTowards(pos2.position, new Vector3(pos2.position.x, 20f, 0), step);
            pos3.position = Vector3.MoveTowards(pos3.position, new Vector3(pos3.position.x, 1f, 0), step);
        }
        else if(now == 4)
        {
            player.position = new Vector3(50f, 50f, 0);
            SceneManager.LoadScene("Cooking");
        }
    }
}
