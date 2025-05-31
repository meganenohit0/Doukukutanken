using System;
using UnityEngine;

public class MiraiCarMove : MonoBehaviour
{
    private bool up;
    private GameObject[] fire;
    private Rigidbody2D miraiCar;
    private Vector2 force;
    private SpriteRenderer miraiCarUp;
    [SerializeField] private GameObject bakuhatu;
    [SerializeField] private Sprite[] upDownGekiha;
    private bool zyunbi;

    private void Start()
    {
        up = false;
        miraiCarUp = GetComponent<SpriteRenderer>();
        miraiCar = GetComponent<Rigidbody2D>();
        Array.Resize(ref fire, 2);
        fire[0] = transform.GetChild(0).gameObject;
        fire[1] = transform.GetChild(1).gameObject;
        fire[0].SetActive(false);
        fire[1].SetActive(false);
        force = new Vector2(0, 12f);
        zyunbi = false;
    }

    private void Update()
    {
        if(GameMaster.game == 1 && GameMaster.duringEvent == 0)
        {
            if (GameMaster.up)
            {
                if (!up)
                {
                    up = true;
                    miraiCarUp.sprite = upDownGekiha[1];
                    fire[0].SetActive(true);
                    fire[1].SetActive(true);
                }
            }
            else
            {
                if (up)
                {
                    up = false;
                    miraiCarUp.sprite = upDownGekiha[0];
                    fire[0].SetActive(false);
                    fire[1].SetActive(false);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(GameMaster.game == 1 && GameMaster.duringEvent == 0)
        {
            if (GameMaster.up)
            {
                miraiCar.AddForce(force);
            }

            if (GameMaster.sideMove == 1)
            {
                if (transform.position.x < 5.5f)
                {
                    miraiCar.linearVelocityX = 2f;
                }
                else
                {
                    miraiCar.linearVelocityX = 0;
                }
            }
            else if (GameMaster.sideMove == -1)
            {
                if (transform.position.x > -5.5f)
                {
                    miraiCar.linearVelocityX = -2f;
                }
                else
                {
                    miraiCar.linearVelocityX = 0;
                }
            }
            else
            {
                miraiCar.linearVelocityX = 0;
            }
        }
        else if(GameMaster.game == 3)
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -20f));
            miraiCar.linearVelocityY -= 0.5f;
            zyunbi = true;
        }
        else if (GameMaster.duringEvent == 1 && zyunbi)
        {
            Kaisi();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameMaster.game == 1 && GameMaster.duringEvent == 0)
        {
            GameMaster.duringEvent = 2;
            GameMaster.game = 2;
            miraiCarUp.sprite = upDownGekiha[2];
            fire[0].SetActive(false);
            fire[1].SetActive(false);
            miraiCar.linearVelocityX = GameMaster.speed * 30;
            miraiCar.linearVelocityY = 10f;
            bakuhatu.transform.position = this.transform.position;
            bakuhatu.GetComponent<ParticleSystem>().Play();
        }
    }

    private void Kaisi()
    {
        zyunbi = false;
        up = false;
        miraiCarUp.sprite = upDownGekiha[0];
        transform.position = new Vector3(-4f,0,-3f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
