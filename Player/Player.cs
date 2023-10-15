using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public HealthBar _hpBar;
    public CanvasGroup _hurt;
    public float _hp;
    public float _maxHp = 100f;
    public static bool _immuneAtStart = true;
    private int _currentRound = 0;
    private float _timer;
    private float _timeInvicible = 3f;
    private bool _wasHurt = false;

    private void Awake()
    {
        _timer = _timeInvicible;
        _hp = _maxHp;
        _hpBar.SetMaxHP(_maxHp);
    }

    private void Update()
    {
        if (Invincible._isInvincible)
        {
            Invincible.Stop();
        }

        if (_immuneAtStart)
        {
            Wait();
        }

        if (_currentRound != RoundSystem._round)
        {
            _currentRound = RoundSystem._round;
            _immuneAtStart = true;
            _timer = _timeInvicible;
        }

        if (_wasHurt)
        {
            HurtAnim();
        }
    }

    public void TakeDamage(float damage)
    {
        if (!Invincible._isInvincible && !_immuneAtStart)
        {
            _hp -= damage;
            _hpBar.SetHP(_hp);
            if (_hp <= 0f)
            {
                GameOver.GameOverScreen();
            }
            else
            {
                _hurt.alpha = 1f;
                _wasHurt = true;
            }
        }
    }

    private void Wait()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            _immuneAtStart = false;
            _timer = _timeInvicible;
        }
    }

    private void HurtAnim()
    {
        _hurt.alpha -= 2.5f * Time.deltaTime;
        if (_hurt.alpha <= 0f)
        {
            _wasHurt = false;
        }
    }
}
