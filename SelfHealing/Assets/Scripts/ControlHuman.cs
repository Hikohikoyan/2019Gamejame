/*
 * 人物控制脚本
 * 功能：
 * 人物移动+动作修改
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ControlHuman : MonoBehaviour
{
    #region 初始化
    //各类按钮和人物
    private GameObject leftbtn;
    private GameObject rightbtn;
    private GameObject human;
    private bool have_kickboard;

    //图像加载，一个是有拿板子，一个没拿板子
    //private Dictionary<int, Sprite[]> spritesDictionary;
    private Sprite[] have;
    private Sprite[] no_have;

    //移动速度
    public float movespeed = 1.0f;

    //动画帧控制
    private int fps;
    private Vector2 rect;

    //检测是否按下按钮
    private bool play;
    private float lasttime;

    //
    public static bool combo_collect;//是否连续吃到或者一段时间没吃到
    public static bool up_down;//上升为true，下降为false

    #endregion

    #region 各类数值初始化（start函数）
    //各种初始化
    void Start()
    {
        //按钮是否按下
        play = false;

        //得到人物的对象
        human = GameObject.Find("human");

        //得到资源
        //spritesDictionary.Add(0, Resources.LoadAll<Sprite>("Image/have"));
        //spritesDictionary.Add(1, Resources.LoadAll<Sprite>("Image/no_have"));

        have = Resources.LoadAll<Sprite>("Image/have");
        no_have = Resources.LoadAll<Sprite>("Image/no_have");

        //帧初始化
        fps = 0;

        //开始没有板子
        have_kickboard = false;

        combo_collect = false;
        up_down = false;

        //test
        /*
        NewUp();
        NewDown();*/
    }
    #endregion

    void Update()
    {
        CheckClickPing();
    }

    #region 移动函数
    public void MoveLeft()
    {
        human.transform.Translate(Vector3.left, Space.World);

        //得到状态机
        human.GetComponent<Animator>().SetBool("direction", false);
        Play();

        
    }

    public void MoveRight()
    {
        human.transform.Translate(Vector3.right, Space.World);

        //得到状态机
        human.GetComponent<Animator>().SetBool("direction", true);
        Play();
    }
    #endregion

    //没写的不用看
    #region 修改碰撞体形状
    public void ChangeLeft()
    {
        //GetComponent<EdgeCollider2D>().points;
    }

    public void ChangeRight()
    {

    }
    #endregion

    #region 修改人物当前动作状态

    //静止不动函数
    public void Freeze()
    {
        play = false;
        human.GetComponent<Animator>().SetBool("play", false);
    }

    //开始动函数
    public void Play()
    {
        human.GetComponent<Animator>().SetBool("play", true);

        play = true;

        lasttime = Time.time;
    }

    //第几帧
    public void ChangeAction()
    {
        fps++;
        fps %= 4;
        bool Left_Right = human.GetComponent<Animator>().GetBool("direction");

        //human.GetComponent<SpriteRenderer>().sprite = spritesDictionary[Convert.ToInt32(have_kickboard)][Convert.ToInt32(Left_Right) * 4 + fps];

        if(have_kickboard == false)
        {
            human.GetComponent<SpriteRenderer>().sprite = no_have[Convert.ToInt32(Left_Right) * 4 + fps];
        }
        else
        {
            human.GetComponent<SpriteRenderer>().sprite = have[Convert.ToInt32(Left_Right) * 4 + fps];
        }
    }

    #endregion

    #region 长按检测代码
    private void CheckClickPing()
    {
        //如果判断是长按，就不断变换动作
        if (play == true && Time.time - lasttime > 0.2)
        {
            //ChangeAction();
            //向左动
            if (human.GetComponent<Animator>().GetBool("direction") == false)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
    }

    #endregion

    #region 控制上升和下降效果代码（有bug）
    
    public void NewUp()
    {
        Instantiate(Resources.Load("Perfabs/up"), GetComponent<Transform>());
    }

    public void NewDown()
    {
        Instantiate(Resources.Load("Perfabs/down"), GetComponent<Transform>());
    }

    #endregion(有bug)
}