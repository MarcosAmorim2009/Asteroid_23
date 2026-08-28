using UnityEngine;
using UnityEngine.InputSystem;

public class Jogador : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;

    public float thrust = 1f;
   public void Start()
    {
      animator = GetComponent<Animator>();  
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
 private void HandleMovement()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            animator.SetBool("isMoving", true);
        }
        
        if(Animator.GetBool("isMoving"))
            animator.SetBool("isMoving", false);
    }
  
        
  
}
