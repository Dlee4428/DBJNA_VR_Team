using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : Stareable
{
    [SerializeField]
    private GameObject target;

    public override void BeginStare()
    {
        target.SetActive(true);
    }

    public override void EndStare()
    {
        target.SetActive(false);
    }
}
