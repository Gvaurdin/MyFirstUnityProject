using UnityEngine;

public class PlayerMover_2 : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    [SerializeField] private float _speed;
    private float _direction;

    private void Update()
    {


        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_speed * Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((_speed * Time.deltaTime) * -1, 0, 0);
        }
    }
}
