using UnityEngine;
//using UnityEditor; //�����͸� ��ũ��Ʈ���� ���� �� �ִ�. 
public class PlayerController : MonoBehaviour  //��Ʈ�� + K + F: ������ ���� //�������̾� : ������Ʈ : ������Ʈ
{
    [SerializeField]private Rigidbody playerRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; //�̵� �ӷ�
    //public PlayerController playerController; //enable ���� ���� ���Ƿ� ����

    void Start()
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
        playerRigidbody = GetComponent<Rigidbody>(); //Get�д�, Set����//�ڽ��� ������ �߿��� ã��
    }

    void Update()
    {
        ////Input.GetKey(): bool Ÿ�� //Input: ����� �Է°��� �޴´�.
        //if (Input.GetKey(KeyCode.UpArrow) == true) //KeyCode: ������ ���, UpArrow�� ����(�ƽ�Ű�ڵ�)�� '273'�� �ĺ���
        //{
        //    //���� ����Ű �Է��� ������ ���, Z����(��)���� speed ��ŭ [��]�ֱ�
        //    playerRigidbody.AddForce(0f, 0f, speed); //rigidbody.AddForce(x,y,z) //1�ʿ� 60������: speed*60 //���� �����̴�.
        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    //���� ����Ű �Է��� ������ ���, Z����(�յ�) ���ֱ�
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        //=======================================================
        //[�̵� �ӵ�]
        //���� ��, ���� �� �Է� ���� �����Ͽ� ���� //Input: ����� �Է°��� �޴´�.
        float xInput = Input.GetAxis("Horizontal"); //input manager�� �̸���, ���ڷ� ��´�. �ִ� 1, �ּ�-1
        float zInput = Input.GetAxis("Vertical");   //
                            //getAxisRaw : ��¦�� �������� 1�� ����

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed; //���ؾ� �÷��� ���̳ʽ� ���⼺�� ��������.
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xspeed, 0, zspped)�� ���� //Vector3:������(������), n���� ���Ҹ� ���������� �޾Ƶ��δ�.
        //Ŭ�������ٸ� 10�е��� 36000�� ���� �����ǰ� �ٷ� ��������� �ʴ´�.
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        //rigidbody.velocity���� (������ٵ��� �ӵ�:�̹� ������ �ִ� �Ӽ�)�� newVelocity�� �Ҵ�//velocity �̹� ������ �ִ� �Ӽ��̴�.
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //�ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false); //gameObject: ����(�ڱ� �ڽ��� ����Ų��.), �й��� ������Ƽ(�ڵ����� ������Ƽ)//SetActive()�޼���
        //ex. ������Ʈ Ȱ��ȭ, ��Ȱ��ȭ
        //playerController.enabled = true; //enabled:����
    }
}
