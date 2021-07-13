using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //一番大きな波括弧ブロックをClass(クラス)といいC#のプログラムの機能をグループにまとめたもの
    Rigidbody rb;
    //宣言でRigidbody型の変数『rb』を定義している
    //クラス内で使う変数は冒頭で宣言
    public float speed;

    // Start is called before the first frame update
    //void Startやvoid UpdateはMethod(メソッド)という
    //戻り値を返さないメソッドをvoid(ヴォイド)という
    void Start()
    //void Startは最初に一回だけ実行される
    //ゲームの初期設定処理やタイトル画面の表示など
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frameの戻り値
    void FixedUpdate()
    //void Updateは1秒間に数十回というすごい速さで実行を繰り返す
    //今回void FixedUpdate()にしたのはPCの性能によってフレームが変わるのを防ぎ、一定のテンポを保つため
    {
        float moveH = Input.GetAxis("Horizontal");
        //float(少数)型の変数『moveH』を定義する
        //float moveHは変数moveHに値を代入する
        //Input.GetAxis("Horizontal")は左右の矢印キーを押すと少数の戻り値を返す
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);
        //Vector3(x,y,z)の新しいVector3型の値を作って戻り値として返す
        //moveHは左右、moveVは前後
        rb.AddForce(move * speed);
        //rb.AddForce(move)は一番初めに変数rbに入れたPlayerのRigidbodyにmoveの力を加えなさいという命令
    }
}
