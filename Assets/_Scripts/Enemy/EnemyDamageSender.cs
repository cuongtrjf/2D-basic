using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Enemy")]
    public EnemyCtrl enemyCtrl;
    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }


    protected override void ColliderSendDamage(Collider2D collision)
    {
        //gui damage vao qua bom
        base.ColliderSendDamage(collision);
        this.enemyCtrl.damageReceiver.Receive(1);//trong khi gui damage vao bom thi cung nhan dame tu no
    }

}
