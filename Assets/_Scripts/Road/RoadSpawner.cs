using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    protected GameObject roadPrefab;
    protected GameObject roadSpawnPos;
    protected float distance = 0;
    protected GameObject roadCurrent;
    protected int roadLayerOrder = 0;//thu tu order layer theo toa do Z
    
    private void Awake()
    {
        this.roadPrefab = GameObject.Find("RoadPrefab");
        this.roadSpawnPos = GameObject.Find("RoadSpawnPos");

        this.roadPrefab.SetActive(false);
        //this.roadCurrent = this.roadPrefab;

        this.roadLayerOrder = (int)this.roadPrefab.transform.position.z;

        this.Spawn(this.roadPrefab.transform.position);
    }

    //khi player di chuyen du xa se spawn them con duong moi
    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        this.distance = Vector2.Distance(PlayerCtrl.instance.transform.position, this.roadCurrent.transform.position);
        if (distance > 40) this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 pos = this.roadSpawnPos.transform.position;
        pos.x = 0;
        pos.z = this.roadLayerOrder;
        this.Spawn(pos);
        //this.roadCurrent = Instantiate(this.roadPrefab, pos, roadPrefab.transform.rotation);
        //this.roadcurrent.setactive(true);
    }

    protected virtual void Spawn(Vector3 position)
    {
        this.roadCurrent= Instantiate(this.roadPrefab, position, this.roadPrefab.transform.rotation);
        this.roadCurrent.transform.parent = transform;//nhom cac road dc spawn vao trong roadSpawner
        this.roadCurrent.SetActive(true);
    }
}
