using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static public EffectManager instance;//singleton
    public List<GameObject> listEffects;//luu tru cac hieu ung cua game


    private void Awake()
    {
        EffectManager.instance = this;
        this.LoadEffect();
    }


    protected virtual void LoadEffect()
    {
        this.listEffects= new List<GameObject> ();
        foreach (Transform child in transform)//for cac thanh phan con cua gameobject nay
        {
            this.listEffects.Add(child.gameObject);//vi o for goi transform nen o duoi phai chuyen sang gameobject
            child.gameObject.SetActive(false);
        }
    }

    
    public virtual void SpawnVFX(string effectName, Vector3 position, Quaternion rot)//(ten effect, vi tri, quay)
        //ham nay de phuc vu khi can spawn hieu ung
    {
        GameObject effect = this.Get(effectName);
        GameObject newEffect= Instantiate(effect, position, rot);
        newEffect.SetActive(true);
    }

    protected virtual GameObject Get(string effectName)
    {
        foreach (GameObject child in this.listEffects)
        {
            if(child.name == effectName) return child;
        }
        return null;
    }
}
