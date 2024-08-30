using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinprefab;
    public float spawntime = 15;
    float m_spawnTime;
    bool directionAppear;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {   
        UIcontroler = FindObjectOfType<UIcontroler>();
        m_spawnTime = spawntime;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIcontroler.GameIsOver)
            return;
        m_spawnTime -= Time.deltaTime;
        Vector2 pos1 = new Vector2(-10, -1);
        Vector2 pos2 = new Vector2(10, -1);
        if (m_spawnTime <= 0)
        {
            int xDirection = Random.Range(1, 3);
            Debug.Log(xDirection);
            if (xDirection == 1)
            {
                Instantiate(coinprefab, pos1, Quaternion.identity);
                directionAppear = true;
                m_spawnTime = spawntime;
            }
            else if (xDirection == 2) 
            {
                Instantiate(coinprefab, pos2, Quaternion.identity);
                directionAppear = false;
                m_spawnTime = spawntime;
            }    
        }
    }
    public bool DirectionAppear
    {
        get { return directionAppear; }
        set { directionAppear = value; }
    }
}
