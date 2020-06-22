using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    #region Variables
    [Header("Turret")]
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    [HideInInspector]
    public bool isEmptyPlaceholder;

    [Header("Color")]
    public Color hoverColor;
    public Color usedColor;
    public Color tooLowColor;
    public Vector3 posOffset;
    private Renderer rend;
    private Color startColor;

    [Header("Effects")]
    public Vector3 offectOffset = new Vector3(0, 10, 0);

    BuildManager buildManager;
    #endregion

    #region Setup
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;

        if (turret != null)
        {
            UsedColor();
        }
    }
    #endregion

    void Update()
    {

        //if we have put on a turret
        if (turret != null)
        {
            UsedColor(); //use the used color to display this
        }
    }

    //used to get the positon to build
    public Vector3 GetBuildPos()
    {
        return transform.position + posOffset;
    }

    #region Build
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            print("Not enough money to build turret");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject timeEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity); //change buildeffect to uprgadeEffect for variation (?)
        Destroy(timeEffect, 5f);

        print("Turret Built. Money left: " + PlayerStats.money);
    }
    #endregion

    #region Upgrade
    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            print("Not enough money to upgrade turret");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        //Destroy old turret
        Destroy(turret);

        //Build new turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPos(), Quaternion.identity);
        turret = _turret;

        GameObject timeEffect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPos(), Quaternion.identity); //change buildeffect to uprgadeEffect for variation (?)
        Destroy(timeEffect, 5f);

        isUpgraded = true;

        print("Turret Upgraded. Money left: " + PlayerStats.money);
    }
    #endregion

    #region Sell
    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount(isUpgraded);

        //Spawn Effect
        GameObject timeEffect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPos(), Quaternion.Euler(180, 0, 0)); //change buildeffect to uprgadeEffect for variation (?)
        Destroy(timeEffect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }
    #endregion

    #region Mouse
    //When we press down the mouse
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            if (!isEmptyPlaceholder)
            {
                buildManager.SelectNode(this);
            }
            Debug.Log("Can't build there! (display on screen ASAP");
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        //Build turret
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            UsedColor();
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = tooLowColor;
            return;
        }
    }

    void OnMouseExit()
    {
        if (turret != null)
        {
            UsedColor();
        }

        rend.material.color = startColor;
    }

    public void UsedColor()
    {
        rend.material.color = usedColor;
    }
    #endregion
}
