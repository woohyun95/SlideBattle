using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StartPanelUI : Singleton<StartPanelUI>
{
    [SerializeField] public TextMeshProUGUI stage;
    [SerializeField] public TextMeshProUGUI gold;

    public void UpdateUI() {
        UpdateStageUI();
        UpdateCoinUI();
    }

    public void UpdateStageUI() {
        stage.text = UITextManager.GetStageText();
    }

    public void UpdateCoinUI() {
        gold.text = UITextManager.GetGoldText();
    }
}
