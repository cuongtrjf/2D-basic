using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    //float playerPosX;
    List<GameObject> minions;//tao bien, chua khoi tao, phai khoi tao de su dung
    public GameObject minionPrefab;//doi tuong duoc dung san thi dc goi la prefab
    public int index;
    protected float spawnTimer = 0f;//bien nay de tinh sau delayTimer se duoc spawn
    protected float delayTimer = 1f;//sau 1 giay thi spawn quai



    private void Start()
    {
        this.minions = new List<GameObject>();//khoi tao list
        this.index = 1;
    }



    // Update is called once per frame
    void Update()
    {
        ////khoi tao bien playerPoxX
        //this.playerPosX = this.transform.position.x;//transfrom dai dien cho object ma scrip nay ket noi (o day la playerposition)
        ////nom na o day la lay toa do truc tiep cua player

        //int spawnLocation = 7;
        //if (this.playerPosX >= spawnLocation)
        //{
        //    this.Spawn();
        //}
        //else
        //{

        //}

        this.Spawn();
        CheckMinionDead();
    }

    void CheckMinionDead()
    {
        //ham nay khac phuc viec khi ma minion da bi chet, van spawn ra quai khi nhan vat di chuyen
        //boi vi khi minion bi chet, no k xoa di nen se k the spawn ra minion moi
        GameObject minion;
        for(int i = 0; i < this.minions.Count; i++)
        {
            minion = this.minions[i];//xoa minion neu no k xac dinh
            if(minion==null) this.minions.RemoveAt(i);
        }
    }


    void Spawn()
    {
        if (PlayerCtrl.instance.DamageReciver.IsDead()) 
            return;
        this.spawnTimer += Time.deltaTime;
        //ham delay di 1 khoang thoi gian la delaytime 
        //giai thich
        //delta time la khoang thoi gian giua cac khung hinh
        //khi spawntime < delay thi se k lam gi ca, khi spawntime lon hon thi se dat lai spawntime va spawn them quai
        if (this.spawnTimer < this.delayTimer)
            return;
        this.spawnTimer = 0f;


        if (this.minions.Count >= 7)
        {
            return;
        }
        //GameObject minion = new GameObject("Minion "+index);//tao ra gameobject bang new
        GameObject minion = Instantiate(this.minionPrefab);//tao ra gameobject bang instance prefab
        //hay noi cach khac la tao ra minion bang object minionprefab da dc dung san
        //muc dich cua viec tao ra minon bang prefab la khi minion moi dc tao ra, no se co script cua minion goc



        minion.name = "Bom #" + index;

        //lay vi tri cua nhan vat lam vi tri spawn cua quai
        minion.transform.position= this.transform.position;



        minion.gameObject.SetActive(true);//set trang thai true (hien ra) khi quai dc spawn
        /*vì ?ây là t?o minion b?ng prefab ?ã ???c d?ng s?n nên có 1 bug là khi ta xây d?ng hàm 
         selfdestroy cho prefab nó s? báo l?i khi prefab ?ã bi?n m?t và k th? spawn thêm ra quái
        gi?i pháp ? ?ây là ta t?t prefab trong trasfrom c?a nó, t?o các minion b?ng prefab và
        active true tr?ng thái cho nó khi ???c t?o ra*/
        this.minions.Add(minion);
        index++;
        if (index == 8) index = 1;
    }
}
