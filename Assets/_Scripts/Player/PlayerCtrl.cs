using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    static public PlayerCtrl instance;//de tao singleton

    public DamageReceiver DamageReciver;
    public PlayerStatus PlayerStatus;


    private void Awake()
    {
        PlayerCtrl.instance = this;//tao ra 1 singleton 
        //ta chi tao singleton khi va chi khi class chi ton tai duy nhat 1 lan


        this.DamageReciver = this.GetComponent<DamageReceiver>(); 
        //lien ket dameReciver voi playerCtrl
        this.PlayerStatus = this.GetComponent<PlayerStatus>();
    }
}
