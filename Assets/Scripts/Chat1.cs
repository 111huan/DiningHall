using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chat1 : MonoBehaviour
{
    float move = 0, now = 1, speed = 50f, step = 0;
    [SerializeField] Transform pos1;
    Transform[] pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (Input.anyKeyDown && now < 10)
        {
            now++;
        }
        if (now == 1)
        {
            Invoke("ctn", 0.5f);
        }
        else if (now == 2)
        {
            pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 20, 0), step);
            SceneManager.LoadScene("Guide");
        }
    }

    void ctn()
    {
        pos1.position = Vector3.MoveTowards(pos1.position, new Vector3(pos1.position.x, 2, 0), step);
    }
}
