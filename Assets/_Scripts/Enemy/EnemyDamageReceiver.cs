using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    public EnemyCtrl enemyCtrl;
    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }
    private void Reset()
    {
        this.hp = 3;
    }
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            EffectManager.instance.SpawnVFX("Explosion_A", transform.position, transform.rotation);
            this.enemyCtrl.despawner.DeSpawn();
        }
    }
}
