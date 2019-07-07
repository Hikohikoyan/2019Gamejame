using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    //粒子数组
    private ParticleSystem.Particle[] particleArray;
    //粒子坐标集合
    private Point[] points;

    //颜色梯度
    public Gradient grad;
    //控制透明度的变化
    private GradientAlphaKey[] gradAplp;
    //控制颜色的变化
    private GradientColorKey[] gradCol;

    //粒子参数
    public int count = 1000;
    public float size = 0.5f;
    public float minRadius = 12.0f;
    public float maxRadius = 12.0f;
    //控制主方向是顺时针还是逆时针
    public bool clockwise = true;
    public float speed = 0.5f;

    private void Init()
    {
        int i;
        for (i = 0; i < count; i++)
        {
            float midRadius = (minRadius + maxRadius) / 2.0f;
            float minRate = Random.Range(1.0f, midRadius / minRadius);
            float maxRate = Random.Range(midRadius / maxRadius, 1.0f);
            float radius = Random.Range(minRadius * minRate, maxRadius * maxRate);
            float angle = Random.Range(0.0f, 360.0f);
            points[i] = new Point(angle, radius);
            points[i].Cal();
            particleArray[i].position = new Vector3(points[i].getX(), points[i].getY(), 0f);
        }

        particleSystem.SetParticles(particleArray, particleArray.Length);
    }

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        int i;
        int level = 7; //将整个粒子系统分成七层，每一层的旋转方向和速度都有差异
        for (i = 0; i < count; i++)
        {

            if (i % level > 3)
            {
                //外层顺时针旋转
                points[i].angle -= (i % level + 1) * speed;
            }
            else
            {
                //内层逆时针旋转
                points[i].angle += (i % level + 1) * speed;
            }

            points[i].angle = (points[i].angle + 360.0f) % 360.0f;
            //粒子旋转半径的微小变化，能够让粒子运动体现出随机性
            points[i].radius += 0.04f * (Mathf.PerlinNoise(points[i].angle / 360.0f, 0.0f)) - 0.02f;
            //Debug.Log(points[i].radius);
            points[i].Cal();
            particleArray[i].color = grad.Evaluate(Time.time * 0.1f);
            particleArray[i].position = new Vector3(points[i].getX(), points[i].getY(), 0.0f);
        }
        particleSystem.SetParticles(particleArray, particleArray.Length);
    }
}


public class Point
{
    public float angle;
    public float radius;

    private float x = 0.0f;
    private float y = 0.0f;


    public void Cal()
    {
        float temp = angle / 180.0f * Mathf.PI;
        y = radius * Mathf.Sin(temp);
        x = radius * Mathf.Cos(temp);
    }
    public Point(float angle, float radius)
    {
        this.angle = angle;
        this.radius = radius;
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }
}