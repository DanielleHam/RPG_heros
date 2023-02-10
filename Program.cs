// See https://aka.ms/new-console-template for more information
using rpg_heros_c.equipment;
using rpg_heros_c.Heros;

Weapon commonAxe = new Weapon("Common Axe", rpg_heros_c.enums.WeaponType.Axes, 2, 1);

Armor plate = new Armor("Common Plate Chest", rpg_heros_c.enums.EquipmentSlots.Body, rpg_heros_c.enums.ArmorType.Plate, 1, 1, 0,0);


Warrior newHero= new Warrior("Dan");

Console.WriteLine("hello");


Console.WriteLine(newHero.Display());

newHero.SetWeapon(commonAxe);

newHero.SetArmor(plate);

Console.WriteLine(newHero.Display());




