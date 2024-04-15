using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillToolTip : UI_ToolTip
{
    [SerializeField] private TextMeshProUGUI skillText;
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI skillCost;
    [SerializeField] private float defaultNameFontSize;
    
    public void ShowToolTip(string _skillDescprtion,string _skillName,int _price)
    {
        skillName.text = _skillName;
        skillText.text = _skillDescprtion;
        skillCost.text = "∑—”√: " + _price;

        AdjustPosition();

        AdjustFontSize(skillText);

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        skillName.fontSize = defaultNameFontSize;
        gameObject.SetActive(false);
    }
 
}
