using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    void Start() //������Ʈ�� Ȱ��ȭ�� �� ���� ���� �ڵ����� �� �� ����
    {
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;//vector3Ÿ���� velocity���� 
                                    //TransformŸ���� transform����(vector3Ÿ��) 
                                    //vector3Ÿ���� forward �չ���, ���� 1 (0,0,1)            //���� ��ǥ�� ��
                                    //bulletRigidbody.velocity = new Vector3(0, 0, 1)*speed; //�۷ι� ��ǥ�� ��

        //3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }
    //������ٵ� �浹 �޽��� �߻� > OnCollision(), OnTrigger()�ߵ� : �ּ� �ϳ� �������� ������ٵ� ������ �־���Ѵ�. 
    //Ʈ���� �浹 �� �ڵ� ����Ǵ� �޼��� // ������ �� �ϳ� �̻��� is Trigger üũ
    void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if(other.tag == "Player") //collider�� component�� ��ӹ���, component.tag����
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>(); //collider�� component�� ��ӹ���, Component.getComponent<>()

            //�������κ��� PlayerController ������Ʈ�� �������� �� �����ߴٸ�
            if (playerController != null)
            {
                //���� PlyaerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}
