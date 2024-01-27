using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlateBalancerUI : MonoBehaviour
{
    [SerializeField]
    float _playerUIPosMax;

    [SerializeField]
    float _playerUIPosMin;

    [SerializeField]
    float _WantedPos;

    [SerializeField]
    RectTransform _playerUI;

    [SerializeField]
    RectTransform _balanceUI;

    [SerializeField]
    Vector2 _newPosition = Vector2.zero;

    [SerializeField]
    float _speed;

    [SerializeField]
    float _speedPRP1Min;

    [SerializeField]
    float _speedPRP1Max;

    [SerializeField]
    float _speedPRP2Min;

    [SerializeField]
    float _speedPRP2Max;

    [SerializeField]
    float _delayPRP1Min;

    [SerializeField]
    float _delayPRP1Max;

    [SerializeField]
    float _delayPRP2Min;

    [SerializeField]
    float _delayPRP2Max;

    float _speedBalanceUI;

    [SerializeField]
    float _delayToChangePatern;

    JaugeBalance jaugeBalance;

    public PlateBalancer plateBalancer;

    private void Start()
    {
        jaugeBalance = GetComponent<JaugeBalance>();
        _playerUI.GetComponent<UIJaugeTrigger>().plateBalancerUI = this;
    }

    public void NewBalancing()
    {
        jaugeBalance._ValueJauge = 50;
        ChooseABalancePatern();
        _balanceUI.anchoredPosition = new Vector2(0, 0);
    } 

    private void FixedUpdate()
    {
        if (plateBalancer.isBalancing)
        {
            _newPosition.y += _speed * Time.deltaTime;
            _playerUI.anchoredPosition = _newPosition;
            _balanceUI.anchoredPosition = new Vector2(_balanceUI.anchoredPosition.x, _balanceUI.anchoredPosition.y + _speedBalanceUI * Time.deltaTime);
            UILimited(_playerUI);
            UILimited(_balanceUI);

            if (_newPosition.y >= _playerUIPosMax)
            {
                _newPosition = new Vector2(_newPosition.x, _playerUIPosMax);
            }
            else if (_newPosition.y <= _playerUIPosMin)
            {
                _newPosition = new Vector2(_newPosition.x, _playerUIPosMin);
            }

            if (_playerUI.GetComponent<UIJaugeTrigger>().jaugeAgremented)
            {
                jaugeBalance._ValueJauge += Time.deltaTime * 20;
            }
            else
            {
                jaugeBalance._ValueJauge -= Time.deltaTime * 20;
            }
        }
    }

    public void MovePlayerUI(float _playerValue)
    {
        if( _WantedPos < ((_playerUIPosMax - _playerUIPosMin) * (_playerValue / 100)) + _playerUIPosMin)
        {
            _speed = Mathf.Abs(_speed);
        }
        else
        {
            _speed = - Mathf.Abs(_speed);
        }

        _WantedPos = ((_playerUIPosMax - _playerUIPosMin) * (_playerValue / 100)) + _playerUIPosMin;
    }

    void ChooseABalancePatern()
    {
        if( Random.Range(0, 2) == 0 ) 
        {
            BalanceMoveToADirection();
        }
        else
        {
            BalanceImpulse();
        }
        StartCoroutine(APatern());
    }

    void BalanceMoveToADirection()
    {
        _speedBalanceUI = _speed / Random.Range(_speedPRP1Min, _speedPRP1Max);
        if(Random.Range(0, 2) == 0 ) 
        {
            _speedBalanceUI = -_speedBalanceUI;
        }
        _delayToChangePatern = Random.Range(_delayPRP1Min, _delayPRP1Max);
    }

    void BalanceImpulse()
    {
        _speedBalanceUI = _speed * Random.Range(_speedPRP2Min, _speedPRP2Max);
        _delayToChangePatern = Random.Range(_delayPRP2Min, _delayPRP2Max);
    }

    IEnumerator APatern()
    {
        yield return new WaitForSeconds(_delayToChangePatern);
        ChooseABalancePatern();
    }

    void UILimited(RectTransform UIToLimit)
    {
        if (UIToLimit.anchoredPosition.y >= _playerUIPosMax)
        {
            UIToLimit.anchoredPosition = new Vector2(UIToLimit.anchoredPosition.x, _playerUIPosMax);
        }
        else if (UIToLimit.anchoredPosition.y <= _playerUIPosMin)
        {
            UIToLimit.anchoredPosition = new Vector2(UIToLimit.anchoredPosition.x, _playerUIPosMin);
        }
    }

    public void ConsoleChangeSpeedGR(float speed)
    {
        _speed = speed;
    }
    public void ConsoleChangeDelayGR(float delay)
    {
        plateBalancer._delayGR = delay;
    }
    public void ConsoleChangeSpeedMinPRP1(float speed)
    {
        _speedPRP1Min = speed;
    }
    public void ConsoleChangeSpeedMaxPRP1(float speed)
    {
        _speedPRP1Max = speed;
    }
    public void ConsoleChangeSpeedMinPRP2(float speed)
    {
        _speedPRP2Min = speed;
    }
    public void ConsoleChangeSpeedMaxPRP2(float speed)
    {
        _speedPRP2Max = speed;
    }
    public void ConsoleChangeDelayMinPRP1(float delay)
    {
        _delayPRP1Min = delay;
    }
    public void ConsoleChangeDelayMaxPRP1(float delay)
    {
        _delayPRP1Max = delay;
    }
    public void ConsoleChangeDelayMinPRP2(float delay)
    {
        _delayPRP2Min = delay;
    }
    public void ConsoleChangeDelayMaxPRP2(float delay)
    {
        _delayPRP2Max = delay;
    }
}
