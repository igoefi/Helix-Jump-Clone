using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;

    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Sector sector = collision.gameObject.GetComponent<Sector>();
        if (sector != null)
        {
            if (sector.IsGood)
                Jump();
            else
                Dead();
        }
    }

    private void Jump()
    {
        Vector3 jumpVector = new(0, jumpForce, 0);
        _body.velocity = jumpVector;
    }

    private void Dead()
    {
        Debug.Log("dead");
        _body.velocity = Vector3.zero;
    }

}
