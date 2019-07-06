using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiPian_Manager : MonoBehaviour
{
    [SerializeField] private bool IsDown = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDown)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, MyClass.SuiPian_DownForce));
        }
        //else
        //{
        //    this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, MyClass.SuiPian_UpForce));
        //}
    }

    void OnTriggerEnter2D(Collider2D collider)//2D触发
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.name == "Sky")
        {
            Destroy(gameObject);
        }

        else if (collider.tag == "Sea")
        {
            IsDown = false;
        }
    }

}
