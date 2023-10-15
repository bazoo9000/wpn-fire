using UnityEngine;
using UnityEngine.UI;

public class IsFullscreen : MonoBehaviour
{
    private void Update()
    {
        // asta ii pentru a arata ca lai apasat
        if (Screen.fullScreen)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.black;
        }
    }
}