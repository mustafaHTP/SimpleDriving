using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedGainOverTime;
    [SerializeField] private float _steerAmount;

    private float _steerInput;

    private void Update()
    {
        //Rotate car
        float steerDelta = _steerInput * _steerAmount * Time.deltaTime;
        transform.Rotate(transform.up * steerDelta);

        //Move car forward
        _speed += _speedGainOverTime * Time.deltaTime;
        float moveDelta = _speed * Time.deltaTime;
        transform.position += transform.forward * moveDelta;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Steer(float steerInput)
    {
        _steerInput = steerInput;
    }
}
