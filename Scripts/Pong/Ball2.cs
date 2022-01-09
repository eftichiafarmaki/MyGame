using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{

    public GameObject PaddleLeft;
    public GameObject PaddleRight;

    private AudioSource snd;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        snd = GetComponent<AudioSource>();

        PaddleLeft = GameObject.Find("PaddleLeft");
        PaddleRight = GameObject.Find("PaddRight");

        Count_Score.canAddScore = true;
        StartCoroutine(Pause());
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(this.transform.position.x) >= 23f)
        {
            Count_Score.canAddScore = true;
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }

    }

    IEnumerator Pause()
    {
        int directionX = Random.Range(-1, 2);
        int directionY = Random.Range(-1, 2);

        if (directionX == 0)
        {
            directionX = 1;
        }

        rb.velocity = new Vector2(0f, 0f);

        yield return new WaitForSeconds(3);

        rb.velocity = new Vector2(18f * directionX, 15f * directionY);

    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "PaddleLeft")
        {
            snd.Play();

            if (PaddleLeft.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(15f, 15f);

            }
            else if (PaddleLeft.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(15f, -15f);
            }
            else
            {
                rb.velocity = new Vector2(18f, 0f);

            }
        }


        if (hit.gameObject.name == "PaddleRight")
        {
            snd.Play();

            if (PaddleRight.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-15f, 15f);

            }
            else if (PaddleRight.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-15f, -15f);
            }
            else
            {
                rb.velocity = new Vector2(-18f, 0f);

            }
        }


    }

}

