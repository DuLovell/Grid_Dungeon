using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform movePoint;
    [SerializeField] LayerMask noMovementLayer;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, movePoint.position) == 0)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            
            if (Mathf.Abs(horizontalInput) == 1f)
            {
                Collider2D potentialCollisionCollider = Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalInput, 0f, 0f), 0.1f, noMovementLayer);
                
                if (!potentialCollisionCollider || potentialCollisionCollider.isTrigger)
                    movePoint.position += new Vector3(horizontalInput, 0f, 0f);
                
            }
            else if (Mathf.Abs(verticalInput) == 1f)
            {
                Collider2D potentialCollisionCollider = Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalInput, 0f), 0.2f, noMovementLayer);

                if (!potentialCollisionCollider || potentialCollisionCollider.isTrigger)
                    movePoint.position += new Vector3(0f, verticalInput, 0f);
            }
        }
        
    }
}
