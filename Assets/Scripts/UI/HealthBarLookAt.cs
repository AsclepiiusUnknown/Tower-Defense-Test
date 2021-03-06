﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLookAt : MonoBehaviour
{
    public enum LookAxis
    {
        X,
        Y,
        Z,
        All,
        None
    }

    public GameObject Target;
    private Vector3 targetPos;
    public LookAxis lookAxis;

    void Awake()
    {
        if (Camera.main.gameObject != null)
            Target = Camera.main.gameObject;
    }

    void Start()
    {
        if (Target == null)
        {
            Debug.LogError("Main Camera GameObject not found by HealthBarLookAt.cs");
            return;
        }

        targetPos = Camera.main.WorldToScreenPoint(Target.transform.position);
    }

    void Update()
    {
        if (Target == null)
        {
            Debug.LogError("Main Camera GameObject not found by HealthBarLookAt.cs");
            return;
        }

        targetPos = Vector3.zero;

        if (lookAxis == LookAxis.X)
        {
            targetPos.x = Target.transform.position.x;
        }
        else if (lookAxis == LookAxis.Y)
        {
            targetPos.y = Target.transform.position.y;
        }
        else if (lookAxis == LookAxis.Z)
        {
            targetPos.z = Target.transform.position.z;
        }
        else if (lookAxis == LookAxis.All)
        {
            targetPos = Target.transform.position;
        }
        else if (lookAxis == LookAxis.None)
        {
            targetPos = Vector3.zero;
        }

        transform.LookAt(targetPos);
    }
}