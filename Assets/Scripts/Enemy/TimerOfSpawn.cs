using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class TimerOfSpawn : MonoBehaviour
{
    //[SerializeField] private 
    [SerializeField] private float timer;
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private Transform spawnPoint;

    [SerializeField, InterfaceType(typeof(ISpawn))]
    private Object[] spawns;

    private void Update()
    {
        if (ServiceLocator.Instance.GetService<ILogicInGame>().IsPause()) return;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            CallSpawns();
            timer = cooldown;
        }
    }

    private void CallSpawns()
    {
        foreach (var spawn in Spawns())
        {
            spawn.Spawn(spawnPoint);
        }
    }

    private List<ISpawn> Spawns()
    {
        var spawnsList = new List<ISpawn>();
        foreach (var spawn in spawns)
        {
            spawnsList.Add(spawn as ISpawn);
        }

        return spawnsList;
    }
}