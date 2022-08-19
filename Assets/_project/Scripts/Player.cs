using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private Rigidbody _body;

    private Vector3 _firstPosition;

    private AudioSource _audioSourse;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _firstPosition = transform.position;

        _audioSourse = GetComponent<AudioSource>();
    }


    private void Jump()
    {
        Vector3 jumpVector = new(0, jumpForce, 0);
        _body.velocity = jumpVector;

        if (_audioSourse != null)
        {
            _audioSourse.volume = Random.Range(0.5f, 1);
            _audioSourse.Play();
        }
    }

    private void Dead()
    {
        GameManager.Losing();
        _body.velocity = Vector3.zero;
    }

    public void GoToFirstPosition()
    {
        transform.position = _firstPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.GameState != GameManager.GameStates.Playing) return;

        Sector sector = collision.gameObject.GetComponent<Sector>();
        if (sector != null)
        {
            if (sector.IsGood)
                Jump();
            else
                Dead();
        }
        else if (collision.gameObject.GetComponent<FinishPlatform>() != null)
        {
            _body.velocity = Vector3.zero;
            GameManager.Winning();
        }
    }
}
