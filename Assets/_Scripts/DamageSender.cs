using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    //protected EnemyCtrl enemyCtrl;
    //private void Awake()
    //{
    //    this.enemyCtrl = GetComponent<EnemyCtrl>();//tao lien ket giua enemyctrl va damageSender
    //}

    [Header("DamageSender")]
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)//khi 2 object deu co collider2d va cham voi nhau se tu dong goi ham
                                                       //de ham nay duoc goi thi object phai co regidbody2D
                                                       //hàm này di cùng voi ca rigidbody2d
    {
        this.ColliderSendDamage(collision);
    }

    protected virtual void ColliderSendDamage(Collider2D collision)
    {
        DamageReceiver damage = collision.GetComponent<DamageReceiver>();
        if (damage == null) return;
        //khi va cham l?y ???c ??i t??ng damage tu collision 
        damage.Receive(this.damage);
    }
}
