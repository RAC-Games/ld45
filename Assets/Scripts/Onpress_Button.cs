using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Onpress_Button : MonoBehaviour{
 public UnityEvent OnButtonPressed=new UnityEvent();
 void OnTriggerEnter(Collider other){OnButtonPressed.Invoke();
 print(other);}
 }