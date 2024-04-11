using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    //[Header("Enemy")]//header se phan biet thanh phan code cua lop cha va lop con


    //awake da co ben lop cha(Spawner)

    private void Reset()//ham nay se reset gia tri tu lop cha de lay gia tri moi
    {
        this.prefabName = "EnemyPrefab";
        this.spawnPosName = "EnemySpawnPos";
        this.spawnName = "Enemy ";
    }

    //update da co ben lop cha(spawner)

    //protected override void Spawn()
    //{
    //    if (PlayerCtrl.instance.DamageReciver.IsDead())
    //        return;//khi player chet thi k spawn quai nua


    //    if (listObjects.Count >= maxObject) return;

    //    this.spawnTimer += Time.deltaTime;
    //    if(this.spawnTimer < spawnDelay)
    //    {
    //        return;
    //    }
    //    this.spawnTimer = 0;


    //    GameObject enemy = Instantiate(this.objPrefab);
    //    enemy.transform.parent = transform;//nhom cac enemy spawn ra o trong enemySpawner
    //    enemy.transform.position = this.spawnPos.transform.position;
    //    enemy.SetActive(true);


    //    this.listObjects.Add(enemy);
    //}
}
