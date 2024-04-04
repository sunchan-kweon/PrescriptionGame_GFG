using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChecker : MonoBehaviour
{
    [SerializeField] Berry berry;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CircleCollider2D col;
    [SerializeField] BerryMover mover;

    private void Start()
    {
        mover = GameObject.FindWithTag("Manager").GetComponent<BerryMover>();
    }
    private void Update()
    {
        if (transform.position.y <= mover.conY(berry.getY())){
            col.enabled = true;
            rb.gravityScale = 0;
            rb.isKinematic = true;
            transform.position = new Vector2(transform.position.x, mover.conY(berry.getY()));
        }
        else
        {
            rb.isKinematic=false;
            rb.gravityScale = 0.4f;
            col.enabled = false;
        }
    }
}
