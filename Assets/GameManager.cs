using UnityEngine;

namespace App
{
  public class GameManager : MonoBehaviour
  {
    private class Person
    { 
      public string Name { get; }
      public int hp { get; set; }
      public Person(string name)
     {
        Name = name; 
        hp = 100; 
     }
    }

  private Person[] players;
  private void Awake()
   {
       players = new Person[]
       {
           new Person("あいうえお"),
           new Person("かきくけこ"),
           new Person("さしすせそ")
       };
   }
  private  void Update()
   {
    if(players != null)
      {
          players[0].hp -= 10;
          Debug.Log(players[0].Name + ":" + players[0].hp);
          players[1].hp -= 10;
          Debug.Log(players[1].Name + ":" + players[1].hp);
          players[2].hp -= 10;
          Debug.Log(players[2].Name + ":" + players[2].hp);
      } 
   }
 }
}