using System.Collections.Generic;
using UnityEngine;

public class RunnerInifity : MonoBehaviour
{
    [SerializeField] private GameObject _runner;
    [SerializeField] private float _distance, aditionalDistance;
    [SerializeField] private GameObject mapPrefab;
    private Queue<GameObject> mapsIntantiated = new();

    private void FixedUpdate()
    {
        if (_runner.transform.position.z > _distance)
        {
            _distance += aditionalDistance;
            var instantiate = Instantiate(mapPrefab, new Vector3(0, 0, _distance), Quaternion.identity);
            mapsIntantiated.Enqueue(instantiate);
            
            //remove map when have more of 3 maps
            if (mapsIntantiated.Count > 3)
            {
                Destroy(mapsIntantiated.Dequeue());
            }
        }
    }
}
