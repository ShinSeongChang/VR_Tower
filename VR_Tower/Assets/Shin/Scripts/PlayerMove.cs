using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 캐릭터 컨트롤러 컴포넌트
    private CharacterController characterController = default;

    // 이동속도
    public float speed = 5f;

    // 점프 크기
    public float jumpPower = 5f;

    // { 중력과 관련된 변수

    // 중력 가속도의 크기
    public float gravity = -20f;

    // 수직 속도
    float yVelocity = 0f;

    // } 중력과 관련된 변수

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        // { 업데이트 타임에 중력을 적용하는 로직
        yVelocity += gravity * Time.deltaTime;

        // 바닥에 있을 경우, 수직 항력을 처리하기 위해 속도를 0으로 한다.
        if(characterController.isGrounded)
        {
            yVelocity = 0f;
        }

        // 사용자가 점프 버튼을 누르면 속도에 점프 크기를 할당한다.
        if(ARAVRInput.GetDown(ARAVRInput.Button.Two, ARAVRInput.Controller.RTouch))
        {
            yVelocity = jumpPower;
        }

        direction.y = yVelocity;

        characterController.Move(direction * speed * Time.deltaTime);
        // } 업데이트 타임에 중력을 적용하는 로직
    }
}
