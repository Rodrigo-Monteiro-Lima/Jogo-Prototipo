using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public TargetJoint2D joint;
    public float fallingTime;

    void Falling()
    {
        boxCollider.enabled = false;
        joint.enabled = false;
        Destroy(gameObject, 4);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Invoke("Falling", fallingTime);
        }
    }
}
