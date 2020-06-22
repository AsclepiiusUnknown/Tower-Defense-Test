﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region Variables
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;
    #endregion

    #region Setup
    void Start()
    {
        buildManager = BuildManager.instance;

        standardTurret.turretCostText.text = "$" + standardTurret.cost;
        missileTurret.turretCostText.text = "$" + missileTurret.cost;
        laserTurret.turretCostText.text = "$" + laserTurret.cost;
    }
    #endregion

    #region Selection
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Missile Turret Purchased");
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("laser Turret Purchased");
        buildManager.SelectTurretToBuild(laserTurret);
    }
    #endregion
}
