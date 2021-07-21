using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCheck : MonoBehaviour
{
    public GameObject retryButton;
    //ボタンを代入するpublic変数を宣言

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
        //スタート時は非アクティブ化
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //衝突した相手(プレイヤー)のRigidbodyをゲットして物理演算を無効にする

        retryButton.SetActive(true);
        //ゴール時にアクティブ化
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //プレイヤーが落ちたときに再読み込みされる時と同じコード
    }
}
