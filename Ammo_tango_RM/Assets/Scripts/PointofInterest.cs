using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointofInterest : MonoBehaviour
{
    private void Start()
    {
        MultipleTargetsCamera.Instance.AddTarget(transform);
    }

    private void OnDisable()
    {
        MultipleTargetsCamera.Instance.RemoveTarget(transform);
    }
}
