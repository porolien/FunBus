using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBalancer : MonoBehaviour
{
    [SerializeField]
    float valueAddToStabilizePlayer;

    [SerializeField]
    GameObject _allUI;

    public float _delayGR;

    float _playerStabilizeValue;
    float _plateStabilizeValue;
    PlateBalancerUI _plateBalancerUI;

    bool _isStabilized;

    public bool isBalancing;

    [SerializeField]
    AudioClip glassBreak;

    void Start()
    {
        GetComponent<PlateMain>().plateBalancer = this;
        _plateBalancerUI = GetComponent<PlateBalancerUI>();
        _plateBalancerUI.plateBalancer = this;
    }

    private void FixedUpdate()
    {
        //Permet de faire baisser la bar 
        if (!_isStabilized && isBalancing)
        {
            ChangeStabilizeValue(- Time.deltaTime * 30);
        }
    }

    public void Balancing()
    {
        isBalancing = true;
        _playerStabilizeValue = 50;
        _allUI.SetActive(true);
        _plateBalancerUI.NewBalancing();
    }

    void ChangeStabilizeValue(float _value)
    {
        _playerStabilizeValue += _value;
        if (_playerStabilizeValue > 100)
        {
            _playerStabilizeValue = 100;
        }
        else if (_playerStabilizeValue < 0)
        {
            _playerStabilizeValue = 0;
        }
        _plateBalancerUI.MovePlayerUI(_playerStabilizeValue);
    }

    public void IsStabilized()
    {
        StopAllCoroutines();
        StartCoroutine(DelayBeforeDown());
        ChangeStabilizeValue(valueAddToStabilizePlayer);
    }

    IEnumerator DelayBeforeDown()
    {
        //Permet d'arrêter de faire baisser la bar le temps qu'on appuie sur espace
        _isStabilized = true;
        yield return new WaitForSeconds(_delayGR);
        _isStabilized = false;
    }

    void Victory()
    {
        Debug.Log("victoire");
        isBalancing = false;
        _allUI.SetActive(false);
        _plateBalancerUI.StopAllCoroutines();
    }

    void Defeat()
    {
        Debug.Log("defeat");
        isBalancing = false;
        _allUI.SetActive(false);
        _plateBalancerUI.StopAllCoroutines();
        CustomerManager.Instance.PlayerMistake();
        SFXManager.Instance.NewSFXPlay(glassBreak);
    }

}
