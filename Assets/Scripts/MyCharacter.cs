using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public int Health = 100;  //체력 선언 한다(변수)
    public float Timer = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = Health + 100;  // 첫 시작할떄 100의 체력 추가
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer - Time.deltaTime; //시간 실수를 매 프레임마다 감소 시킴

        if (Timer <= 0) //만약 Timer의 수치가 0 이하로 내려갈 경우
        {
            Timer = 1.0f;                           //다시 1초로 변경
            Health = Health - 20;                   //체력을 20 감소
        }

        if (Input.GetKeyDown(KeyCode.Space))        //스페이스 바를 누르면 체력이 +2가 된다
        {
            Health = Health + 2;
        }

        if (Health <= 0)                            //체력이 0 이하로 떨어지면
        {
            Destroy(this.gameObject);               //파괴
        }
    }
}
