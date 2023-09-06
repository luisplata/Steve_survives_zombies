using UnityEngine;

public class SpawnOfPowerUps : MonoBehaviour, ISpawn
{
    [SerializeField] private PowerUp[] powerUps;
    [SerializeField] private float factor_de_aumento;
    public void Spawn(Transform spawnPoint)
    {
        //get random powerup and spawn it
        var powerUp = powerUps[Random.Range(0, powerUps.Length)];
        var powerUpInstantiate = Instantiate(powerUp, spawnPoint.position, Quaternion.identity);
        powerUpInstantiate.Config(factor_de_aumento);
    }
}