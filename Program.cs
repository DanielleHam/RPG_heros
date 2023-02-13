// See https://aka.ms/new-console-template for more information
using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.Heros;

Weapon commonAxe = new Weapon("Common Axe", WeaponType.Axes, 2, 1);

Armor plate = new Armor("Common Plate Chest", EquipmentSlots.Body, ArmorType.Plate, 1, 1, 0,0);


Warrior newHero= new Warrior("Dan");

Console.WriteLine("hello");


Console.WriteLine(newHero.Display());

newHero.SetWeapon(commonAxe);

newHero.SetArmor(plate);

Console.WriteLine(newHero.Display());




