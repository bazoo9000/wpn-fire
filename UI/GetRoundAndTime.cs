using UnityEngine;
using UnityEngine.UI;

public class GetRoundAndTime : MonoBehaviour
{
    [SerializeField] Text _lasted;

    private void Update()
    {
        _lasted.text = "You lasted " + RoundSystem._round + " rounds";
        _lasted.text += "\n"; // randul urmator
        _lasted.text += "And your time is " + GameTimer._min;
        if (GameTimer._sec < 10)
        {
            _lasted.text += ":0";
        }
        else
        {
            _lasted.text += ":";
        }
        _lasted.text += GameTimer._sec;

        // daca cumva intrebi dc arata asa ii din cauza ca CODUL TREBUIE SPALAT CU DETERGENT!!!
    }
}