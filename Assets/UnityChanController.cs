using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityChanController : MonoBehaviour
{
  //アニメーションするためのコンポーネントを入れる
  Animator animator;
  //Unityちゃんを動かすためのコンポーネントを入れる
  Rigidbody2D rigid2D;
  //地面の位置
  private float groundLevel = -3.0f;
  //ジャンプ速度の減衰
  private float dump = 0.8f;
  //ジャンプの速度
  float jumpVelocity = 20;
  //ゲームオーバーになる位置
  private float deadLine = -9f;

  // Start is called before the first frame update 
  void Start()
  {
    //アニメーターのコンポーネントを取得する
    this.animator = GetComponent<Animator>();
    //Rigidbody2Dのコンポーネントを取得する
    this.rigid2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    //走るアニメーションを再生するためにanimatorのパラメータを調整する
    this.animator.SetFloat("Horizontal", 1);
    //着地しているかを調べる
    bool isGround = (transform.position.y > this.groundLevel) ? false : true;
    this.animator.SetBool("isGround", isGround);
    //着地状態でクリックされた場合
    if (Mouse.current.leftButton.isPressed && isGround)
    {
      //上方向の力をかける
      this.rigid2D.linearVelocity = new Vector2(0, this.jumpVelocity);
    }
    //クリックをやめたら上方向への速度を減速する
    if (!Mouse.current.leftButton.isPressed == false)
    {
      if (this.rigid2D.linearVelocity.y > 0)
      {
        this.rigid2D.linearVelocity *= this.dump;
      }
    }
    //デッドラインを超えた場合ゲームオーバーにする
    if (transform.position.x < this.deadLine)
    {
      //UIControllerのGameOver関数を呼び出して画面上に"Game Over"と表示する
      GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
      //Unityちゃんを破棄する
      Destroy(gameObject);
    }
  }
}
