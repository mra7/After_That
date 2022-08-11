using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleExplosiion : VFXDestroy
{
    protected override void RecyclePreFab()
    {
        string prefabName = "explosion";
        EventCenter.Boardcast(EventType.PoolSystem_RecycleGameObject, prefabName, gameObject);
    }
}
