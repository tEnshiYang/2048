using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class mana : MonoBehaviour {
    public static mana _instance;   //单例
    public Nuber[,] numbers = new Nuber[4, 4];
    public GameObject ga;           //生成方块
    public List<Nuber> isMovingNumbers = new List<Nuber>(); 
    public bool hasMove=false;
    public bool isOver = false;
    public GameObject OverSp;        //失败UI
    public GameObject OverSp2;
    public GameObject WinSp;          //胜利UI
    public GameObject WinSp2;
    public  int Score=0;
    public Text text;
    public bool hasCacu=false;
    public int deltaScore=0;
    public GameObject des;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public int maxScore=0;
    public bool canConrtrol=true;     //结束后失去控制权
    public Numbermanager nmanager;
    public static bool isWin = false;
 

    void Awake()
    {

        _instance = this;
        nmanager = GameObject.Find("NumberManager").GetComponent<Numbermanager>();
    }

    void Start () {
        Instantiate(ga);
        Instantiate(ga);
     

        text1.fontSize += 30;
        text2.fontSize += 30;
        text3.fontSize += 30;
        text4.fontSize += 30;


    }

 
	
	void Update () {
     
     //boom
   
        
        //计算并显示现在分数,每次移动执行一次
        if (hasCacu)
        text.text = Score.ToString();
        if (deltaScore!=0)
        des.GetComponent<Text>().text = "+"+deltaScore.ToString();
      
       //游戏没结束并可移动数字为1 执行移动
        if (isMovingNumbers.Count == 0 && canConrtrol)
        {  
            int dirX = 0;

            int dirY = 0;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                dirY = 1;
              
               
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                dirY = -1;
               
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                dirX = 1;
          
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                dirX = -1;
         
            }
            //检测触屏事件
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 tdP = Input.GetTouch(0).deltaPosition;
                if (Mathf.Abs(tdP.x) > Mathf.Abs(tdP.y))
                {
                    if (tdP.x > 10)
                    {
                        dirX = 1;
                    }
                    else if (tdP.x < -10)
                    {
                        dirX = -1;
                    }
                }
                else
                {
                    if (tdP.y > 10)
                    {
                        dirY = 1;
                    }
                    else if (tdP.y < -10)
                    {
                        dirY = -1;
                    }
                }
            }
                
                 
               
         
            deltaScore = 0;
            des.GetComponent<Text>().text = "";
            hasCacu = false;
            MoveNumber(dirX, dirY);
        }
        //移动完成生成新方块
        if (hasMove && isMovingNumbers.Count == 0)
        {
            Instantiate(ga);
            hasMove = false;
        }

        if (gameEnd())
        {
            gameOver();
        }
    }

   

 

    public void MoveNumber(int directionX,int directionY)
    {
        if (directionX == 1)
        {
            for (int x=2;x>=0;x--)
            {
                for (int y=0;y<4;y++)
                {
                    if (numbers[x,y]!=null)
                    {
                        numbers[x, y].Move2(directionX,directionY);
                    }
                }
            }
       
        }

        if (directionX == -1)
        {
          
            for (int x = 1; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (numbers[x, y] != null)
                    {
                        numbers[x, y].Move1(directionX, directionY);
                    }
                }
            }
        }

        if (directionY == 1)
        {

            for (int x = 3; x >= 0; x--)
            {
                for (int y = 2; y >=0; y--)
                {
                    if (numbers[x, y] != null)
                    {
                        numbers[x, y].Move2(directionX, directionY);
                    }
                }
            }
        }

        if (directionY == -1)
        {
     
            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (numbers[x, y] != null)
                    {
                        numbers[x, y].Move1(directionX, directionY);
                    }
                }
            }
        }
    }
    //判断指定位置是否为空
    public bool isEmpty(int x, int y)
    {
        if (x < 0 || x >= 4 || y < 0 || y >= 4)
        {
            return false;
        }
        else if (numbers[x, y] != null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    //游戏胜利
  public void OnGameWin()
    {
        canConrtrol = false;
        isWin = false;
        WinSp.SetActive(true);
        WinSp2.SetActive(true);
      
    }
    //判断是否结束 
  public bool gameEnd()
    {

        for (int x=0;x<4;x++)
        {
            for(int y=0;y<4;y++){
                if (numbers[x,y]==null)
                {
                    return false;
                }
            }
        }
        for (int x=0;x<3;x++)
        {
            for (int y=0;y<3;y++)
            {
                if (numbers[x, y].value == numbers[x + 1, y].value)
                {
                    return false;
                }
                if (numbers[x,y].value==numbers[x,y+1].value)
                {
                    return false;
                }
            }
        }
        for (int y = 0; y < 3; y++)
        {
            if (numbers[3, y].value == numbers[3, y + 1].value)
            {
                return false;
            }

        }
        for (int x = 0; x < 3; x++)
        {
            if (numbers[x, 3].value == numbers[x + 1, 3].value)
            {
                return false;
            }

        }

        Debug.Log("Game Over");
        return true;
    }
    //游戏失败
    public void gameOver()
    {
        canConrtrol = false;


        OverSp.SetActive(true);
        OverSp2.SetActive(true);
       

    }
    //重新开始
    public void Restart()
    {
        canConrtrol = true;
        Score = 0;
        Application.LoadLevel("main");
      
      
    }
  
    //将value转化为图片编号
    public int valueToNumber(int a)
    {
        for (int i=1; true;i++)
        {
            if (Mathf.Pow(2, i) == a)
            {
                return i;
            }
        }
    }


}
