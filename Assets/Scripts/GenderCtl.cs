using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderCtl : MonoBehaviour
{
    Toggle tg;
    [SerializeField] GameObject body, body1;
    // Start is called before the first frame update

    public void female()
    {
        body1.transform.localScale = new Vector3(0, 0, 0);
        body.transform.localScale = new Vector3(1, 1, 1);
    }
    public void male()
    {
        body.transform.localScale = new Vector3(0, 0, 0);
        body1.transform.localScale = new Vector3(1, 1, 1);
    }
}
