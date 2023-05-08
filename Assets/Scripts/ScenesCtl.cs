using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScenesCtl : MonoBehaviour
{
    [SerializeField] Sprite sp1, sp2;
    [SerializeField] Button bt = null;
    public static bool pausing = false;
    // Start is called before the first frame update
    public void newGame()
    {
        SceneManager.LoadScene("Chat 1");
    }
    public void toChat()
    {
        SceneManager.LoadScene("Chat");
    }

    public void toChat2()
    {
        SceneManager.LoadScene("Chat 2");
    }

    public static void toDressing()
    {
        SceneManager.LoadScene("Dressing");
    }
    public static void toCooking()
    {
        SceneManager.LoadScene("Cooking");
    }

    public void pauseOrCtn()
    {
        if (pausing)
        {
            pausing = false;
            bt.image.sprite = sp2;
            Time.timeScale = 1f;
        }
        else
        {
            pausing = true;
            bt.image.sprite = sp1;
            Time.timeScale = 0f;
        }
    }

    public void toCompetition()
    {
        SceneManager.LoadScene("Competition");
    }
}
