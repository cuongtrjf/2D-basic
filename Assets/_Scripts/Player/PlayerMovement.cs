using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]//nhac cho unity ti thêm rigidbody2d khi ta quên chua add
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rg2d;
    public Vector2 velocity = new Vector2(0f, 0f);
    public float pressHorizontal = 0f;//di chuyen ngang
    public float pressVertical = 0f;//di chuyen doc
    public float speedUp = 0.5f;//gia toc xe khi tang toc
    public float speedDown = 0.5f;//gia toc xe khi giam toc do  
    public float speedMax = 20f;//gia toc toi da cua xe
    public float speedHorizontal = 3f;//gia toc di chuyen sang trai phai

    //test auto run
    public bool autoRun = false;


    private void Awake()
    {
        this.rg2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.pressHorizontal = Input.GetAxis("Horizontal");//nhan tin hieu tu ban phim 
        this.pressVertical = Input.GetAxis("Vertical");

        if (autoRun) this.pressVertical = 1;
    }

    private void FixedUpdate()///ham nay se duoc goi sau 1 khoang thoi gian nhat dinh
    {
        this.UpdateSpeed();
    }


    protected virtual void UpdateSpeed()
    {
        this.velocity.x = this.pressHorizontal*speedHorizontal;//??ng b? tín hi?u t? bàn phím và t?a ?? m?i
        //this.velocity.y = this.pressVertical;


        //2 ham if duoc xay dung de tao hieu ung xe tang toc tu tu den toc do max la speedMax
        if (this.pressVertical > 0)//tuc la da co tin hieu tu nut W hoac tien len
            this.velocity.y += this.speedUp;
        if(this.velocity.y>this.speedMax) this.velocity.y = this.speedMax;//gioi han toc do khi di thang (gioi han gia toc)


        //khi ko nhan nut W thi xe se dung tu tu
        if (this.pressVertical <= 0)
        {
            this.velocity.y-=this.speedDown;
            if(this.velocity.y<0)
                this.velocity.y = 0;//neu toc do giam dan ve 0 thi dung xe lai
        }

        if(this.transform.position.x > 7 || this.transform.position.x < -7)
        {
            this.velocity.y -= 1;
            if (this.velocity.y < 3f) this.velocity.y = 3f;
        }

        this.rg2d.MovePosition(this.rg2d.position + 
            this.velocity*Time.fixedDeltaTime);//di chuyen doi tuong theo huong nao do
    }
}
