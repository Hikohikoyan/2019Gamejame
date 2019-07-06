using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        MyClass.Player_DownForce = MyClass.Player_PreDownForce;

    }

    // Update is called once per frame
    void Update()
    {
        if (MyClass.gameState==MyClass.GameState.Playing)//判断游戏是否进行中
        {
            //获取玩家的输入
            float moveHorizontal = Input.GetAxis("Horizontal");
            //移动玩家
            rb2d.velocity = new Vector3(moveHorizontal, 0.0f, 0.0f) * MyClass.playerSpeed;

            //玩家下落
            rb2d.AddForce(new Vector2(0, MyClass.Player_DownForce));

        }

        //玩家的移动范围不能超过边界
        //rb2d.position = new Vector3(Mathf.Clamp(rb2d.position.x, MyClass.xMin, MyClass.xMax), 0.0f, 0.0f);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        print("1");
        if (collider.gameObject.tag == "SuiPian")
        {
            MyClass.Score += 1;
            MyClass.Player_DownForce += MyClass.LowForce;
        }

        else if (collider.gameObject.tag == "UnSuiPian")
        {
            MyClass.Player_DownForce -= MyClass.LowForce;
        }

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name == "Land")
        {
            MyClass.gameState = MyClass.GameState.failure;
        }
    }


    }
