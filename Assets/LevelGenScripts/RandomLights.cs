using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomLights {
	public static void RandomOff(int maxX, int maxY){
		bool lit = false;
        int litCtr = 0;
        while(!lit){
            if(litCtr == ((maxX-1)*(maxY-1))){
                lit = true;
            }
            int randX = Random.Range(0,maxX);
            int randY = Random.Range(0,maxY);
			GameObject.Destroy(LevelOneGen.Dark[randX,randY]);

            litCtr ++;

            //}
        }
	}
	
	
}
