using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 5;
    CoinSpawn CoinSpawn;
    SoundEffect SoundEffect;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {
        SoundEffect = FindObjectOfType<SoundEffect>();
        CoinSpawn = FindObjectOfType<CoinSpawn>();
        UIcontroler = FindObjectOfType<UIcontroler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoinSpawn.DirectionAppear)
        {
            transform.Translate(Vector2.right *speed*Time.deltaTime);
        }
        else if (!CoinSpawn.DirectionAppear)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (UIcontroler.GameIsOver)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundEffect.IncreasementTIme();
            Destroy(gameObject);
            
        }
        else if (collision.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
