
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    #region Variables
    [Header("General")]
    public GameObject ui;
    private Node target;

    [Header("Upgrading")]
    public TextMeshProUGUI upgradeCostTxt;
    public string fullyUpgradedPhrase = "FULLY UPGRADED";
    public Button upgradeBtn;

    [Header("Selling")]
    public TextMeshProUGUI sellAmountTxt;
    #endregion

    #region Setup
    void Start()
    {
        upgradeBtn.interactable = true;
    }
    #endregion

    #region Target
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
    #endregion

    #region Hide UI Elements
    public void Hide()
    {
        ui.SetActive(false);
    }
    #endregion

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //This automatically hides NodeUI after upgrade
    }

    #region Sell Turret
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode(); //This automatically hides NodeUI after upgrade
        target.isUpgraded = false;
    }
    #endregion
}
