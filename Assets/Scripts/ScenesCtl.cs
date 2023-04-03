using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesCtl : MonoBehaviour
{
    // Start is called before the first frame update
    public void newGame()
    {
        SceneManager.LoadScene("Guide");
    }
    public void toChat()
    {
        SceneManager.LoadScene("Chat");
    }

    public static void toDressing()
    {
        SceneManager.LoadScene("Dressing");
    }
    public static void toCooking()
    {
        SceneManager.LoadScene("Cooking");
    }
}
