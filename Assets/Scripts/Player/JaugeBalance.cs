using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeBalance : MonoBehaviour
{
    float _valueJauge;
    public float _ValueJauge
    {
        get { return _valueJauge; }
        set
        {
            _valueJauge = value;
            if (_valueJauge <= 0)
            {
                gameObject.SendMessage("Defeat");
            }
            if (_valueJauge >= 100)
            {
                gameObject.SendMessage("Victory");
            }
        }
    }
}
