using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        //このオブジェクトの(this.)transformを(transform.)回転させなさい(Rotate)
        //ここではX軸15°、Y軸30°、z軸で45°今の状態から回転させる
    }
}
