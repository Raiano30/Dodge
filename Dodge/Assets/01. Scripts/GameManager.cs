using UnityEngine;
using UnityEngine.UI; //UI관련 라이브러리 - 메모리에 공간확보해서 상주를 시킨다.
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버 시 활성화할 텍스트 게임 오브젝트트
    public Text timeText;    //'생존 시간' 표시할 텍스트 컴포넌트
    public Text recordText;  //'최고 기록' 표시할 텍스트 컴포넌트
    //public UnityEngine.UI.Text timetext2;// 라이브러리 직접적 명시법, 딱 한번 쓸때 호출 - 시간 소요

    private float surviveTime; //생존시간
    private bool isGameover;   //게임오버 상태
    
    void Start()
    {
        //생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    
    void Update()
    {
        //게임오버가 아닌 동안
        if (!isGameover) //!: NOT연산자, 게임오버가false면 True반환
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime; //int형변환
        }
        else //게임오버
        {
            //R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene"); //DontDestroyOnLoad(): 설정한 오브젝트는 사라지지 않는다. 
                                                       //동기식 로드, 비동기식 로드(오브젝트가 엄청 많으면)
                                                       //LoadScene(): 씬이름 or 씬인덱스로 불러오기
                                                       //파일 > 빌드세팅 > 씬등록에서 씬 이름 가져오는 거다. 
                Input.GetAxis("Horizontal");//프리퍼런스
            }
        }
    }
    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태 = 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트의 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //Get 읽기 //Set 쓰기
        //BestTime키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전 최고 기록보다 > 현재 생존 시간이 더 크다면
        if(surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
