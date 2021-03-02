using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    Object player;
    Object enemy;
    private void Awake()
    {
        player = Resources.Load("Prefabs/Player");
        enemy = Resources.Load("Prefabs/Enemy");
    }
    void Start()
    {
        switch (mob)
        {
            case MobToSpawn.None:
                break;
            case MobToSpawn.Player:
                Instantiate(player, transform);
                break;
            case MobToSpawn.Enemy:
                Instantiate(enemy, transform);
                break;
        }
    }
    public enum MobToSpawn
    {
        None,
        Player,
        Enemy
    }
    public MobToSpawn mob;
}
