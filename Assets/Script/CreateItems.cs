using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItems : MonoBehaviour
{
    float CreateTime = 5.0f;
    public GameObject ball;
    public GameObject med;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateTime -= Time.deltaTime;
        if (CreateTime <= 0)    //如果倒计时为0 的时候
        {
            CreateTime = Random.Range(10, 15);     //随机3到9秒内

            Instantiate(ball, new Vector3(Random.Range(-7.9f, 7.7f), 5.6f, 0.0f), Quaternion.Euler(0, 0, 0));

            Instantiate(med, new Vector3(Random.Range(-7.9f, 7.7f), 5.6f, 0.0f), Quaternion.Euler(0, 0, 0));



        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
