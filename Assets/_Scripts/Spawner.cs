using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tao lop cha Spawn de cac lop khac khi spawn se ke thua tu lop nay
public class Spawner : MonoBehaviour
{
    [Header("Spawner")]//header de phan biet to tuc code trong scrift
    public GameObject objPrefab;
    private int index = 1;//de doi ten bomb
    public GameObject spawnPos;
    public List<GameObject> listObjects;
    public float spawnTimer = 0f;
    public float spawnDelay = 1f;
    public string spawnPosName = "";
    public string prefabName = "";
    public int maxObject = 1;//so luong object de gioi han spawn
    public int layerOrder = 0;//thu tu order layer theo toa do z

    public string spawnName = "";

    private void Awake()
    {
        this.listObjects = new List<GameObject>();
        this.objPrefab = GameObject.Find(this.prefabName);
        this.spawnPos = GameObject.Find(this.spawnPosName);
        this.objPrefab.SetActive(false);
        this.layerOrder = (int)objPrefab.transform.position.z;
    }

    private void Update()
    {
        this.Spawn();
        this.CheckDead();
    }


    protected virtual GameObject Spawn()
    {
        if (PlayerCtrl.instance.DamageReciver.IsDead())
            return null;
        this.spawnTimer += Time.deltaTime;
        //ham delay di 1 khoang thoi gian la delaytime 
        //giai thich
        //delta time la khoang thoi gian giua cac khung hinh
        //khi spawntime < delay thi se k lam gi ca, khi spawntime lon hon thi se dat lai spawntime va spawn them quai
        if (this.spawnTimer < this.spawnDelay)
            return null;
        this.spawnTimer = 0f;
        if (this.listObjects.Count >= maxObject)
        {
            return null;
        }
        Vector3 pos = this.spawnPos.transform.position;
        pos.z = this.layerOrder;
        return this.Spawn(pos);
    }

    protected virtual GameObject Spawn(Vector3 pos)
    {
        //GameObject minion = new GameObject("Minion "+index);//tao ra gameobject bang new
        GameObject obj = Instantiate(this.objPrefab);//tao ra gameobject bang instance prefab
        //hay noi cach khac la tao ra minion bang object minionprefab da dc dung san
        //muc dich cua viec tao ra minon bang prefab la khi minion moi dc tao ra, no se co script cua minion goc

        obj.transform.parent = transform;//nhom cac enemy spawn ra o trong enemySpawner

        obj.name = this.spawnName + index;


        obj.transform.position = pos;



        obj.gameObject.SetActive(true);//set trang thai true (hien ra) khi quai dc spawn
        /*vì ?ây là t?o minion b?ng prefab ?ã ???c d?ng s?n nên có 1 bug là khi ta xây d?ng hàm 
         selfdestroy cho prefab nó s? báo l?i khi prefab ?ã bi?n m?t và k th? spawn thêm ra quái
        gi?i pháp ? ?ây là ta t?t prefab trong trasfrom c?a nó, t?o các minion b?ng prefab và
        active true tr?ng thái cho nó khi ???c t?o ra*/
        this.listObjects.Add(obj);
        index++;
        if (index == 8) index = 1;

        return obj;
    }

    protected virtual void CheckDead()
    {
        //ham nay khac phuc viec khi ma minion da bi chet, van spawn ra quai khi nhan vat di chuyen
        //boi vi khi minion bi chet, no k xoa di nen se k the spawn ra minion moi
        GameObject gameObject;
        for (int i = 0; i < this.listObjects.Count; i++)
        {
            gameObject = this.listObjects[i];
            if (gameObject == null)
                this.listObjects.RemoveAt(i);
        }
    }
}
