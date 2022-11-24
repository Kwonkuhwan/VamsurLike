using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Slider : MonoBehaviour
{
    private Slider hp_Slider = null;

    private Player player = null;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hp_Slider = GetComponent<Slider>();
        hp_Slider.maxValue = player.MaxHP;
        hp_Slider.value = player.MaxHP;
    }

    private void Update()
    {
        hp_Slider.value = player.HP;
    }
}
