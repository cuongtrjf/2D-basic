using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReceiver
{
    protected PlayerCtrl playerCtrl;

    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerCtrl>();
        //tao doi tuong playerCtrl
    }

    public override void Receive(int damage)//ghi de len ham ke thua tu ham cha
    {
        base.Receive(damage);//goi den ham Receive cua ham cha (DamageReciver)
        if (this.IsDead())
        {
            this.playerCtrl.PlayerStatus.Dead();
            UIManager.instance.btnGameOver.SetActive(true);//khi player chet thi hien ra nut gameover
        }

    }
}
