using UnityEngine;

namespace App
{
    public class hoge : MonoBehaviour
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

            Debug.Log(players[0].Name + ":" + players[0].hp);
            Debug.Log(players[1].Name + ":" + players[1].hp);
            Debug.Log(players[2].Name + ":" + players[2].hp);
        }
    }
}