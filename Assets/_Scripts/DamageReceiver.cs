using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    [Header("DamageReceiver")]
    public int hp = 1;


    public virtual bool IsDead()
    {
        return this.hp <= 0;
        //tra ve gia tri true neu hp <=0, false neu nguoc lai
    }

    public virtual void Receive(int damage)//ham nhan damage tu enemy
    {
        this.hp -= damage;
    }
}
