using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTimeSpawn : MonoBehaviour
{
    public GameObject AddTimePrefab;
    public GameObject RemoveTimePrefab;
    public float spawnTimeAddTime = 6;
    public float spawnTimeRemoveTime = 4;
    float m_SpawnTimeAddTime;
    float m_SpawnTimeRemoveTime;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {
        UIcontroler = FindObjectOfType<UIcontroler>();
        m_SpawnTimeAddTime = spawnTimeAddTime;
        m_SpawnTimeRemoveTime = spawnTimeRemoveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIcontroler.GameIsOver)
        {
            return;
        }
        if (AddTimePrefab)
        {
            m_SpawnTimeAddTime -= Time.deltaTime;
            Vector2 spawnpos = new Vector2(Random.Range(-8.3f, 8.3f), 5.75f);
            if (m_SpawnTimeAddTime <= 0)
            {
                Instantiate(AddTimePrefab, spawnpos, Quaternion.identity);
                m_SpawnTimeAddTime = spawnTimeAddTime;
            }
        }
        if (RemoveTimePrefab)
        {
            m_SpawnTimeRemoveTime -= Time.deltaTime;
            Vector2 spawnpos2 = new Vector2(Random.Range(-8.3f, 8.3f), 5.75f);
            if (m_SpawnTimeRemoveTime <= 0)
            {
                Instantiate(RemoveTimePrefab, spawnpos2, Quaternion.identity);
                m_SpawnTimeRemoveTime = spawnTimeRemoveTime;
            }
        }
    }
}
