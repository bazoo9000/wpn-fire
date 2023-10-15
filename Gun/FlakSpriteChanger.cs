using UnityEngine;

public class FlakSpriteChanger : MonoBehaviour
{
    public Sprite[] s;
    public SpriteRenderer sr;

    private void Start()
    {
        sr.sprite = s[Random.Range(0, s.Length)];
    }
}