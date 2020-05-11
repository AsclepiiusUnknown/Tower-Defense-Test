using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Build")]
    public GameObject prefab;
    public int cost;
    public TextMeshProUGUI turretCostText;

    [Header("Upgrade")]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount(bool isUpgraded)
    {
        if (isUpgraded)
        {
            return (cost / 2) + (upgradeCost / 3);
        }
        else
        {
            return (cost / 2);
        }
    }

    void Start()
    {
        turretCostText.text = "$" + cost;
    }
}
