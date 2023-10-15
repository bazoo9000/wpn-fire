using UnityEngine;
using UnityEngine.UI;

public class StartMenuScripts : MonoBehaviour
{
    public void KnightMode()
    {
        MainMenuScripts._choice = 0;
    }

    public void ZombieMode()
    {
        MainMenuScripts._choice = 1;
    }
}