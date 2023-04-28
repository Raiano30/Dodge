using UnityEngine;
using UnityEngine.UI; //UI���� ���̺귯�� - �޸𸮿� ����Ȯ���ؼ� ���ָ� ��Ų��.
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������ƮƮ
    public Text timeText;    //'���� �ð�' ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText;  //'�ְ� ���' ǥ���� �ؽ�Ʈ ������Ʈ
    //public UnityEngine.UI.Text timetext2;// ���̺귯�� ������ ��ù�, �� �ѹ� ���� ȣ�� - �ð� �ҿ�

    private float surviveTime; //�����ð�
    private bool isGameover;   //���ӿ��� ����
    
    void Start()
    {
        //���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    
    void Update()
    {
        //���ӿ����� �ƴ� ����
        if (!isGameover) //!: NOT������, ���ӿ�����false�� True��ȯ
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime; //int����ȯ
        }
        else //���ӿ���
        {
            //RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene"); //DontDestroyOnLoad(): ������ ������Ʈ�� ������� �ʴ´�. 
                                                       //����� �ε�, �񵿱�� �ε�(������Ʈ�� ��û ������)
                                                       //LoadScene(): ���̸� or ���ε����� �ҷ�����
                                                       //���� > ���弼�� > ����Ͽ��� �� �̸� �������� �Ŵ�. 
                Input.GetAxis("Horizontal");//�����۷���
            }
        }
    }
    //���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        //���� ���� = ���ӿ��� ���·� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ�� ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //Get �б� //Set ����
        //BestTimeŰ�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���� �ְ� ��Ϻ��� > ���� ���� �ð��� �� ũ�ٸ�
        if(surviveTime > bestTime)
        {
            //�ְ� ��� ���� ���� ���� �ð� ������ ����
            bestTime = surviveTime;
            //����� �ְ� ����� BestTimeŰ�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //�ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
