using UnityEngine;
using Cysharp.Threading.Tasks;

public class FireMove : MonoBehaviour
{
    [SerializeField] private Sprite[] yurameki;
    [SerializeField] private SpriteRenderer fire;

    private void Start()
    {
        Yurameki();
    }

    private async void Yurameki()
    {
        fire.sprite = yurameki[0];
        await UniTask.Delay(100);
        fire.sprite = yurameki[1];
        await UniTask.Delay(100);
        Yurameki();
    }
}