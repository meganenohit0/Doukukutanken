using TMPro;
using UnityEngine;

public class Kyori : MonoBehaviour
{
    private GameObject kyori;
    private TextMeshProUGUI kiroku;

    private void Start()
    {
        kyori = GameObject.Find("MoveTenzyouToge");
        kiroku = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        kiroku.text = (-(int)kyori.transform.position.x).ToString() + " m";
    }
}
