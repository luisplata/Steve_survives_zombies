using System.Collections;
using Services;
using UnityEngine;

public class SpawnerOfEnemies : MonoBehaviour
{
    [SerializeField] private float cooldown = 10f;
    private float timer;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] models3D;
    [SerializeField] private GameObject player;
    [SerializeField] private float factor_de_aumento;
    [SerializeField] private float time;

    private void Update()
    {
        if(ServiceLocator.Instance.GetService<ILogicInGame>().IsPause()) return;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            timer = cooldown;
        }
    }

    private void SpawnEnemy()
    {
        var cantidad_de_zombies = player.transform.position.z * factor_de_aumento;
        Debug.Log($"cantidad_de_zombies {cantidad_de_zombies}");
        //Instantiate enemy during x seconds
        StartCoroutine(InstantiateEnemies(cantidad_de_zombies, time));/*
        for (int i = 0; i < cantidad_de_zombies; i++)
        {
            var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.InstantiateModel3D(models3D[Random.Range(0, models3D.Length)]);
        }*/
    }

    private IEnumerator InstantiateEnemies(float cantidadDeZombies, float time)
    {
        //during time instantiate enemies
        for (int i = 0; i < cantidadDeZombies; i++)
        {
            var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.InstantiateModel3D(models3D[Random.Range(0, models3D.Length)]);
            //steps instantiate enemy
            yield return new WaitForSeconds(time/ cantidadDeZombies);
        }
    }
}