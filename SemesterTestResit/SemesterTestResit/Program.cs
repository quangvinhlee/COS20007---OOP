using System;
using System.Security.Cryptography.X509Certificates;

namespace SemesterTestResit
{
    public class program
    {
        public static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Attack(5); // 5 damage

            arena.AttackAll(3); // 3 damage

            // Add 3 enemies
            arena.AddEnemy(new RegularEnemy()); 
            arena.AddEnemy(new RegularEnemy());
            arena.AddEnemy(new RegularEnemy());

            // Add invincible enemy
            arena.AddEnemy(new InvincibleEnemy());

            arena.Attack(10); // 10 damage

            arena.AttackAll(1); // 1 damage
        }
    }
}