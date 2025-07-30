using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    //-------

    [SerializeField] private float _spawnTime;
    [SerializeField] private Gem[] _prefabs;

    private float _currentSpawn;

    private bool _isMoveBack = true;

    private void Start()
    {
        transform.position = _startPoint.position;
        _currentSpawn = _spawnTime;
    }
    private void Update()
    {
        if (_isMoveBack == true)
        {
            Move(_endPoint);
        }
        else
        {
            Move(_startPoint);
        }

        Spawn();
    }

    private void Move(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            if(_isMoveBack == true)
            {
                _isMoveBack = false;
            }
            else
            {
                _isMoveBack = true;
            }
        }
    }

    private void Spawn()
    {
        _currentSpawn -= Time.deltaTime;

        if (_currentSpawn < 0)
        {
            Instantiate(_prefabs[Random.Range(0,_prefabs.Length)],transform.position, Quaternion.identity);
            _currentSpawn = _spawnTime;
        }
    }


}
