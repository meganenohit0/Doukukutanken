using System;
using TMPro;
using UnityEngine;

public class GameMaster : GameMasterFunctions
{
    public static bool up;
    public static int sideMove;
    public static float speed;
    public static int mode;
    private int count;

    private void Awake()
    {
        title = uitoka[0].GetComponent<TextMeshProUGUI>();
        ankoku = uitoka[2].GetComponent<SpriteRenderer>();
        up = false;
        count = 0;
        mode = 0;
        game = 0;
        ongaku = GetComponent<AudioSource>();
        duringEvent = 0;
        miraiCar = GameObject.Find("MiraiCar");
        kyori = GameObject.Find("MoveTenzyouToge");
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!up)
            {
                up = true;
            }
        }
        else
        {
            if (up)
            {
                up = false;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sideMove = 1;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sideMove = -1;
        }
        else
        {
            sideMove = 0;
        }
    }

    private void FixedUpdate()
    {
        if(duringEvent == 0)
        {
            if (game == 0)
            {
                if (up)
                {
                    duringEvent = 1;
                    title.text = "";
                    uitoka[1].SetActive(false);
                    uitoka[3].SetActive(false);
                    game = 1;
                }
            }
            else if (game == 1)
            {
                count++;
                if (count >= 400)
                {
                    count = 0;
                    speed -= 0.004f;
                }
                if (count % 80 == 0)
                {
                    int random;
                    random = UnityEngine.Random.Range(0, 5);
                    if (random < 3)
                    {
                        mode = 0;
                    }
                    else if (random == 3)
                    {
                        mode = 1;
                    }
                    else if (random == 4)
                    {
                        mode = 2;
                    }
                }
            }
            else if (game == 3)
            {
                if (up)
                {
                    miraiCar.GetComponent<Rigidbody2D>().gravityScale = 0;
                    miraiCar.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
                    count = 0;
                    mode = 0;
                    duringEvent = 1;
                    title.text = "";
                    uitoka[1].SetActive(false);
                    uitoka[3].SetActive(false);
                    ongaku.Play();
                    game = 1;
                }
            }
        }

        if (duringEvent == 1)
        {
            MiraiCarStart();
        }
        else if (duringEvent == 2)
        {
            Result();
        }
    }
}