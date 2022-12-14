using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    public Player player;
    public PlayerInputController playerController;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
