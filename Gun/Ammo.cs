using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text _gunName;
    public Text _ammoCounter;
    public int _ammo;
    [SerializeField] private AudioSource _outOfAmmo;
    [SerializeField] private int _totalAmmo = -1;
    private bool _inCooldown = false;
    private int _currentRound = 1;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        _ammo = _totalAmmo;
    }

    private void Update()
    {
        _gunName.text = gameObject.name;

        if (_ammo < 0)
        {
            _ammoCounter.color = Color.white;
            _ammoCounter.text = "INFINITY";
        }
        else
        {
            ChangeTextColor();
            _ammoCounter.text = _ammo + " / " + _totalAmmo;
        }

        if (_currentRound != RoundSystem._round)
        {
            _currentRound = RoundSystem._round;
            _ammo = _totalAmmo;
        }
    }

    private void ChangeTextColor()
    {
        if (_ammo == 0)
        {
            _ammoCounter.color = Color.red;
        }
        else if (_ammo <= _totalAmmo / 3)
        {
            _ammoCounter.color = Color.yellow;
        }
        else
        {
            _ammoCounter.color = Color.white;
        }
    }

    public void Click()
    {
        if (!_inCooldown)
        {
            _outOfAmmo.Play();
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        _inCooldown = true;
        yield return new WaitForSeconds(0.2f);
        _inCooldown = false;
    }
}