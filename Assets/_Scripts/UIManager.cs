using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //vi uimanager chi xuat hien khi player chet va chi xuat hien 1 lan nen se dung singleton
    static public UIManager instance;

    public GameObject btnGameOver;

    private void Awake()
    {
        UIManager.instance = this;

        this.btnGameOver = GameObject.Find("btnGameOver"); 
        //nut dc an di khi player chua chet
        this.btnGameOver.SetActive(false);
    }


}
