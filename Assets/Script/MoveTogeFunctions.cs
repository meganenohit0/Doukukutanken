using UnityEngine;

public class MoveTogeFunctions : MonoBehaviour
{
    [SerializeField] protected GameObject toge;
    protected GameObject[] takusantoge;
    protected int tuginotoge, imanotoge;
    protected int togeSize;
    private float togekeisan;
    protected bool uesita;
    protected int mode;
    protected bool zyunbi;

    protected void Kaisi()
    {
        zyunbi = false;
        GameMaster.speed = -0.01f;
        imanotoge = 21;
        tuginotoge = 0;
        togeSize = 3;
        mode = 0;
        if (uesita)
        {
            transform.position = new Vector3(0, 4.3f, -2f);
        }
        else
        {
            transform.position = new Vector3(0, -4.8f, -2f);
        }
        for(int i = 0;i < takusantoge.Length; i++)
        {
            takusantoge[i].transform.localScale = new Vector3(0.3f, 0.3f);
            if (uesita)
            {
                takusantoge[i].transform.position = new Vector3(-7.5f, 4.3f, -2) + (new Vector3(0.72f, 0, 0)) * i;
            }
            else
            {
                takusantoge[i].transform.position = new Vector3(-7.5f, -4.8f, -2) + (new Vector3(0.72f, 0, 0)) * i;
            }
        }
    }

    protected void MakeToge(int i, bool uesita)
    {
        if (uesita)
        {
            takusantoge[i] = Instantiate(toge, new Vector3(-7.5f, 4.3f, -2) + (new Vector3(0.72f, 0, 0)) * i, new Quaternion(0, 0, 0, 0), this.transform);
        }
        else
        {
            takusantoge[i] = Instantiate(toge, new Vector3(-7.5f, -4.8f, -2) + (new Vector3(0.72f, 0, 0)) * i, new Quaternion(0, 0, 180f, 0), this.transform);
        }
    }

    protected void MoveToge()
    {
        togekeisan = 0.21f + (togeSize * 0.05f);
        if ((takusantoge[imanotoge].transform.position.x + togekeisan) < 7f)
        {
            int tuginotogeSize = 0;
            if (GameMaster.mode == 0)
            {
                tuginotogeSize = Random.Range(3, 12);
            }
            else if(GameMaster.mode == 1)
            {
                if (uesita)
                {
                    tuginotogeSize = Random.Range(3, 9);
                }
                else
                {
                    if(mode != 1)
                    {
                        tuginotogeSize = Random.Range(3, 9);
                    }
                    else
                    {
                        tuginotogeSize = Random.Range(3, 16);
                    }
                }
            }
            else if(GameMaster.mode == 2)
            {
                if (uesita)
                {
                    if(mode != 2)
                    {
                        tuginotogeSize = Random.Range(3, 9);
                    }
                    else
                    {
                        tuginotogeSize = Random.Range(3, 16);
                    }
                }
                else
                {
                    tuginotogeSize = Random.Range(3, 9);
                }
            }
            mode = GameMaster.mode;

            if(tuginotogeSize < 6)
            {
                tuginotogeSize = 3;
            }
            else if(tuginotogeSize < 8)
            {
                tuginotogeSize = 4;
            }
            else if(tuginotogeSize < 10)
            {
                tuginotogeSize = 5;
            }
            else
            {
                tuginotogeSize -= 4;
            }

            takusantoge[tuginotoge].transform.localScale = new Vector3(0.15f + 0.05f * tuginotogeSize, 0.1f * tuginotogeSize);
            takusantoge[tuginotoge].transform.position = takusantoge[imanotoge].transform.position + (new Vector3(1f,0,0) * (togekeisan + 0.21f + (tuginotogeSize * 0.05f)));
            togeSize = tuginotogeSize;
            if(++imanotoge > 21)
            {
                imanotoge = 0;
            }
            if(++tuginotoge > 21)
            {
                tuginotoge = 0;
            }
            MoveToge();
        }
    }
}
