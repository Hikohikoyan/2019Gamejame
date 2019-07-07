using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Pleyer,
    SuiPian
}

public class Game_Manger : MonoBehaviour
{
    public static Game_Manger _instance;//实例化

    [TooltipAttribute("上浮速度")]public float UpForce = -10f;
    [TooltipAttribute("下沉速度")]public float DownForce = 2f;
    [TooltipAttribute("速度_左")] public float LeftForce = -5f;
    [TooltipAttribute("速度_右")] public float RightForce = 5f;

    [TooltipAttribute("玩家体重")] public int Height = 0;


    void Awake()
    {
        _instance = this;
    }





}
