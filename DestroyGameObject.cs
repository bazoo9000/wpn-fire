using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float _timeUntilDestroyed = 0f;

    private void Start()
    {
        Destroy(this.gameObject, _timeUntilDestroyed);
    }
}