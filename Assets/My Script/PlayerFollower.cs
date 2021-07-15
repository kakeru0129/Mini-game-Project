using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.transform.position;
        //playerからカメラの距離を求めてoffsetに代入する
        //距離はカメラの位置とplayerの位置の差なので引き算をする
    }

    // Update is called once per frame
    void LateUpdate()
    //void LateUpdateは全てのクラスのUpdateが実行された後に実行
    //今回はplayerが動いてからカメラが動くため(playerよりカメラの処理が先に実行されるのを防ぐため)Lateをつける
    {
        this.transform.position = player.transform.position + offset;
        //playerの位置を取得してカメラの位置に代入
        //+ offsetは現在のplayerの位置からoffset分だけずらしてそこをカメラの位置として設定する
    }
}
