using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 8f);//ham invoke de goi 1 ham thong qua ten cua no qua 1 tgian nhat dinh
        //o day la goi ham destroy sau 8 giay
    }

    void Destroy()
    {
        Destroy(gameObject);
        //bien gameobject o day cung giong nhu transform, no lien ket voi object ma script nay lien ket toi

    }
    
}
