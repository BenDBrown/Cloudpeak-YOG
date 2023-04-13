using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool weapon = false;

    public string itemName;

    public int vitality;
    public int physicalAttack;
    public int magicalAttack;
    public int physicalDefense;
    public int magicalDefense;
    public int speed;
    public string itemType;
    public int spritePosition;

    private Sprite sprite;

    public List<Sprite> swordSprites = new List<Sprite>();
    public List<Sprite> axeSprites = new List<Sprite>();
    public List<Sprite> staffSprites = new List<Sprite>();
    public List<Sprite> armourSprites = new List<Sprite>();
    public List<Sprite> speedArmourSprites = new List<Sprite>();
    public List<Sprite> magicalArmourSprites = new List<Sprite>();

    private List<string> swordTypes = new List<string>();
    private List<string> axeTypes = new List<string>();
    private List<string> staffTypes = new List<string>();
    private List<string> magicArmourTypes = new List<string>();
    private List<string> speedArmourTypes = new List<string>();
    private List<string> armourTypes = new List<string>();

    private List<string> physicalAdjectives = new List<string>();
    private List<string> magicalAdjectives = new List<string>();

    private int nrOfGreater = 0;
    private int nrOfGood = 0;

    public void Randomize(int level)
    {
        vitality = 0;
        physicalAttack = 0;
        magicalAttack = 0;
        physicalDefense = 0;
        magicalDefense = 0;
        speed = 0;

        int w = Random.Range(0, 2);
        if(w == 0)
        {
            weapon = true;
        }    

        int nrOfValues = Random.Range(1, 7);
        nrOfGreater = Random.Range(0, 3);
        nrOfGood = Random.Range(0, 3);
        List<int> values = new List<int>();

        for(int i = 0; i < nrOfValues; i++)
        {
            values.Add(GetValue(level));
        }

        if (weapon)
        {
            int r = Random.Range(0, 2);
            if(r == 0)
            {
                values.Sort();
                values.Reverse();
                physicalAttack = values[0];
                Debug.Log(physicalAttack);
                values.RemoveAt(0);
            }
            else
            {
                values.Sort();
                values.Reverse();
                magicalAttack = values[0];
                values.RemoveAt(0);
            }
            foreach(int value in values)
            {
                SeedToUnassignedValue(value);
            }
        }
        else
        {
            int r = Random.Range(0, 6);
            if(r == 0)
            {
                values.Sort();
                values.Reverse();
                magicalAttack = values[0];
                values.RemoveAt(0);

            }
            else if (r == 1)
            {
                values.Sort();
                values.Reverse();
                magicalDefense = values[0];
                values.RemoveAt(0);
            }
            else if (r > 1 && r < 4)
            {
                values.Sort();
                values.Reverse();
                physicalDefense = values[0];
                values.RemoveAt(0);
            }
            else if (r > 3)
            {
                values.Sort();
                values.Reverse();
                speed = values[0];
                values.RemoveAt(0);
            }
            foreach (int value in values)
            {
                SeedToUnassignedValue(value);
            }
        }
        MakeName();
    }

    void SeedToUnassignedValue(int value)
    {
        float breakerSwitch = 0;
        while (1 > 0)
        {
            int r = Random.Range(0, 6);
            if(r == 0 && vitality == 0)
            {
                vitality = value;
                break;
            }
            else if(r == 1 && physicalAttack == 0)
            {
                physicalAttack = value;
                break;
            }
            else if (r == 2 && magicalAttack == 0)
            {
                magicalAttack = value;
                break;
            }
            else if (r == 3 && physicalDefense == 0)
            {
                physicalDefense = value;
                break;
            }
            else if (r == 4 && magicalDefense == 0)
            {
                magicalDefense = value;
                break;
            }
            else if (r == 5 && speed == 0)
            {
                speed = value;
                break;
            }
            if(breakerSwitch == 100000000)
            {
                Debug.Log("either u just used up a lifetime of luck and won nothing, or the random item generation is broken");
                break;
            }
            breakerSwitch++;
        }
        
    }

    int GetValue(int level)
    {
        if (nrOfGreater > 0)
        {
            nrOfGreater--;
            return GetGreaterValue(level);
        }
        else if (nrOfGood > 0)
        {
            nrOfGood--;
            return GetGoodValue(level);
        }
        else
        {
            return GetLesserValue(level);
        }
    }

    int GetGreaterValue(int level)
    {
        int topRange = level + 10;
        int bottomRange = level + 4;
        int ret = Random.Range(bottomRange, topRange);
        return ret;
    }
    int GetLesserValue(int level)
    {
        int topRange = level + 5;
        int bottomRange = level;
        int ret = Random.Range(bottomRange, topRange);
        return ret;
    }
    int GetGoodValue(int level)
    {
        int topRange = level + 8;
        int bottomRange = level + 2;
        int ret = Random.Range(bottomRange, topRange);
        return ret;
    }
    
    void MakeName()
    {
        itemName = "";
        swordTypes.Clear();
        axeTypes.Clear();
        staffTypes.Clear();
        magicArmourTypes.Clear();
        speedArmourTypes.Clear();
        armourTypes.Clear();
        physicalAdjectives.Clear();
        magicalAdjectives.Clear();

        if (weapon)
        {
            swordTypes.Add("sword");
            swordTypes.Add("blade");
            swordTypes.Add("longsword");
            swordTypes.Add("claymore");
            swordTypes.Add("shortsword");
            swordTypes.Add("flamberge");
            swordTypes.Add("greatsword");
            swordTypes.Add("bastard sword");
            swordTypes.Add("zweihänder");
            swordTypes.Add("cutlass");
            swordTypes.Add("rapier");
            swordTypes.Add("sabre");
            swordTypes.Add("katana");

            axeTypes.Add("hatchet");
            axeTypes.Add("battle axe");
            axeTypes.Add("halberd");
            axeTypes.Add("axe");
            axeTypes.Add("war axe");
            axeTypes.Add("great axe");
            axeTypes.Add("short axe");
            axeTypes.Add("tomahawk");
            axeTypes.Add("hand axe");

            staffTypes.Add("staff");
            staffTypes.Add("wand");
            staffTypes.Add("rod");
        }
        else
        {
            magicArmourTypes.Add("robe");
            magicArmourTypes.Add("dress");
            magicArmourTypes.Add("vestment");
            magicArmourTypes.Add("cassock");
            magicArmourTypes.Add("veil");
            magicArmourTypes.Add("garment");

            speedArmourTypes.Add("tunic");
            speedArmourTypes.Add("vest");
            speedArmourTypes.Add("brigandine");
            speedArmourTypes.Add("lamellar vest");

            armourTypes.Add("chestplate");
            armourTypes.Add("battle armour");
            armourTypes.Add("spike carapace");
            armourTypes.Add("carapace");
            armourTypes.Add("gambeson");
            armourTypes.Add("mail");
            armourTypes.Add("plate armour");
            armourTypes.Add("hauberk");
            armourTypes.Add("laminar armour");
            armourTypes.Add("vambrace");
        }

        physicalAdjectives.Add("destroyer's");
        physicalAdjectives.Add("god butcher's");
        physicalAdjectives.Add("king slayer's");
        physicalAdjectives.Add("batlle hardened");
        physicalAdjectives.Add("veteran's");
        physicalAdjectives.Add("conquerer's");
        physicalAdjectives.Add("vanguard's");
        physicalAdjectives.Add("blood stained");
        physicalAdjectives.Add("enchanted");
        physicalAdjectives.Add("hero's");
        physicalAdjectives.Add("champion's");
        physicalAdjectives.Add("legendary");
        physicalAdjectives.Add("hell touched");
        physicalAdjectives.Add("infernal");
        physicalAdjectives.Add("sky forged");
        physicalAdjectives.Add("berserker's");
        physicalAdjectives.Add("deathbringer's");
        physicalAdjectives.Add("knight's");
        physicalAdjectives.Add("lord's");
        physicalAdjectives.Add("soldier's");
        physicalAdjectives.Add("duelist's");
        physicalAdjectives.Add("warmonger's");
        physicalAdjectives.Add("dragon horn");

        magicalAdjectives.Add("sage's");
        magicalAdjectives.Add("grand wizard's");
        magicalAdjectives.Add("eon");
        magicalAdjectives.Add("elder's");
        magicalAdjectives.Add("dragon eye");
        magicalAdjectives.Add("phoenix");
        magicalAdjectives.Add("old god's");
        magicalAdjectives.Add("legendary");
        magicalAdjectives.Add("mage's");
        magicalAdjectives.Add("grand mage's");
        magicalAdjectives.Add("wizard's");
        magicalAdjectives.Add("sorcerer's");
        magicalAdjectives.Add("grand sorcerer's");
        magicalAdjectives.Add("witch's");
        magicalAdjectives.Add("omnipotence");
        magicalAdjectives.Add("focus");
        magicalAdjectives.Add("super charged");
        magicalAdjectives.Add("blessed");
        magicalAdjectives.Add("griphon feather");


        if (weapon && IsHighestStat(physicalAttack))
        {
            int r = Random.Range(0, 2);
            if (r == 1)
            {
                r = Random.Range(0, swordTypes.Count);
                itemName = swordTypes[r];
                r = Random.Range(0, swordSprites.Count);
                sprite = swordSprites[r];
                spritePosition = r;
                itemType = "sword";
            }
            else
            {
                r = Random.Range(0, axeTypes.Count);
                itemName = axeTypes[r];
                r = Random.Range(0, axeSprites.Count);
                sprite = axeSprites[r];
                spritePosition = r;
                itemType = "axe";
            }
            r = Random.Range(0, physicalAdjectives.Count);
            itemName = physicalAdjectives[r] + " " + itemName; 
        }
        else if (weapon && IsHighestStat(magicalAttack))
        {
            int r = Random.Range(0, staffTypes.Count);
            itemName = staffTypes[r];
            r = Random.Range(0, magicalAdjectives.Count);
            itemName = magicalAdjectives[r] + " " + itemName;
            r = Random.Range(0, staffSprites.Count);
            sprite = staffSprites[r];
            spritePosition = r;
            itemType = "staff";
        }
        else if(weapon == false && IsHighestStat(physicalDefense) || IsHighestStat(vitality))
        {
            int r = Random.Range(0, armourTypes.Count);
            itemName = armourTypes[r];
            r = Random.Range(0, physicalAdjectives.Count);
            itemName = physicalAdjectives[r] + " " + itemName;
            r = Random.Range(0, armourSprites.Count);
            sprite = armourSprites[r];
            spritePosition = r;
            itemType = "armour";
        }
        else if (weapon == false && IsHighestStat(magicalDefense) || IsHighestStat(magicalAttack))
        {
            int r = Random.Range(0, magicArmourTypes.Count);
            itemName = magicArmourTypes[r];
            r = Random.Range(0, magicalAdjectives.Count);
            itemName = magicalAdjectives[r] + " " + itemName;
            r = Random.Range(0, magicalArmourSprites.Count);
            sprite = magicalArmourSprites[r];
            spritePosition = r;
            itemType = "marmour";
        }
        else
        {
            int r = Random.Range(0, speedArmourTypes.Count);
            itemName = speedArmourTypes[r];
            r = Random.Range(0, physicalAdjectives.Count);
            itemName = physicalAdjectives[r] + " " + itemName;
            r = Random.Range(0, speedArmourSprites.Count);
            sprite = speedArmourSprites[r];
            spritePosition = r;
            itemType = "sarmour";
        }
        Debug.Log(itemName);
    }

    bool IsHighestStat(int stat)
    {
        if(stat < vitality)
        {
            return false;
        }
        else if (stat < physicalAttack)
        {
            return false;
        }
        else if (stat < magicalAttack)
        {
            return false;
        }
        else if (stat < physicalDefense)
        {
            return false;
        }
        else if (stat < magicalDefense)
        {
            return false;
        }
        else if (stat < speed)
        {
            return false;
        }

        return true;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public int GetQuality()
    {
        int quality = 0;
        quality += vitality;
        quality += physicalAttack;
        quality += magicalAttack;
        quality += physicalDefense;
        quality += magicalDefense;
        quality += speed;
        return quality;
    }
    
    public void SetSprite(Sprite sprite)
    {

        this.sprite = sprite;

    }

    public List<Sprite> GetSpriteList(string itemType)
    {
        if (itemType == "sword")
        {
            return swordSprites;
        }
        else if (itemType == "axe")
        {
            return axeSprites;
        }
        else if (itemType == "staff")
        {
            return staffSprites;
        }
        else if (itemType == "armour")
        {
            return armourSprites;
        }
        else if (itemType == "marmour")
        {
            return magicalArmourSprites;
        }
        else
        {
            return speedArmourSprites;
        }
    }

}
