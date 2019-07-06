using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rhythm_Controller : MonoBehaviour
{
    [SerializeField]private Text Score;//分数组件
    [SerializeField]private Text GameTime;//时间组件
    [SerializeField]private Text Player_Speed;
    [SerializeField]private Text Reminder;


    private float timer = 0f;//计时器

    // Start is called before the first frame update
    void Start()
    {
        //print(MyClass.SuiPian_CreatRate);
        //print(MyClass.UnSuiPian_CreatRate);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TextDisplay();
        NowGameState();

        //if ((int)(timer) == 10)
        //{
        //    MyClass.SuiPian_CreatRate = 5f;
        //    MyClass.UnSuiPian_CreatRate = 3f;
        //    MyClass.Player_DownForce = -15f;

        //    print("超过10s,节奏加快");
        //}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            print(MyClass.SuiPian_CreatRate);
            print(MyClass.UnSuiPian_CreatRate);
        }
    }



    void TextDisplay()
    {
        Score.text = "碎片数量:" + MyClass.Score;
        GameTime.text = "当前时间:" + (int)(timer);
        Player_Speed.text= "玩家速度" + MyClass.Player_DownForce;


    }
    void NowGameState()
    {
        if (MyClass.Score == MyClass.WantSocre)
        {
            MyClass.gameState = MyClass.GameState.Win;
        }



        if (MyClass.gameState == MyClass.GameState.Win)//胜利
        {
            Time.timeScale = 0;
            Reminder.text="游戏胜利";
        }
        else if (MyClass.gameState == MyClass.GameState.failure)//失败
        {
            Time.timeScale = 0;
            print("游戏失败");
        }
    }
}
