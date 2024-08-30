using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour
{
    public GameObject GemPrefab;
    public float spawnTime = 10;
    float m_SpawnTime;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {   
        UIcontroler = FindObjectOfType<UIcontroler>();
        m_SpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIcontroler.GameIsOver)
        {
            return;
        }
        if (GemPrefab)
        {
            m_SpawnTime -= Time.deltaTime;
            Vector2 spawnpos = new Vector2(Random.Range(-8.3f, 8.3f), 5.75f);
            if (m_SpawnTime <= 0)
            {
                Instantiate(GemPrefab, spawnpos, Quaternion.identity);
                m_SpawnTime = spawnTime;
            }
        }
    }
}
