using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    //游戏状态枚举
    public enum GameState
    {
        Load,           //准备
        Playing,        //在玩
        Pause,          //暂停
        Win,            //胜利
        failure         //失败
    }
    //对话框延迟delayTiemIn时间出现
    public static float delayTimeIn = 2.0f;

    //对话框延迟delayTimeOut时间退出
    public static float delayTimeOut = 1.0f;

    //对话框打字机间隔时间
    public static float wordTime = 0.5f;

    //开场白
    public static string[] stprologue = new string[] { "我生病了。", "就像圆珠笔突然写不出来了。", "明明还有那么多重要的事情要做。", "明明已经很努力写了。", "但是圆珠笔却再也写不出来了。" };

    //好物品信息
    public static string[] goodItemInfo = new string[]
    {
        "小A的短信：我又学了一道新菜，今天过去你那里，让你尝尝我的手艺。",
        "老B的礼物：刚好那家店打折促销，就送给你当圣诞礼物了",
        "童年的日记：“我以后一定要成为一个很厉害很厉害的人”",
        "友谊大合照："
    };

    //坏物品信息
    public static string[] badItenInfo = new string[]
    {
        "邻居的嘲讽：“年纪轻轻怎么会有病？”",
        "早上的心情：天气灰蒙蒙，一切都是那么难。"
    };

    //游戏状态
    public static GameState gameState = GameState.Playing;

    //碎片速度
    public static float SuiPian_UpForce = 3f;
    public static float SuiPian_DownForce = -10f;
    //碎片生成时间
    public static float SuiPian_CreatRate = 1f;
    public static float UnSuiPian_CreatRate = 5f;


    public static float Score;//收集碎片数量
    public static float WantSocre=5;//收集碎片数量的要求


    public static float Player_PreDownForce= -5f;//玩家初始下落速度
    public static float Player_DownForce;//玩家当前下落速度

    //接触碎片后减少下降的速度
    public static float LowForce = 0.5f;

    //玩家的移动速度
    public static float playerSpeed = 5.0f;
    //玩家的移动边界
    public static float xMin = -8.0f;
    public static float xMax = 8.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
