using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}

public class Program
{
    public static void Main()
    {
        // 무기 정보 입력
        Weapon[] weapons = new Weapon[4];

        weapons[0] = new Weapon("Sword", 40);
        weapons[1] = new Weapon("Bow", 35);
        weapons[2] = new Weapon("Axe", 50);
        weapons[3] = new Weapon("Magic Staff", 60);

        // 모든 무기 정보 출력
        Console.WriteLine("Weapons Information:");
        foreach (Weapon weapon in weapons)
        {
            Console.WriteLine($"Weapon Name: {weapon.Name}");
            Console.WriteLine($"Damage: {weapon.Damage}");
            Console.WriteLine();
        }
    }
}
