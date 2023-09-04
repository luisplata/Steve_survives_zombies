using UnityEngine;

public class SpawnerOfEnemies : MonoBehaviour
{
    [SerializeField] private float cooldown = 10f;
    private float timer;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] models3D;
    private void Update()
    {
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
        var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemy.InstantiateModel3D(models3D[Random.Range(0, models3D.Length)]);
    }
}