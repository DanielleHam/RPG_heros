// See https://aka.ms/new-console-template for more information
using rpg_heros_c.enums;
using rpg_heros_c.equipment;
using rpg_heros_c.Heros;

Console.WriteLine("hello");
Weapon commonWand = new("Common Wand", WeaponType.Wands, 2, 1);
Armor cloth = new Armor("Common cloth cape", EquipmentSlots.Body, ArmorType.Cloth, 1, 0, 1, 2);


Mage newHero = new Mage("Dan");


Console.WriteLine(newHero.Display()); 

