using UnityEngine;
//using UnityEditor; //에디터를 스크립트에서 만질 수 있다. 
public class PlayerController : MonoBehaviour  //컨트롤 + K + F: 스코프 정렬 //모노비헤이어 : 컴포넌트 : 오브젝트
{
    [SerializeField]private Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //이동 속력
    //public PlayerController playerController; //enable 예시 위해 임의로 만듬

    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>(); //Get읽다, Set쓰다//자신의 오브제 중에서 찾음
    }

    void Update()
    {
        ////Input.GetKey(): bool 타입 //Input: 사용자 입력값을 받는다.
        //if (Input.GetKey(KeyCode.UpArrow) == true) //KeyCode: 열거형 상수, UpArrow는 숫자(아스키코드)가 '273'이 식별자
        //{
        //    //위쪽 방향키 입력이 감지된 경우, Z방향(앞)으로 speed 만큼 [힘]주기
        //    playerRigidbody.AddForce(0f, 0f, speed); //rigidbody.AddForce(x,y,z) //1초에 60프레임: speed*60 //힘은 누적이다.
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우, Z방향(앞뒤) 힘주기
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우, Z방향(앞뒤) 힘주기
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    //위쪽 방향키 입력이 감지된 경우, Z방향(앞뒤) 힘주기
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        //=======================================================
        //[이동 속도]
        //수평 축, 수직 축 입력 값을 감지하여 저장 //Input: 사용자 입력값을 받는다.
        float xInput = Input.GetAxis("Horizontal"); //input manager의 이름값, 숫자로 담는다. 최대 1, 최소-1
        float zInput = Input.GetAxis("Vertical");   //
                            //getAxisRaw : 살짝만 움직여도 1로 고정

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed; //곱해야 플러스 마이너스 방향성을 가져간다.
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xspeed, 0, zspped)로 생성 //Vector3:구조제(값형식), n개의 원소를 값형식으로 받아들인다.
        //클래스였다면 10분동안 36000번 힙에 생성되고 바로 사라지지도 않는다.
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //rigidbody.velocity변수 (리지드바디의 속도:이미 가지고 있는 속성)에 newVelocity를 할당//velocity 이미 가지고 있는 속성이다.
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false); //gameObject: 변수(자기 자신을 가리킨다.), 학문적 프로퍼티(자동구현 프로퍼티)//SetActive()메서드
        //ex. 컴포넌트 활성화, 비활성화
        //playerController.enabled = true; //enabled:변수
    }
}
