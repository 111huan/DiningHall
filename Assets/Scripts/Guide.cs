using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Guide : MonoBehaviour
{
    [SerializeField] GameObject obj1, obj2;
    // Update is called once per frame
    void Update()
    {
        if (obj2.GetComponent<Cook>().isOn)
        {
            Invoke("toNext", 1);
        }
    }

    void toNext()
    {
        SceneManager.LoadScene("Chat");
    }
}
