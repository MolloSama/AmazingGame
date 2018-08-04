using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IllustrationSave{
    private Dictionary<GameProp, bool> cardIllustration = new Dictionary<GameProp, bool>();
    private Dictionary<GameProp, bool> itemIllustration = new Dictionary<GameProp, bool>();
    private Dictionary<Monster, bool> monsterIllustration = new Dictionary<Monster, bool>();

    public Dictionary<GameProp, bool> CardIllustration
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

    public Dictionary<GameProp, bool> ItemIllustration
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

    public Dictionary<Monster, bool> MonsterIllustration
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
