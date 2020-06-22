using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    [Header("General")]
    public GameObject ui;
    private Node target;

    [Header("Upgrading")]
    public TextMeshProUGUI upgradeCostTxt;
    public string fullyUpgradedPhrase = "FULLY UPGRADED";
    public Button upgradeBtn;

    [Header("Selling")]
    public TextMeshProUGUI sellAmountTxt;


    void Start()
    {
        upgradeBtn.interactable = true;
    }

    public void SetTarget(Node _target)
    {
        target = _target;

        this.transform.position = target.GetBuildPos();

        upgradeCostTxt.enableAutoSizing = true;

        if (!target.isUpgraded)
        {
            upgradeBtn.interactable = true;
            upgradeCostTxt.text = "-" + "$" + target.turretBlueprint.upgradeCost;
        }
        else
        {
            upgradeBtn.interactable = false;
            upgradeCostTxt.text = fullyUpgradedPhrase;
        }

        sellAmountTxt.text = "+" + "$" + target.turretBlueprint.GetSellAmount(target.isUpgraded);

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //This automatically hides NodeUI after upgrade
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode(); //This automatically hides NodeUI after upgrade
        target.isUpgraded = false;
    }
}
