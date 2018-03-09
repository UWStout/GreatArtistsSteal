using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneGen : MonoBehaviour {
    private float offsetX = 0;
    private float offsetY = 0;
    private int maxX = 7;
    private int maxY = 10;

	public GameObject LeftShell;
	public GameObject RightShell;
	public GameObject NormalShell;

    public GameObject NormalRoom1;
    public GameObject NormalRoom2;
    public GameObject NormalRoom3;
    public GameObject NormalRoom4;
	public GameObject NormalRoom5;
	public GameObject NormalRoom6;
	public GameObject NormalRoom7;
	public GameObject NormalRoom8;
	public GameObject NormalRoom9;
	public GameObject NormalRoom10;
	public GameObject NormalRoom11;
	public GameObject NormalRoom12;
	public GameObject NormalRoom13;
	public GameObject NormalRoom14;
	public GameObject NormalRoom15;
    public GameObject LeftRoom;
    public GameObject RightRoom;
    public GameObject LeftStairsDown;
    public GameObject LeftStairsUp;
    public GameObject RightStairsDown;
    public GameObject RightStairsUp;
    public GameObject NormalStairsDown;
    public GameObject NormalStairsUp;

    public GameObject TREASUREROOM;


    // Use this for initialization
    void Start()
    {

        Vector2 originPostion = transform.position;

        //Creates the Array
        
        int[,] level = new int[,] { { 4, 1, 5, 0, 0, 0, 0, 2, 9, 5 },
                                    { 3, 1, 7, 0, 0, 0, 0, 4, 8, 7 },
                                    { 4, 1, 8, 1, 1, 1, 1, 8, 1, 6 },
                                    { 3, 1, 1, 1, 1, 1, 1, 1, 1, 7 },
                                    { 4, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
                                    { 3, 1, 1, 1, 1, 1, 1, 1, 1, 7 },
                                    { 2, 1, 1, 1, 1, 1, 1, 1, 1, 6 }, };

        



int prev = -1;

//* Randomizing the Normal Rooms *//
Debug.Log("Randomizing the Array");
for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                
                //Debug.Log(x + " " + y);
                Vector3 offset = new Vector2(offsetY,offsetX);
                //Places NormalRooms
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
					}
					else if(rand == 2)
					{
						level[x,y] = 11;
					}
					else if(rand == 3)
					{
						level[x,y] = 12;
					}
					else if(rand == 4)
					{
						level[x,y] = 13;
					}
					else if(rand == 5)
					{
						level[x,y] = 14;
					}
					else if(rand == 6)
					{
						level[x,y] = 15;
					}
					else if(rand == 7)
					{
						level[x,y] = 16;
					}
					else if(rand == 8)
					{
						level[x,y] = 17;
					}
					else if(rand == 9)
					{
						level[x,y] = 18;
					}
					else if(rand == 10)
					{
						level[x,y] = 19;
					}
					else if(rand == 11)
					{
						level[x,y] = 20;
					}
					else if(rand == 12)
					{
						level[x,y] = 21;
					}
					else if(rand == 13)
					{
						level[x,y] = 22;
					}
					else if(rand == 14)
					{
						level[x,y] = 23;
					}
					else if(rand == 15)
					{
						level[x,y] = 24;
					}
					prev = level[x,y];
                }
                
            }

		}



// Placing the Shells
Debug.Log("Placing the Shells");
for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                
                //Debug.Log(x + " " +y);
				Vector3 offset = new Vector2(offsetY,offsetX);
				if(level[x,y] == 2 || level[x,y] == 3 || level[x,y] == 4){
					Instantiate(LeftShell, offset, Quaternion.identity);
					offsetY += 24;
				}
				else if(level[x,y] == 1 ||level[x,y] == 8 || level[x,y]== 9 || level[x,y] >= 10 && level[x,y] <= 24)
				{
                    Instantiate(NormalShell, offset, Quaternion.identity);
                    offsetY += 24;
				}
                else if(level[x,y]== 6 || level[x,y] == 5 || level[x,y] == 7){
                    Instantiate(RightShell, offset, Quaternion.identity);
                    offsetY += 24;
                }
                else{offsetY += 24;}

			}
			offsetY = 0;
            offsetX += 9;
		}

// Finding the index of the treasure Room and
// making sure it is not supposed to be an empty Room or stair room
/* 
int randX = Random.Range(0,maxY-1);
int randY = Random.Range(5,6);
if(level[randX, randY] != 1 ||  level[randX,randY] != 5 ||  level[randX,randY] != 2  ){
    while(level[randX, randY] != 1 ||  level[randX,randY] != 5 ||  level[randX,randY] != 2){
        randX = Random.Range(0,maxY-1);
        randY = Random.Range(maxX-2,maxX-1);
        if(level[randX, randY] == 1 ||  level[randX,randY] == 5 ||  level[randX,randY] == 2){
            level[randX,randY] = 50;
        }
    }
}

//*Placing The Rooms */
offsetY = 3.66f;
offsetX=-4.94f;
Debug.Log("Placing the Rooms");
        for (int x = maxX-1; x >= 0; x--)
        {
            for (int y = 0; y < maxY; y++)
            {
                
                Debug.Log(x + " " + y);
                Vector3 offset = new Vector2(offsetY,offsetX);
                //Places NormalRooms
                if (level[x,y] == 1 ||level[x,y] == 8 || level[x,y]== 9 || level[x,y] >= 10 && level[x,y] <= 24)
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
                //Right Rooms
                else if (level[x, y] == 2)
                {
                    Instantiate(RightRoom, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Right Stairs Up
                else if (level[x, y] == 3)
                {
                    Instantiate(RightStairsUp, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Right Stairs Down
                else if (level[x, y] == 4)
                {
                    Instantiate(RightStairsDown, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Left Rooms
                else if (level[x, y] == 5)
                {
                    Instantiate(LeftRoom, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Left Stairs Up
                else if (level[x, y] == 6)
                {
                    Instantiate(LeftStairsUp, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Left Stairs Down
                else if (level[x, y] == 7)
                {
                    Instantiate(LeftStairsDown, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Normal Stairs Up
                else if (level[x, y] == 8)
                {
                    Instantiate(NormalStairsUp, offset, Quaternion.identity);
                    offsetY += 24;
                }
                //Normal Stairs Down
                else if (level[x, y] == 9)
                {
                    Instantiate(NormalStairsDown, offset, Quaternion.identity);
                    offsetY += 24;
                }
                else if(level[x,y]== 50){
                    Instantiate(TREASUREROOM, offset, Quaternion.identity);
                    offsetY += 24;
                }
                else { offsetY += 24; }


                
            }
            offsetY = 3.66f;
            offsetX += 9;
        }
}
}
