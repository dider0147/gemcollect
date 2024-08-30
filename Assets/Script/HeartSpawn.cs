using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
    public GameObject HeartPrefab;
    public float spawntime = 3;
    float m_spawntime;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {   
        UIcontroler = FindObjectOfType<UIcontroler>();
        m_spawntime = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        if (UIcontroler.GameIsOver)
        {
            return;
        }
        if (HeartPrefab)
        {
            Vector2 spawnpos = new Vector2(Random.Range(-8.3f, 8.3f), 5.75f);
            m_spawntime -= Time.deltaTime;
            if (m_spawntime <= 0)
            {
                Instantiate(HeartPrefab, spawnpos, Quaternion.identity);
                m_spawntime = spawntime;
            }
        }
    }

}
