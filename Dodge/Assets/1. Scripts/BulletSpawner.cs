using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 1f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        //ź�� ���� ������ �ּҰ��� �ִ밪 ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        //<PlayerController������Ʈ>�� ���� ������Ʈ�� �� ��ο��� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform; //transform Ÿ��
            //gameObject = FindObjectOfType<PlayerController>().gameObject //���� ������Ʈ Ÿ��
    }

    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime; //Time.deltaTime: �����Ӵ� �ð� ���� �ڵ� �Ҵ�
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        Debug.Log("Time : " + (int)timeAfterSpawn);
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;
            //bulletPrefab�� �������� transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            //������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
