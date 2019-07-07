using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartStory : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        //显示开场白
        StartCoroutine(StartSayStory());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //协程，显示开场白
    IEnumerator StartSayStory()
    {
        yield return new WaitForSeconds(MyClass.delayTimeIn);
        //双重循环呈现打字机效果
        for (int i = 0; i < MyClass.stprologue.Length; i++)
        {
            for (int j = 0; j < MyClass.stprologue[i].Length; j++)
            {
                this.gameObject.GetComponent<Text>().text = MyClass.stprologue[i].Substring(0,j);
                yield return new WaitForSeconds(MyClass.wordTime);
            }
            yield return new WaitForSeconds(MyClass.delayTimeOut);
        }
        SwithScene();

    }

    //方法，切换场景
    public void SwithScene()
    {
        print("切换场景");
    }
}
