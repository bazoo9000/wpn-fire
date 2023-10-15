using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour
{
    public AudioSource hover;
    public Text text;
    private bool hovered = false;
    void OnMouseOver()
    {
        Debug.Log("hovered");
        if (!hovered)
        {
            hover.Play();
            hovered = false;
            text.fontSize = 100;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
    }
    void OnMouseExit()
    {
        hovered = false;
        text.fontSize = 100;
    }
}