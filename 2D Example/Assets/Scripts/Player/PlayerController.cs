using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float moveHorizontal;
    bool jump = false;
    bool crouch = false;

    bool IsMovementDisabled = false;

    [SerializeField] Animator animator;
    [SerializeField] CharacterController2D characterController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMovementDisabled)
            moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        else
            moveHorizontal = 0;

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        
        characterController.Move(moveHorizontal * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void DisableMovement()
    {
        characterController.Move(0, false, false);
        IsMovementDisabled = true;
    }

    public void EnableMovement()
    {
        IsMovementDisabled = false;
    }

}
