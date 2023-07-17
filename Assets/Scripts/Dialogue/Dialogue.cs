using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //необходимо для сохранения
public class Dialogue
{
    [TextArea(3, 10)] //мин и макс кол-во строк, которое будет использовано в нашем пространстве диалога 
    public string[] sentences; // массив строк 
}
