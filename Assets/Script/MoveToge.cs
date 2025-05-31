using System;

public class MoveToge : MoveTogeFunctions
{
    private void Start()
    {
        zyunbi = false;
        Array.Resize(ref takusantoge, 22);
        if (this.transform.position.y > 0)
        {
            uesita = true;
        }
        else
        {
            uesita = false;
        }
        GameMaster.speed = -0.02f;
        imanotoge = 21;
        tuginotoge = 0;
        togeSize = 3;
        mode = 0;
        for (int i = 0; i < takusantoge.Length; i++)
        {
            MakeToge(i, uesita);
        }
    }

    private void FixedUpdate()
    {
        if(GameMaster.game == 1 && GameMaster.duringEvent == 0)
        {
            transform.Translate(GameMaster.speed, 0, 0);
            MoveToge();
        }
        else if(GameMaster.game == 3)
        {
            zyunbi = true;
        }
        else if (GameMaster.duringEvent == 1 && zyunbi)
        {
            Kaisi();
        }
    }
}