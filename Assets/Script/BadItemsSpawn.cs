using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItemsSpawn : MonoBehaviour
{
    public GameObject snowman;
    public float spawnTime = 5;
    float m_SpawnTime;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {   
        UIcontroler = FindObjectOfType<UIcontroler>();
        m_SpawnTime = 5;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (snowman)
        {   
            if (UIcontroler.GameIsOver)
            {
                return;
            }    
            m_SpawnTime -= Time.deltaTime;
            Vector2 spawnpos = new Vector2(Random.Range(-8.3f, 8.3f), 5.75f);
            if (m_SpawnTime <= 0)
            {
                Instantiate(snowman,spawnpos, Quaternion.identity);
                m_SpawnTime = spawnTime;
            }
        }
        
    }
}
