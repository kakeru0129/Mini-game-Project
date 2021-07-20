using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//UIを制御するときはこの一行を必ず加える
using UnityEngine.SceneManagement;
//シーンを操作する時には必ず追加する

public class Player : MonoBehaviour
{
    //一番大きな波括弧ブロックをClass(クラス)といいC#のプログラムの機能をグループにまとめたもの
    Rigidbody rb;
    //宣言でRigidbody型の変数『rb』を定義している
    //クラス内で使う変数は冒頭で宣言

    public float speed;

    int count;
    //今回は個数で必ず整数になるので『int型』を使う

    public Text countText;
    //Text型の変数『countText』の宣言

    // Start is called before the first frame update
    //void Startやvoid UpdateはMethod(メソッド)という
    //戻り値を返さないメソッドをvoid(ヴォイド)という
    
    void Start()
    //void Startは最初に一回だけ実行される
    //ゲームの初期設定処理やタイトル画面の表示など

    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        //初期値は0

        SetCountText();
        //countText.text = "ゲット数:" + count.ToString();
        //count.ToString();を入力することによって左右の型が揃って代入できるようになる
        //int型の『数値』→string型の『文字(数字)』に変換するメソッド
        //"ゲット数:" + でUIの表示を『ゲット数:◯』とし、＋で前後の文字列を連結できる
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

    private void OnTriggerEnter(Collider other)
    //OnTriggerEnter()メソッドは他のオブジェクトに接触した瞬間に実行
    //このメソッドは引数を持ち、Collider型は文字通りColliderを代入することができる型で、そのときに触れた相手が自動的に変数otherに代入される

    {
        if (other.gameObject.CompareTag("Item"))
        //接触したオブジェクトのタグが引数("Item")と一致しているか？
        //条件式が真(true)の時だけ{}の中の処理を実行！
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Bottom"))
        //条件式２
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //今開いてるシーンを読み込み直す
        }
        //つまり接触したタグが『Item』ならアイテムゲットの処理を実行し、タグが『Bottom』ならステージ読み込み直しを実行


        //other.gameObject.SetActive(false);
        //otherに代入されているColliderを持っているオブジェクト、つまり接触したゲームオブジェクトのSetActive()メソッドを呼び出して実行しなさいという意味。
        //SetActive()メソッドはオブジェクトのアクティブ・非アクティブを制御するメソッドで、『bool型』と言ってtrueかfalseのどちらかの値だけしか代入できない型
        //trueがアクティブ化、falseが非アクティブ化

        //count = count + 1;
        //『今のcountの値に1を足してそれを新しいcountの値にしなさい』という意味で『count += 1』と書いてもいい

        //SetCountText();
        //countText.text = "ゲット数:" + count.ToString();
    }

    void SetCountText()
    //voidのStartとOnTriggerEnterの記述が同じためオリジナルメソッドを作る

    {
        countText.text = "ゲット数:" + count.ToString();
    }
}
