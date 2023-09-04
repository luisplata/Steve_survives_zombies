using System.Collections.Generic;
using UnityEngine;

public class SpawnerOfFollowers : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private FollowPoint followPointPrefab;
    [SerializeField] private ElementOrganizer elementOrganizer;
    [SerializeField] private Follower followerPrefab;
    private readonly List<FollowPoint> _followPoints = new();
    private List<Follower> _followers = new();
    private Gun _gun;
    private IPlayerMediator _playerMediator;

    [ContextMenu("AddElement")]
    public void AddFollower()
    {
        var followPoint = Instantiate(followPointPrefab, player.transform);
        var follower = Instantiate(followerPrefab);
        _followers.Add(follower);
        _followPoints.Add(followPoint);
        follower.OnPowerUpEventFollower += OnPowerUpEventFollower;
        UpdateFollowers();
    }

    private void OnPowerUpEventFollower(Gun gunInComing)
    {
        _gun = gunInComing;
        UpdateFollowers();
    }

    private void UpdateFollowers()
    {
        var result = elementOrganizer.GetPointsInWord(player, _followPoints.Count);
        for (var index = 0; index < _followPoints.Count; index++)
        {
            var vector3 = _followPoints[index];
            vector3.transform.position = result[index];
            _followers[index].Config(vector3.gameObject, _gun, _playerMediator);
        }
    }

    public void AddFollower(Gun defaultGun)
    {
        _gun = defaultGun;
        AddFollower();
    }

    public void Config(IPlayerMediator playerMediator)
    {
        _playerMediator = playerMediator;
    }
}