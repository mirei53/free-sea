using UnityEngine;

public class plyer : MonoBehaviour
{
    //�L�����R���Q��
    public float movespeed = 5f;
    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        //�R���|�[�l���g�̎擾
        controller = GetComponent<CharacterController>();
        animator =  GetComponent<Animator>();
    }

    void Update()
    {
        //���͎擾
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vectical");

        //�ړ��x�N�g���̐���
        Vector3 move = new Vector3(h,0,v);
        controller.Move(move * movespeed *  Time.deltaTime);

        //�A�j���[�V�����̐؂�ւ�
        bool isMoving = move.magnitude > 0.1f;
        animator.SetBool("Swimming", isMoving);

        //�O�����ύX
        if (isMoving)
        {
            transform.forward = move;
        }
    }
}
