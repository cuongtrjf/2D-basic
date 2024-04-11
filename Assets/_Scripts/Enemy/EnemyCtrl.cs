using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //class này duoc tao ra muc dích chia nho tác vu cua enemy, có the goi destroy thông qua class này
    public DeSpawner despawner;
    public EnemyDamageReceiver damageReceiver;

    private void Awake()
    {
        this.despawner = GetComponent<DeSpawner>();//tao lien ket tu dong giua enemyctrl va despawn
        this.damageReceiver = GetComponent<EnemyDamageReceiver>();
    }
}
