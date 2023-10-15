using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private float _timer;
    [SerializeField] private Text _counter;
    static public int _sec;
    static public int _min;

    private void Start()
    {
        _timer = 0f;
        _counter.text = "Timer: " + "0:00";
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _sec = (int)_timer % 60;
        _min = (int)_timer / 60;

        if (_sec < 10)
        {
            _counter.text = "Timer: " + _min + ":0" + _sec;
        }
        else
        {
            _counter.text = "Timer: " + _min + ":" + _sec;
        }
    }
}