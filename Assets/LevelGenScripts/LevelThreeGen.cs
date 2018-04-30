using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeGen : MonoBehaviour {
    private float offsetX = 0;
    private int GuardCounter=0;

    private float offsetY = 0;
    private int maxX = 12;
    private int maxY = 8;


    public static GameObject[,] Dark;
    public static int[,] iDark;
    private GameObject Guard;
	public GameObject LeftShell;// = GameObject.Find("LeftShell");
	public GameObject RightShell;// = GameObject.Find("RightShell");
	public GameObject NormalShell;// = GameObject.Find("NormalShell");

    public GameObject NormalRoom1;//  = GameObject.Find("NormalRoom1");
    public GameObject NormalRoom2;//  = GameObject.Find("NormalRoom2");
    public GameObject NormalRoom3;// = GameObject.Find("NormalRoom3");
    public GameObject NormalRoom4;// = GameObject.Find("NormalRoom4");
	public GameObject NormalRoom5;// = GameObject.Find("NormalRoom5");
	public GameObject NormalRoom6;// = GameObject.Find("NormalRoom6");
	public GameObject NormalRoom7;// = GameObject.Find("NormalRoom7");
	public GameObject NormalRoom8;// = GameObject.Find("NormalRoom8");
	public GameObject NormalRoom9;// = GameObject.Find("NormalRoom9");
	public GameObject NormalRoom10;// = GameObject.Find("NormalRoom10");
	public GameObject NormalRoom11;// = GameObject.Find("NormalRoom11");
	public GameObject NormalRoom12;// = GameObject.Find("NormalRoom12");
	public GameObject NormalRoom13;// = GameObject.Find("NormalRoom13");
	public GameObject NormalRoom14;// = GameObject.Find("NormalRoom14");
	public GameObject NormalRoom15;// = GameObject.Find("NormalRoom15");
    public GameObject LeftRoom;// = GameObject.Find("LeftRoom");
    public GameObject RightRoom;// = GameObject.Find("RightRoom");
    public GameObject StairsUp;// = GameObject.Find("StairsUp");
    public GameObject StairsDown;// = GameObject.Find("StairsDown");
    public GameObject Darkness;// = GameObject.Find("Darkness");
    public GameObject TREASUREROOM;// = GameObject.Find("TREASUREROOM");
    
    public GameObject StartEndRoom;

    



    // Use this for initialization
    void Start()
    {
        UnityEngine.Cursor.visible = false;
        //Cursor.visible = false;

        Guard = GameObject.Find("Guard");
        
        //SecCamera = GameObject.FindGameObjectWithTag("SecCamera");
        Vector2 originPostion = transform.position;

        //Creates the Array

        
        int[,] level = new int[,] { 
			{0, 0, 2, 9, 1, 1, 1, 5},
			{0, 0, 4, 8, 1, 1, 9, 34},
			{0, 0, 3, 7, 0, 0, 3, 7},
			{0, 0, 4, 6, 0, 0, 4, 6},
			{0, 0, 3, 7, 0, 0, 3, 7},
			{4, 1, 1, 8, 1, 1, 9, 6},
			{3, 9, 1, 1, 1, 1, 8, 7},
			{4, 6, 0, 0, 4, 1, 1, 6},
			{3, 7, 0, 0, 3, 7, 0, 0},
			{4, 6, 0, 0, 4, 6, 0, 0},
			{3, 1, 1, 1, 8, 7, 0, 0},
			{25, 1, 1, 1, 1, 6, 0, 0}
		};

        int[,] iDark = new int[,] {  
			{0, 0, 1, 1, 1, 1, 1, 1},
			{0, 0, 1, 1, 1, 1, 1, 1},
			{0, 0, 1, 1, 0, 0, 1, 1},
			{0, 0, 1, 1, 0, 0, 1, 1},
			{0, 0, 1, 1, 0, 0, 1, 1},
			{1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 0, 0, 1, 1, 1, 1},
			{1, 1, 0, 0, 1, 1, 0, 0},
			{1, 1, 0, 0, 1, 1, 0, 0},
			{1, 1, 1, 1, 1, 1, 0, 0},
			{1, 1, 1, 1, 1, 1, 0, 0}
		};

        GameObject[,] Dark= new GameObject[maxX,maxY];


int prev = -1;

//* Randomizing the Normal Rooms *//
//Debug.Log("Randomizing the Array");
for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                //Debug.Log(x + " " + y);
                //Vector3 offset = new Vector2(offsetY,offsetX);
                //Places NormalRooms
				//Debug.Log(x + " , " + y + " = " + level[x,y]);
                if (level[x, y] == 1)
                {
					int rand = Random.Range(1, 15);
					if(rand == prev){
						if(rand  == 15){
							rand -= 1;
						}
						rand +=1;
					}
					
					if(rand == 1){
						level[x,y] = 10;
                        prev = 1;
					}
					else if(rand == 2)
					{
						level[x,y] = 11;
                        prev = 2;
					}
					else if(rand == 3)
					{
						level[x,y] = 12;
                        prev = 3;
					}
					else if(rand == 4)
					{
						level[x,y] = 13;
                        prev = 4;
					}
					else if(rand == 5)
					{
						level[x,y] = 14;
                        prev = 5;
					}
					else if(rand == 6)
					{
						level[x,y] = 15;
                        prev = 6;
					}
					else if(rand == 7)
					{
						level[x,y] = 16;
                        prev = 7;
					}
					else if(rand == 8)
					{
						level[x,y] = 17;
                        prev = 8;
					}
					else if(rand == 9)
					{
						level[x,y] = 18;
                        prev = 9;
					}
					else if(rand == 10)
					{
						level[x,y] = 19;
                        prev = 10;
					}
					else if(rand == 11)
					{
						level[x,y] = 20;
                        prev = 11;
					}
					else if(rand == 12)
					{
						level[x,y] = 21;
                        prev = 12;
					}
					else if(rand == 13)
					{
						level[x,y] = 22;
                        prev = 13;
					}
					else if(rand == 14)
					{
						level[x,y] = 23;
                        prev = 14;
					}
					else if(rand == 15)
					{
						level[x,y] = 24;
                        prev = 15;
					}	
                }   
            }
		}
        for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                if(x >0&&y>0){
                    if((level[x,y] == level[x-1,y]&&level[x-1,y] >=0)||(level[x,y] == level[x,y-1]&&level[x,y-1]>=0)){
                        while(level[x,y] == level[x-1,y]||level[x,y] == level[x,y-1]){
                            level[x,y] -= 1;
                            if(level[x,y] == 9){
                                level[x,y] += 2;
                            }
                        }
                    }
                }


            }
        }
/* 
for(int x = maxX-1; x>=0; x--){
    for(int y = 0; y < maxY; y++){
        Debug.Log("[" + x + "," + y +"]" + "=" + level[x,y]);
    }
    
}
*/
// Placing the Shells
//Debug.Log("Placing the Shells");
for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                
                //Debug.Log(x + " " +y);
				Vector3 offset = new Vector2(offsetY,offsetX);
				if(level[x,y] == 2 || level[x,y] == 3 || level[x,y] == 4||level[x,y] == 25){
					Instantiate(LeftShell, offset, Quaternion.identity);
					offsetY += 24;
				}
				else if(level[x,y] == 1 ||level[x,y] == 8 || level[x,y]== 9 || level[x,y] >= 10 && level[x,y] <= 24)
				{
                    Instantiate(NormalShell, offset, Quaternion.identity);
                    offsetY += 24;
				}
                else if(level[x,y]== 6 || level[x,y] == 5 || level[x,y] == 7 || level[x,y] == 34){
                    Instantiate(RightShell, offset, Quaternion.identity);
                    offsetY += 24;
                }
                else{offsetY += 24;}

			}
			offsetY = 0;
            offsetX += 9;
		}



 int randTR = Random.Range(0,2);
 if(randTR == 0){
    level[0,7] = 50;
 }
 else if(randTR == 1 || randTR == 2){
    level[1,7] = 50;
 }
 

//*Placing The Rooms */
offsetY = 3.66f;
offsetX=-4.94f;


//Debug.Log("Placing the Rooms");
        for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {   
               // Debug.Log(x + " " + y);
                Vector3 offset = new Vector2(offsetY,offsetX);
                Vector3 GuardOffset = new Vector2(offsetY,offsetX-2.5f);
				
                if((GuardCounter % 4 == 0) && x>5 && GuardCounter != 0 && level[x,y] != 0){
					//Debug.Log("Guard at " + x + " , " + y);
                    Instantiate(Guard, new Vector3(offsetY,offsetX-2.5f,0), Quaternion.identity);
                }
				
				if((x == 0 && y == 7)||(x == 1 && y == 3)||(x == 2 && y == 6) ||(x == 2 && y == 3)||(x == 3 && y == 7)||(x == 4 && y == 6)||
					(x == 4 && y == 2) ||(x == 5 && y == 6)){
					Instantiate(Guard, new Vector3(offsetY,offsetX-2.5f,0), Quaternion.identity);
				}


                //Places NormalRooms
                if (level[x,y] == 1 || level[x,y] >= 10 && level[x,y] <= 24)
                {
                    //Figures a random int for a random room to be placed
                    
                    if (level[x,y] == 10) {
                        Instantiate(NormalRoom1, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 11)
                    {
                        Instantiate(NormalRoom2, offset, Quaternion.identity);                    
                    }
                    else if(level[x,y] == 12)
                    {
                        Instantiate(NormalRoom3, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 13)
                    {
                        Instantiate(NormalRoom4, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 14){
                        Instantiate(NormalRoom5, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 15){
                        Instantiate(NormalRoom6, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 16){
                        Instantiate(NormalRoom7, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 17){
                        Instantiate(NormalRoom8, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 18){
                        Instantiate(NormalRoom9, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 19){
                        Instantiate(NormalRoom10, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 20){
                        Instantiate(NormalRoom11, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 21){
                        Instantiate(NormalRoom12, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 22){
                        Instantiate(NormalRoom13, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 23){
                        Instantiate(NormalRoom14, offset, Quaternion.identity);
                    }
                    else if(level[x,y] == 24){
                        Instantiate(NormalRoom15, offset, Quaternion.identity);
                    }

                    offsetY += 24;
                }
                else if(level[x,y] == 25){
                    Instantiate(StartEndRoom, offset, Quaternion.identity);
                    offsetY += 24;
                }
                else if (level[x, y] == 2 || level[x,y] == 5 || level[x,y] == 34)
                {
                    Instantiate(LeftRoom, offset, Quaternion.identity);
                    offsetY += 24;
                }/*
                else if (level[x, y] == 5)
                {
                    Instantiate(RightRoom, offset, Quaternion.identity);
                    offsetY += 24;
                }*/
                
                else if(level[x,y]== 50){
                    Instantiate(TREASUREROOM, offset, Quaternion.identity);
                    offsetY += 24;
                }
                
                else if(level[x,y] == 3 || level[x,y] == 6 || level[x,y] == 8){
                    Instantiate(StairsUp, offset, Quaternion.identity);
                    offsetY+=24;
                }
                else if(level[x,y] == 4 || level[x,y] == 7 || level[x,y] == 9){
                    Instantiate(StairsDown, offset, Quaternion.identity);
                    offsetY+=24;
                }
                
                else {offsetY += 24; }


                GuardCounter+=1;
            }
            offsetY = 3.66f;
            offsetX += 9;
        }
        //Create Dark Object Array
offsetX = -4.94f;
offsetY = 3.66f;

        for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                //Debug.Log(x + " , " + y);
               if(iDark[x,y] == 1){
                    Vector3 offsetD = new Vector3(offsetY,offsetX, 0);
                    Dark[x,y] = (GameObject)Instantiate(Darkness, offsetD, Quaternion.identity);
                    offsetY += 24;
                }
                else {
                    offsetY += 24;
                }
            }
        
            offsetY = 3.66f;
            offsetX += 9;
        }
    }

    

}
  

    /*public void Lighting(){
        //RandomLights.RandomOff(maxX,maxY);
        bool lit = false;
        int litCtr = 0;
        while(!lit){
            if(litCtr == ((maxX-1)*(maxY-1))){
                lit = true;
            }
            int randX = Random.Range(0,maxX);
            int randY = Random.Range(0,maxY);
			GameObject.Destroy(LevelOneGen.Dark[randX,randY].gameObject);

            litCtr ++;

            //}
        }*/
