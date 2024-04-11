using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected PlayerCtrl playerCtrl;

    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerCtrl>();//lien ket player stt voi player ctrl
        //tuc la lay doi tuong playerStatus tu component khac
    }

    private void Update()
    {
        //this.CheckDead();
    }


    protected virtual void CheckDead()
    {
        if (this.playerCtrl.DamageReciver.IsDead())
            this.Dead();
    }


    public virtual void Dead()
    {
        Debug.Log("Dead");
    }
}
