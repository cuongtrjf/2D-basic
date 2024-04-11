using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //class n�y duoc tao ra muc d�ch chia nho t�c vu cua enemy, c� the goi destroy th�ng qua class n�y
    public DeSpawner despawner;
    public EnemyDamageReceiver damageReceiver;

    private void Awake()
    {
        this.despawner = GetComponent<DeSpawner>();//tao lien ket tu dong giua enemyctrl va despawn
        this.damageReceiver = GetComponent<EnemyDamageReceiver>();
    }
}
