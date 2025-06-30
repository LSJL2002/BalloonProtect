using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new UnityEngine.Vector2(x, y);


        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new UnityEngine.Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBox();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }

    private void DestroyBox()
    {
        float yPosition = gameObject.transform.position.y;
        if (yPosition <= -5.0)
        {
            Destroy(gameObject);
        }

    }
}
