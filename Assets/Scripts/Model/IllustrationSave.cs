using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IllustrationSave{
    private Dictionary<string, bool> cardIllustration = new Dictionary<string, bool>();
    private Dictionary<string, bool> itemIllustration = new Dictionary<string, bool>();
    private Dictionary<string, bool> monsterIllustration = new Dictionary<string, bool>();

    public Dictionary<string, bool> CardIllustration
    {
        get
        {
            return cardIllustration;
        }

        set
        {
            cardIllustration = value;
        }
    }

    public Dictionary<string, bool> ItemIllustration
    {
        get
        {
            return itemIllustration;
        }

        set
        {
            itemIllustration = value;
        }
    }

    public Dictionary<string, bool> MonsterIllustration
    {
        get
        {
            return monsterIllustration;
        }

        set
        {
            monsterIllustration = value;
        }
    }

    public IllustrationSave()
    {
        cardIllustration = GlobalVariable.cardIllustration;
        itemIllustration = GlobalVariable.itemIllustration;
        monsterIllustration = GlobalVariable.monsterIllustration;
    }
}
