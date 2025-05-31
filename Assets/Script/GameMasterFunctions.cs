using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameMasterFunctions : MonoBehaviour
{
    public static int game;
    public static int duringEvent;
    [SerializeField] protected GameObject[] uitoka;
    [SerializeField] protected AudioClip[] sounds;
    protected AudioSource ongaku;
    protected SpriteRenderer ankoku;
    protected TextMeshProUGUI title;
    protected GameObject miraiCar, kyori;
    private int wait;

    protected void MiraiCarStart()
    {
        if (ankoku.color.a > 0)
        {
            ankoku.color = new Color(0, 0, 0, ankoku.color.a - 0.1f);
        }
        else
        {
            if (title.text == "")
            {
                title.text = "3";
                uitoka[0].transform.position = new Vector3(0, 0, -7f);
                wait = 40;
            }
            else if (title.text == "3")
            {
                wait--;
                if (wait == 0)
                {
                    title.text = "2";
                    wait = 40;
                }
            }
            else if (title.text == "2")
            {
                wait--;
                if (wait == 0)
                {
                    title.text = "1";
                    wait = 40;
                }
            }
            else if (title.text == "1")
            {
                wait--;
                if (wait == 0)
                {
                    uitoka[0].SetActive(false);
                    miraiCar.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
                    duringEvent = 0;
                }
            }
        }
    }

    protected async void Result()
    {
        if(wait == 0)
        {
            ongaku.Stop();
            ongaku.PlayOneShot(sounds[1]);
            wait = 40;
            game = 3;
            await UniTask.Delay(2000);
            ankoku.color = new Color(0, 0, 0, 0.8f);
            uitoka[0].transform.position = new Vector3(0, 1.5f, -7f);
            title.text = "åãâ ÅF" + (-(int)kyori.transform.position.x).ToString() + "m";
            uitoka[0].SetActive(true);
            uitoka[1].SetActive(true);
            uitoka[3].SetActive(true);
            duringEvent = 0;
        }
    }
}
