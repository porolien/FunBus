using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class UIJaugeTrigger : MonoBehaviour
{
    public bool jaugeAgremented;

    public PlateBalancerUI plateBalancerUI;

    [SerializeField]
    RectTransform _otherUI;

    RectTransform _ownTransform;

    private void Start()
    {
        _ownTransform = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        float otherLowerPoint = _otherUI.anchoredPosition.y - (_otherUI.rect.height / 2);
        float otherHigherPoint = _otherUI.anchoredPosition.y + (_otherUI.rect.height / 2);
        float ownLowerPoint = _ownTransform.anchoredPosition.y - (_ownTransform.rect.height / 2);
        float ownHigherPoint = _ownTransform.anchoredPosition.y + (_ownTransform.rect.height / 2);
        if (otherLowerPoint <= ownHigherPoint && otherLowerPoint >= ownLowerPoint ||
            otherHigherPoint <= ownHigherPoint && otherHigherPoint >= ownLowerPoint)
        {
            jaugeAgremented = true;
        }
        else
        {
            jaugeAgremented = false;
        }

        
    }
}
