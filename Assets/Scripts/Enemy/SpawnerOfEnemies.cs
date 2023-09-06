using System.Collections;
using UnityEngine;

public class SpawnerOfEnemies : MonoBehaviour, ISpawn
{
    private float timer;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject[] models3D;
    [SerializeField] private GameObject player;
    [SerializeField] private float factor_de_aumento;
    [SerializeField] private float time = 10f;


    private IEnumerator InstantiateEnemies(float cantidadDeZombies, float time, Transform spawnPoint)
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

    public void Spawn(Transform spawnPoint)
    {
        var cantidad_de_zombies = player.transform.position.z * factor_de_aumento;
        //Instantiate enemy during x seconds
        StartCoroutine(InstantiateEnemies(cantidad_de_zombies, time, spawnPoint));
    }
}