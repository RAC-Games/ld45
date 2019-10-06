using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doortimer : MonoBehaviour{
public float timer=0;
public float Maxzeit;
public bool timer_is_running=false;
private Animator animator;
public Text text;


void Start(){
animator=GetComponent<Animator>();}
   
    void Update()
    {
	if (timer_is_running==true){
		
		 timer -= Time.deltaTime;
		 text.text = timer.ToString("##");
		 if (0>timer)
		 {
		 close_door();
		 timer_is_running=false;}
	}}

	public void starttimer(){
	timer=Maxzeit;
	timer_is_running=true;

	}
	public void close_door(){
	animator.SetTrigger("Door_close");
	}
	
	public void open_door(){
		animator.SetTrigger("Door_open");
	}

}