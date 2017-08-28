using UnityEngine;
using System.Collections;

public class Nuber : MonoBehaviour {
    public int PositionX;
    public int PositionY;
    public int value;
    int number;
    public TweenPosition tp;
    public  bool isMoving = false;
    private bool toDestory = false;



    //void Awake()
    //{
    //    Instantiate(yuzhi, new Vector2(0, 0), Quaternion.identity);
    //    Instantiate(yuzhi, new Vector2(0, 0), Quaternion.identity);
    //}

    void Start () {
        value = Random.value > 0.2f ? 2 : 4;     //随机生成方块初始value
        number = mana._instance.valueToNumber(value);     //得到value对应sprite编号
        GetComponent<SpriteRenderer>().sprite = mana._instance.nmanager.manager[number - 1];
     
        //保证生成的方块不重复
        do
        {
            PositionX = Random.Range(0, 4);
            PositionY = Random.Range(0, 4);
        } while (mana._instance.numbers[PositionX,PositionY]!=null);

      
        transform.position = new Vector2(PositionX,PositionY);
        mana._instance.numbers[PositionX, PositionY] = this;
        //移动参数
        tp.from = new Vector2(PositionX,PositionY);   
        tp.to = new Vector2(PositionX, PositionY);
        
    }
	
	

 

	void Update () {
       
        
        //重置移动参数
        if (!isMoving)
        {
            if (transform.localPosition != new Vector3(PositionX, PositionY, 0))
            {
                isMoving = true;
                tp.from = transform.localPosition;

                tp.to = new Vector3(PositionX, PositionY, 0);
                tp.ResetToBeginning();
                tp.PlayForward();
            }
        }
       


    }

    public void OnMoveOver()
    {
       //移动完成 计算分数
        if (!mana._instance.hasCacu)
        {
        
            mana._instance.Score += mana._instance.deltaScore;
            
            mana._instance.hasCacu = true;
        }

        isMoving = false;
        if (toDestory)
        {
            
            Destroy(this.gameObject);
 
        }
       
    mana._instance.isMovingNumbers.Remove(this);

    }
    //向右 向上移动
    public void Move2(int directionX,int directionY)
    {
        if (directionX == 1)
        {
            int index = 1;
            while (mana._instance.isEmpty(PositionX + index, PositionY))
            {
                index++;
            }
            if (index > 1)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionX = PositionX + index - 1;
                mana._instance.numbers[PositionX, PositionY] = this;
            }
            if (PositionX < 3 && value == mana._instance.numbers[PositionX + 1, PositionY].value)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                toDestory = true; 
                mana._instance.deltaScore += value;
                mana._instance.numbers[PositionX + 1, PositionY].value *= 2;

                mana._instance.numbers[PositionX + 1, PositionY].GetComponent<SpriteRenderer>().sprite = mana._instance.nmanager.manager[(mana._instance.valueToNumber(mana._instance.numbers[PositionX + 1, PositionY].value)) - 1];
                if (mana._instance.numbers[PositionX + 1, PositionY].value == 4096)
                {
                    mana.isWin = true;
                    mana._instance.OnGameWin();
                }

                mana._instance.numbers[PositionX, PositionY] = null;

                PositionX += 1;
            }

        }

        if (directionY == 1)
        {
            int index = 1;
            while (mana._instance.isEmpty(PositionX, PositionY + index))
            {
                index++;
            }
            if (index > 1)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionY = PositionY + index - 1;
                mana._instance.numbers[PositionX, PositionY] = this;
            }
            if (PositionY < 3 && value == mana._instance.numbers[PositionX, PositionY + 1].value)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                toDestory = true;
                mana._instance.deltaScore += value;
                mana._instance.numbers[PositionX, PositionY + 1].value *= 2;

                mana._instance.numbers[PositionX, PositionY + 1].GetComponent<SpriteRenderer>().sprite = mana._instance.nmanager.manager[(mana._instance.valueToNumber(mana._instance.numbers[PositionX, PositionY + 1].value)) - 1];

                if (mana._instance.numbers[PositionX, PositionY + 1].value == 4096)
                {
                    mana.isWin = true;
                    mana._instance.OnGameWin();
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionY += 1;
            }
        }

    }

    //向左 向下移动
    public void Move1(int directionX,int directionY)
    {
        
        
        if (directionX == -1)
        {
            int index = 1;
            while (mana._instance.isEmpty(PositionX - index, PositionY))
            {
                index++;
            }
            if (index > 1)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionX = PositionX - index + 1;
                mana._instance.numbers[PositionX, PositionY] = this;
            }
            if (PositionX > 0 && value == mana._instance.numbers[PositionX - 1, PositionY].value)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                toDestory = true;
                mana._instance.deltaScore += value;
                mana._instance.numbers[PositionX - 1, PositionY].value *= 2;
               
                mana._instance.numbers[PositionX - 1, PositionY].GetComponent<SpriteRenderer>().sprite = mana._instance.nmanager.manager[(mana._instance.valueToNumber(mana._instance.numbers[PositionX - 1, PositionY].value)) - 1];
                if (mana._instance.numbers[PositionX - 1, PositionY].value == 4096)
                {
                    mana.isWin = true;
                    mana._instance.OnGameWin();
                }
               
                mana._instance.numbers[PositionX, PositionY] = null;

                PositionX -= 1;
            }
        }
   
        if (directionY == -1)
        {
            int index = 1;
            while (mana._instance.isEmpty(PositionX , PositionY - index))
            {
                index++;
            }
            if (index > 1)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionY = PositionY - index + 1;
                mana._instance.numbers[PositionX, PositionY] = this;
            }
            if (PositionY > 0 && value == mana._instance.numbers[PositionX, PositionY - 1].value)
            {
                mana._instance.hasMove = true;
                if (!mana._instance.isMovingNumbers.Contains(this))
                {
                    mana._instance.isMovingNumbers.Add(this);
                }
                toDestory = true;
                mana._instance.deltaScore += value;
                mana._instance.numbers[PositionX, PositionY - 1].value *= 2;
                mana._instance.numbers[PositionX, PositionY - 1].GetComponent<SpriteRenderer>().sprite = mana._instance.nmanager.manager[(mana._instance.valueToNumber(mana._instance.numbers[PositionX, PositionY - 1].value)) - 1];
                if (mana._instance.numbers[PositionX, PositionY - 1].value == 4096)
                {
                    mana.isWin = true;
                    mana._instance.OnGameWin();
                }
                mana._instance.numbers[PositionX, PositionY] = null;
                PositionY -= 1;
            }
        }
    }

 
}
