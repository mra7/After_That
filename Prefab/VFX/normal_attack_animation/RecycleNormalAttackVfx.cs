using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleNormalAttackVfx : VFXDestroy
{
    protected override void RecyclePreFab()
    {
        string prefabName = "normal_attack_hit_vfx";
        EventCenter.Boardcast(EventType.PoolSystem_RecycleGameObject, prefabName, gameObject);
    }
}
