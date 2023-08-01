namespace XperiaRPG.Scripts.Items
{
    public abstract class Potion : Item
{
    public int Potency { get; set; }
    public string Effect { get; set; }

    protected Potion(int id, int quantity, string name, int price, string description, int potency, string effect) : base(quantity,
        name, description, price)
    {
        Effect = effect;
    }

    public abstract override void Use();
}
/*
public class HealingPotion : Potion
{
    public HealingPotion(int id, int quantity, string name, string description, int potency, string effect) : base(id,
        quantity, name, description, potency, effect)
    {
        Effect = "Healing";
    }

    public override void Use()
    {
        // Heal the user 
    }
}

public class DamagingPotion : Potion
{
    public DamagingPotion(int id, int quantity, string name, string description, int potency, string effect) : base(id,
        quantity, name, description, potency, effect)
    {
        Name = name;
        Description = description;
        Effect = "Damaging";
    }

    public override void Use()
    {
        // Damage the enemy
    }
}

public class TeleportPotion : Potion
{

    public TeleportPotion(int id, int quantity, string name, string description, int potency, string effect) : base(id,
        quantity, name, description, potency, effect)
    {
        Name = name;
        Description = description;
        Effect = "Teleport";
    }

    public override void Use()
    {
        // Teleports the player to their base / city
    }
}

// template for resistance potions
public class ResistPotion : Potion
{
    public string ResistanceType { get; set; }
    public int Duration { get; set; }

    public ResistPotion(int id, int quantity, string name, string description, string resistanceType, int potency,
        int duration, string effect) : base(id, quantity, name, description, potency, effect)
    {
        Effect = "Resistance";
        Name = name;
        Description = description;
        ResistanceType = resistanceType;
        Duration = duration;
    }

    public override void Use()
    {
    }
}
*/
}