using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public GameObject PrefabApple;
    public GameObject PrefabBomb;
    float delta;
    float spawn = 1.0f;
    float speed = -0.03f;
    float ratio = 20;
    System.Random random = new System.Random();

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > spawn)
        {
            GameObject Item;
            if (random.Next(0, 100) < ratio)
            {
                Item = Instantiate(PrefabBomb);
            }
            else
            {
                Item = Instantiate(PrefabApple);
            }
            Item.transform.position = new Vector3(random.Next(-1, 2), 4, random.Next(-1, 2));
            delta = 0;
            spawn -= 0.01f;
            speed -= 0.001f;
            Item.GetComponent<ItemController>().dropSpeed = speed;
        }
    }
    
    public void SetParameter(float spawn, float speed, float ratio)
    {
        this.spawn = spawn;
        this.speed = speed;
        this.ratio = ratio;     // ratio 1´ç ÆøÅº 1%
    }
}
