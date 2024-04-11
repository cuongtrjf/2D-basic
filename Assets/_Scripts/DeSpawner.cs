using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    public virtual void DeSpawn()
    {
        Destroy(gameObject);//ham huy object hay xoa object 
    }
}
