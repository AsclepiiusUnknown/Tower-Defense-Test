using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Variables
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    //Whether or not we can build
    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    //Whether or not we have the money required
    public bool HasMoney
    {
        get { return PlayerStats.money >= turretToBuild.cost; }
    }
    #endregion

    #region Setup
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!!");
            return;
        }
        instance = this;
    }
    #endregion

    #region Node Selection
    //Select the given node
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;

        //Switching selection
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    //Deselect the node by deselecting all
    public void DeselectNode()
    {
        //Switching selection
        selectedNode = null;
        nodeUI.Hide();
    }
    #endregion

    #region Select Turret
    //Select the turret we want to build using the given blueprint
    public void SelectTurretToBuild(TurretBlueprint blueprint)
    {
        turretToBuild = blueprint;
        DeselectNode();
    }

    //return the turret to build
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    #endregion
}
