using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    void Start() //오브젝트가 활성화될 때 가장 먼저 자동으로 한 번 실행
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;//vector3타입의 velocity변수 
                                    //Transform타입의 transform변수(vector3타입) 
                                    //vector3타입의 forward 앞방향, 값은 1 (0,0,1)            //로컬 좌표상 앞
                                    //bulletRigidbody.velocity = new Vector3(0, 0, 1)*speed; //글로벌 좌표상 앞

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }
    //리지드바디가 충돌 메시지 발생 > OnCollision(), OnTrigger()발동 : 최소 하나 오브제는 리지드바디 가지고 있어야한다. 
    //트리거 충돌 시 자동 실행되는 메서드 // 오브제 중 하나 이상이 is Trigger 체크
    void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player") //collider가 component를 상속받음, component.tag변수
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>(); //collider가 component를 상속받음, Component.getComponent<>()

            //상대방으로부터 PlayerController 컴포넌트를 가져오는 데 성공했다면
            if (playerController != null)
            {
                //상대방 PlyaerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
