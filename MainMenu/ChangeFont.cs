using UnityEngine;
using UnityEngine.UI;

public class ChangeFont : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _text.fontSize = 50;
    }

    public void IncreaseFont()
    {
        _text.fontSize = 70;
    }

    public void DecreaseFont()
    {
        _text.fontSize = 50;
    }
}