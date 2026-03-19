using UnityEngine;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float power = 200f;
    public Text timeUI;
    public float Timer = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Timer = Timer - Time.deltaTime;                             //타이머를 상승시키고
        timeUI.text = Timer.ToString();                             //타이머 ui

        if (Input.GetKeyDown(KeyCode.Space))  //스페이스 누르면
        {
            power = power + Random.Range(-100, 200);            //
            rigidbody.AddForce(transform.up * power);           //power의 힘 값으로 위쪽(transform.up)으로 힘을 준다.
        }

        if (this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
    }
}
