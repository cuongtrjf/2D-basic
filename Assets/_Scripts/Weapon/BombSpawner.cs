using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : Spawner
{
    //[Header("Bomb")]


    //awake da co ben lop cha(Spawner)

    private void Reset()//ham nay se reset gia tri tu lop cha de lay gia tri moi
    {
        this.prefabName = "BombPrefab";
        this.spawnPosName = "BombSpawnPos";
        this.spawnName = "Bomb ";
        this.maxObject = 7;
    }

    //update da co ben lop cha (spawner)

}
