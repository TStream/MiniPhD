// Mini PhD - 2013 //
///by  Jeff Thomas, Nico Walker, Tyler Bach //

// These classes define the different virii our intrepid Doctor must defeat //


using UnityEngine;
using System.Collections;


//Virus is the superclass that all our specific Virii are formed from.
public abstract class Virus : MonoBehaviour
{

	public const int MELEE = 1;
	public const int RANGED = 2;
	public double x, y;        //coordinates of virus sprite
	public int hp; //meleeDef, rangeDef;  I don't think we need to implement these Def stats after further consideration
	
	public float lifeTime;  //time virus has been alive.
	public float startTime; //time virus was born.
	public float spreadThreshold; //time after spawning until virii spreads.  Do we want this to vary between colors?
	public float currentTime;
	

	public abstract void takeDamage(int dmgType, int dmg);
	//dmgType tells us if the dmg is melee/ranged, and dmg is the base damage from weapon.  
	//ATM dmg is always 1 but it could change in future if we want upgrades or something
	
	
	
	//Upon reaching 0 hp, the virus's sprite and stored object needs to be cleaned up
	public abstract void virusDeath();
	
	
	
	//once the individual virus have passed a certain lifeTime threshold, it will spread and spawn new virii.
	public abstract void spread();
	

}



//These Virii are resistant to range damage.
public class BlueVirus : Virus
{
    public BlueVirus(double xPos, double yPos)
    {
        x = xPos;
		y = yPos;
		
		hp = 3;
		//meleeDef = 0;
		//rangeDef = 1;
		
		lifeTime = 0;
		spreadThreshold = 20;
    }
	
	
	void OnStart(){
		startTime = Time.time;
		currentTime= 0;
	}
	
	//controls Virus spread mechanic.
	void Update(){
		currentTime = Time.time;	
		if(currentTime - startTime > spreadThreshold){
		
		}
	}
	
	//upon trigger entry by a bullet, the virus takes dmg and bullet is destroyed
	void OnTriggerEnter(Collider col ){  
		if (col.gameObject.name == "LazerBeam")
		{
			takeDamage(RANGED, 1);
			Destroy(col);
		}
		
	}
	
	public override void takeDamage(int dmgType, int dmg){
		
		if (dmgType == MELEE){
			hp = hp - dmg;
		}
		
		if (hp <= 0){
			virusDeath();
		}
		
	}
	
	public override void spread(){
	
	}
	
	public override void virusDeath(){
	
	}
	

}



//These Virii have no increased resistance, but have large HP pools.  Spreads faster than others.
public class GreenVirus : Virus
{
    public GreenVirus(double xPos, double yPos)
    {
        x = xPos;
		y = yPos;
		
		hp = 6;
		//meleeDef = 0;
		//rangeDef = 0;
		
		lifeTime = 0;
		spreadThreshold = 12;
    }
	
	
	void OnStart(){
		startTime = Time.time; 
		currentTime= 0;
	}
	
	//controls Virus spread mechanic.
	void Update(){
		currentTime = Time.time;	
		if(currentTime - startTime > spreadThreshold){
		
		}
	}
	
	
	//upon trigger entry by a bullet, the virus takes dmg and bullet is destroyed
	void OnTriggerEnter(Collider col ){  
		if (col.gameObject.name == "LazerBeam")
		{
			takeDamage(RANGED, 1);
			Destroy(col);
		}
		
	}
	
	
	public override void takeDamage(int dmgType, int dmg){
		
		hp = hp - dmg;
		
		if (hp <= 0){
			virusDeath();
		}
	}
	
	
	public override void virusDeath(){
	
	}
	
	
	public override void spread(){
		
	
	}        
   
}



//These Virii are resistant to melee damage.
public class RedVirus : Virus
{
    public RedVirus(double xPos, double yPos)
    {
        x = xPos;
		y = yPos;
		
		hp = 3;
		//meleeDef = 0;
		//rangeDef = 0;
		
		lifeTime = 0;
		spreadThreshold = 20;
    }
	
		
	void OnStart(){
		startTime = Time.time;
		currentTime = 0;
	}
	
	//controls Virus spread mechanic.
	void Update(){
		currentTime = Time.time;	
		if(currentTime - startTime > spreadThreshold){
		
		
		}
	}
	
	//upon trigger entry by a bullet, the virus takes dmg and bullet is destroyed
	void OnTriggerEnter(Collider col ){  
		if (col.gameObject.name == "LazerBeam")
		{
			takeDamage(RANGED, 1);
			Destroy(col);
		}
		
	}
	
	
	public override void takeDamage(int dmgType, int dmg){

		if (dmgType == RANGED){
			hp = hp - dmg;
		}
		
		if (hp <= 0){
			virusDeath();
		}
	}
	
	
	public override void virusDeath(){
	
	}
	
	
	public override void spread(){
		

		
	}        
   
}