using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;//bien nay la doi tuong de lien ket
    //o day player se duoc lien ket transform vao enemy



    public float speed = 27f;
    public float disLimit = 6f;
    public float randPos = 0f;//random vi tri xuat hien enemy car

    // Start is called before the first frame update
    private void Awake()
    {
        this.player = PlayerCtrl.instance.transform;

        this.randPos = Random.Range(-6, 6); // random vi tri ngau nhien theo chieu ngang cua quang duong
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Follow();
    }

    void Follow()
    {
        Vector3 posPlayer = this.player.position;
        posPlayer.x= this.randPos;//random vi tri x de enemy dc random theo chieu ngang cua road (enemy s
        Vector3 distance = posPlayer - transform.position;//ket qua la 1 vecto 3 chieu
        if(distance.magnitude >= this.disLimit)//ham magnite tra ve do dai cua vector 3 chieu
        {
            //ham normalized se chuan hoa vector ve do dai la 1 nhung giu nguyen huong cua no
            Vector3 targerPoint = posPlayer - distance.normalized * this.disLimit;
            transform.position = Vector3.MoveTowards(transform.position,targerPoint,this.speed*Time.fixedDeltaTime);
        }
    }
    /*giai thich ham follow
     khi player di chuyen, enemy se luon duoi theo player nhung khong cham vao player 
    vi da co dieu kien if(distance.magnitude >=3) la enemy se luon giu khoang cach
    voi player la 3.
    vi tri cua enemy se duoc cap nhat la no se luon di chuyen toi vecto target voi khoang
    cach toi da 15*deltatime, neu vi tri hien tai gan target hon la khoang cach toi da, no 
    se dung di chuyen va tra ve gia tri target.
    */
}
