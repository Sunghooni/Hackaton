using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

	public GameObject tutorial_UI;
	public GameObject player;
	public Text main_text;
	public Text sub_text;
	PlayerMove pm;
	
	int order = 0;

	private string[] main = new string[6] {"이동 W/A/S/D", "H를 누르면 앞에 있는 블럭을 잡을 수 있습니다.", "블럭을 들고 다른 블럭과 접촉하면 블럭들이 연결됩니다.", "블럭의 위치를 수정할 때도 아까와 같은 방법을 사용하시면 됩니다.", "모든 블럭들을 올바른 순서로 조합하면 스테이지가 클리어 됩니다.", "튜토리얼 클리어! 재시작 버튼 R" };
	private string[] sub = new string[1] {"화면 클릭/스페이스 바를 누르시면 다음 설명이 출력됩니다."};

    private void Start()
    {
		player.SetActive(false);
		pm = player.GetComponent<PlayerMove>();
	}
    void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if(order < 5)
				Tutorial_Next();
		}

		if(!pm.canCtl && !player.activeSelf)
        {
			main_text.text = main[5];
		}
	}
	public void Tutorial_Next() {
		order += 1;
		if(order == 5){
			//tutorial_UI.SetActive(false);
			main_text.text = "";
			sub_text.text = "";
			player.SetActive(true);
		}
		else
			main_text.text = main[order];
	}
}