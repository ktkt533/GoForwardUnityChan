using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // 背景のスクロール速度
    public float scrollSpeed = -1f;
    //背景終了位置
    private float deadline = -16f;
    //背景開始位置
    private float startline = 15.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // 背景をスクロールさせる
      transform.Translate(this.scrollSpeed * Time.deltaTime, 0, 0);

      // 画面外に出たら右端に移動する
      if (transform.position.x < deadline)
      {
          transform.position = new Vector2(this.startline, 0);
      }
    }
}
