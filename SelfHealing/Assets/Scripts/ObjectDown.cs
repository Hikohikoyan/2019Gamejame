/*
 * 控制物体掉落速度脚本
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 1, Space.World);
    }
}
