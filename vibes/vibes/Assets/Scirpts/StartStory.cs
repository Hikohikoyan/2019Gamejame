using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartStory : MonoBehaviour
{
    [SerializeField] private GameObject StroyText;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(SayStory);
        StroyText = GameObject.Find("StroyText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SayStory()
    {
        //显示开场白
        StartCoroutine(StartSayStory());
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
                StroyText.GetComponent<Text>().text = MyClass.stprologue[i].Substring(0, j);
                yield return new WaitForSeconds(MyClass.wordTime);
            }
            yield return new WaitForSeconds(MyClass.delayTimeOut);
        }
        SwithScene();

    }

    //方法，切换场景
    public void SwithScene()
    {
        SceneManager.LoadScene("GamingScene");
    }
}
