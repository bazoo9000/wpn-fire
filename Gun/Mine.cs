using UnityEngine;

public class Mine : MonoBehaviour
{
    public float _speed = 0f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _effect;
    private bool _hasLanded = false;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F) && _hasLanded)
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            transform.rotation = Quaternion.identity;
            _hasLanded = true;
            _rb.bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;
            AudioSource s = GetComponent<AudioSource>();
            s.Play();
        }
    }
}