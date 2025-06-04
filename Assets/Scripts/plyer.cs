using UnityEngine;

public class plyer : MonoBehaviour
{
    //キャラコン参照
    public float movespeed = 5f;
    private Animator animator;
    private CharacterController controller;

    void Start()
    {
        //コンポーネントの取得
        controller = GetComponent<CharacterController>();
        animator =  GetComponent<Animator>();
    }

    void Update()
    {
        //入力取得
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vectical");

        //移動ベクトルの制作
        Vector3 move = new Vector3(h,0,v);
        controller.Move(move * movespeed *  Time.deltaTime);

        //アニメーションの切り替え
        bool isMoving = move.magnitude > 0.1f;
        animator.SetBool("Swimming", isMoving);

        //前向き変更
        if (isMoving)
        {
            transform.forward = move;
        }
    }
}
