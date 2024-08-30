using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float fallspeed = 5;
    UIcontroler UIcontroler;
    // Start is called before the first frame update
    void Start()
    {
        UIcontroler = FindObjectOfType<UIcontroler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallspeed * Time.deltaTime);
        if (UIcontroler.GameIsOver)
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIcontroler.DecreasementScore();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
