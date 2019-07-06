using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public float X ;
    public int Y ;

    public GameObject[] SuiPianPrefabs;
    public GameObject[] UnSuiPianPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SuiPian_Creat", 2f, MyClass.SuiPian_CreatRate);//隔2f后以一定的速率调用方法    
        //InvokeRepeating("UnSuiPian_Creat", 5f, MyClass.UnSuiPian_CreatRate);//隔2f后以一定的速率调用方法
    }

    // Update is called once per frame
    void Update()
    {
        X = Random.Range(-15f, 15f);
        Y = Random.Range(0, 3);
    }

    void SuiPian_Creat()
    {
        print(SuiPianPrefabs[Y].name);
        //物体实例化
        GameObject.Instantiate(SuiPianPrefabs[Y], new Vector3(X, this.transform.position.y, 0), Quaternion.identity);  
    }

    //void UnSuiPian_Creat()
    //{
    //    for (int i = 0; i < SuiPianPrefab.Length; i++)
    //    {           
    //        GameObject.Instantiate(UnSuiPianPrefab[Y], new Vector3(X, this.transform.position.y, 0), Quaternion.identity);
    //    }
    //}


}
