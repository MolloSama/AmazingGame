using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour {
    public GameObject monstersPosition1;
    public GameObject monstersPosition2;
    public GameObject monstersPosition3;
    public GameObject monstersPosition4;
    public GameObject monstersPosition5;
    public GameObject monstersPosition6;
    public GameObject cardPrefab;
    public GameObject energy;
    public Transform cardStartPosition;
    public Transform cardEndPosition;
    public Transform cardOutPosition;
    public GameObject krakenObject;
    public GameObject statusIcon;
    public GameObject healthChangePrefab;
    public GameObject itemPrefab;
    public Transform itemFirstPosition;
    public Escape escape;
    public GameObject tipGameObject;
    public GameObject talentNamePrefab;
    public GameObject friendPosition1;
    public GameObject friendPosition2;
    [HideInInspector]
    public List<string> monsterNumber = new List<string>();
    private Dictionary<int, GameObject> handCardsSprite = new Dictionary<int, GameObject>();
    private Dictionary<int, GameProp> handCards = new Dictionary<int, GameProp>();
    private List<Monster> monsters = new List<Monster>();
    [HideInInspector]
    public bool isMonsterFight = false;
    [HideInInspector]
    public bool isMonsterRoundOver = false;
    private bool isFriendRoundOver = false;
    private Monster selectedMonster;
    [HideInInspector]
    public Monster kraken;
    private int maxEnergy = 5;
    private int currentEnergy;
    private static int orderIndex = -1;
    [HideInInspector]
    public bool isAnimationEnd = false;
    [HideInInspector]
    public Dictionary<int, GameObject> indexGameObjectReflect = new Dictionary<int, GameObject>();
    private Dictionary<GameObject, Monster> gameObjectMonsterReflect = new Dictionary<GameObject, Monster>();
    [HideInInspector]
    public Dictionary<GameProp, GameObject> itemSpriteReflect = new Dictionary<GameProp, GameObject>();
    [HideInInspector]
    public GameObject playButton;
    private Vector3 energyStartPosition;
    [HideInInspector]
    public int currentPage;
    [HideInInspector]
    public bool isDrawCard = false;
    public bool isItemAnimationEnd = true;
    private int krakenMaxHealth;
    private float krakenBaseAttact;
    private float krakenBaseDefend;
    private ItemCondition itemCondition = new ItemCondition();
    private bool isKrakenDeath = false;
    [HideInInspector]
    public List<GameProp> cardGroup = new List<GameProp>();
    public List<Monster> friendMonsters = new List<Monster>();
    private int maxCardCount = 14;
    private int drawCardCount = 0;
    private bool isTalent3Effect = false;

    // Use this for initialization
    void Start() {
        SetMosters();
        GlobalVariable.sceneMonsterNumber = monsterNumber;
        cardGroup = DeepCopy(GlobalVariable.FightCards);
        AddCards(4, cardEndPosition.position, false);
        foreach (Monster monster in gameObjectMonsterReflect.Values)
        {
            monsters.Add(monster);
        }
        kraken = DeepCopy(GlobalVariable.kraKen);
        kraken.BloodVolume = GlobalVariable.currentBlood;
        krakenMaxHealth = GlobalVariable.kraKen.BloodVolume;
        krakenBaseAttact = GlobalVariable.kraKen.AttactPower;
        krakenBaseDefend = GlobalVariable.kraKen.DefensivePower;
        gameObjectMonsterReflect.Add(krakenObject, kraken);
        currentEnergy = maxEnergy;
        playButton = GameObject.Find("playButton");
        energyStartPosition = energy.transform.position;
        InitializeItem();
    }
	
	// Update is called once per frame
	void Update () {
        if (isKrakenDeath)
        {
            SceneManager.LoadScene("gameOver");
        }
        if(monsters.Count == 0)
        {
            SceneManager.LoadScene("settlement");
        }
        if (RenderMonster.currentIndex != -1)
        {
            selectedMonster = gameObjectMonsterReflect
             [indexGameObjectReflect[RenderMonster.currentIndex]];
        }
        if (isMonsterFight)
        {
            StartCoroutine(MonsterRound(friendMonsters, monsters, true));
        }
        if (isFriendRoundOver)
        {
            friendMonsters.Add(kraken);
            StartCoroutine(MonsterRound(monsters, friendMonsters, false));
            isFriendRoundOver = false;
            isMonsterFight = false;
        }
        if (playButton != null)
        {

            if ((CardAction.isCardSelected && RenderMonster.needClickMonster
            && RenderMonster.isMonsterSelected && !isMonsterFight) ||
            (CardAction.isCardSelected && !RenderMonster.needClickMonster && !isMonsterFight))
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }
    }

    IEnumerator StartMonsterRound()
    {
        yield return new WaitForSeconds(1f);

    }

    private void OnDestroy()
    {
        GlobalVariable.currentBlood = kraken.BloodVolume;
    }

    private void EffectPropertyItem(GameProp item)
    {
        switch (item.Type)
        {
            case "a4e1":
                kraken.AttactPower += krakenBaseAttact * item.Value;
                break;
            case "a4e2":
                kraken.DefensivePower += krakenBaseDefend * item.Value;
                break;
            case "a4e4":
                krakenMaxHealth += Mathf.RoundToInt(krakenMaxHealth * item.Value);
                kraken.BloodVolume = krakenMaxHealth;
                break;
            case "a4e6":
                kraken.AttactPower += krakenBaseAttact * item.Value;
                kraken.DefensivePower -= krakenBaseDefend * item.Value;
                break;
            case "a4e9":
                escape.demarcationline += System.Convert.ToInt32(item.Value * 100);
                break;
            case "a4e10":
                kraken.AttactPower += krakenBaseAttact * item.Value;
                kraken.DefensivePower += krakenBaseDefend * item.Value;
                break;
            case "a4e11":
                kraken.AttactPower += krakenBaseAttact * item.Value;
                break;
            case "a4e15":
                kraken.DefensivePower += krakenBaseDefend * item.Value;
                krakenMaxHealth -= Mathf.RoundToInt(krakenMaxHealth * 0.5f);
                kraken.BloodVolume = krakenMaxHealth;
                break;
        }
    }

    private void EffectStatusItem(GameProp item)
    {
        switch (item.Type)
        {
            case "a4e3":
                AddStatus(kraken, item.StatusIcon, item.ConsecutiveRounds, item.Value, krakenObject.transform.position);
                break;
            case "a4e5":
                AddStatus(kraken, item.StatusIcon, item.ConsecutiveRounds, item.Value, Vector3.zero);
                break;
            case "a4e11":
                AddStatus(kraken, item.StatusIcon, item.ConsecutiveRounds, 0.1f, Vector3.zero);
                break;
        }
    }

    private void SetSpecialItem(GameProp item)
    {
        switch (item.Type)
        {
            case "a4e7":
                itemCondition.ExtendsRounds += System.Convert.ToInt32(item.Value);
                break;
            case "a4e14":
                itemCondition.KillPromote += item.Value;
                break;
            case "a4e16":
                itemCondition.BloodSucking += item.Value;
                break;
            case "a4e12":
                itemCondition.Revive =item;
                break;
            case "a4e13":
                itemCondition.FullBloodItems.Add(item);
                break;
        }
    }

    private void InitializeItem()
    {
        currentPage = 0;
        for(int i = 0; i < GlobalVariable.BattleItems.Count; ++i)
        {
            GameProp itemProp = DeepCopy(GlobalVariable.BattleItems[i]);
            GameObject item = Instantiate(itemPrefab, itemFirstPosition.position + 
                new Vector3(0.2f * i, 0, 0), Quaternion.identity);
            itemSpriteReflect.Add(itemProp, item);
            item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("item/" + itemProp.SerialNumber);
            EffectPropertyItem(itemProp);
            EffectStatusItem(itemProp);
            SetSpecialItem(itemProp);
        }
    }

    public bool PlayCard()
    {
        GameProp card = handCards[CardAction.currentIndex];
        if(currentEnergy - card.EnergyConsumption < 0)
        {
            SetTip("精力值不足");
            return false;
        }
        else
        {
            currentEnergy -= card.EnergyConsumption;
            energy.transform.DOMoveY(energy.transform.position.y - card.EnergyConsumption * 0.35f, 1f);
            KrakenRound(card);
            if (IsTalentEffect(3, 10))
            {
                isTalent3Effect = true;
                if (!card.Type.Equals("a1b3"))
                {
                    KrakenRound(card);
                }
                else
                {
                    StartCoroutine(WaitForRemoveCard(2.5f));
                }
                DisplayTalentName(GlobalVariable.AllTalent["003"].Name);
                
            }
            RemoveCard();
            return true;
        }       
    }

    public void KrakenRound(GameProp card)
    {
        switch (card.Type)
        {
            case "a1b1":
                if (card.TargetQuantity == 1)
                {
                    KrakenAttackMonster(selectedMonster, card, false);
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        GetGameObjectByMonster(selectedMonster).transform));
                }
                else if (card.TargetQuantity == 6)
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    monstersPosition5.transform));
                    foreach (Monster monster in monsters)
                    {
                        KrakenAttackMonster(monster, card, false);
                    }
                }
                else
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    monstersPosition5.transform));
                    for (int i = 1; i <= card.TargetQuantity; ++i)
                    {
                        int randomIndex = Random.Range(0, monsters.Count);
                        Monster monster = monsters[randomIndex];
                        KrakenAttackMonster(monster, card, false);
                    }
                }            
                break;
            case "a1b2":
                if (card.TargetQuantity == 1)
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        GetGameObjectByMonster(selectedMonster).transform));
                    KrakenAttackMonster(selectedMonster, card, true);
                    
                }
                else if (card.TargetQuantity == 6)
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    monstersPosition5.transform));
                    foreach (Monster monster in monsters)
                    {
                        KrakenAttackMonster(monster, card, true);
                    }
                }
                else
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    monstersPosition5.transform));
                    for (int i = 1; i <= card.TargetQuantity; ++i)
                    {
                        int randomIndex = Random.Range(0, monsters.Count);
                        Monster monster = monsters[randomIndex];
                        KrakenAttackMonster(monster, card, true);
                    }
                }
                break;
            case "a1b3":
                isDrawCard = true;
                StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        krakenObject.transform));
                StartCoroutine(WaitForRemoveCard(1.7f));
                break;
            case "a1b4":
                StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        krakenObject.transform));
                int energyValue = int.Parse(card.Value.ToString());
                if (currentEnergy + energyValue >= maxEnergy)
                {
                    SetEnergyFull();
                }
                else
                {
                    currentEnergy += energyValue;
                    energy.transform.DOMoveY(energy.transform.position.y + energyValue * 0.35f, 1f);
                }
                break;
            case "a1b5":
                StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        krakenObject.transform));
                AddBlood(kraken, System.Convert.ToInt32(card.Value*krakenMaxHealth));
                if (kraken.BloodVolume > krakenMaxHealth)
                {
                    kraken.BloodVolume = krakenMaxHealth;
                }
                break;
            case "a2c1":
                if (card.TargetQuantity == 1)
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                        GetGameObjectByMonster(selectedMonster).transform));
                    EffectPropertyStatus(selectedMonster,
                        AddStatus(selectedMonster, card.StatusIcon, card.ConsecutiveRounds, card.Value,
                        GetGameObjectByMonster(selectedMonster).transform.position));
                }
                else
                {
                    StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    monstersPosition5.transform));
                    for (int i = 1; i <= card.TargetQuantity; ++i)
                    {
                        int randomIndex = Random.Range(0, monsters.Count);
                        Monster monster = monsters[randomIndex];
                        EffectPropertyStatus(monster,
                        AddStatus(monster, card.StatusIcon, card.ConsecutiveRounds, card.Value, 
                        GetGameObjectByMonster(monster).transform.position));
                    }
                }
                break;
            case "a2c2":
                StartCoroutine(PlayCardAnimation(card.SerialNumber,
                    krakenObject.transform));
                EffectPropertyStatus(kraken,
                        AddStatus(kraken, card.StatusIcon, card.ConsecutiveRounds, 
                        card.Value, krakenObject.transform.position));
                break;
            case "a3d1":
                StartCoroutine(PlayCardAnimation(card.SerialNumber,
                   krakenObject.transform));
                EffectPropertyStatus(kraken,
                        AddStatus(kraken, card.StatusIcon, card.ConsecutiveRounds, 
                        card.Value, krakenObject.transform.position));
                break;
            case "a3d2":
                Monster friend = DeepCopy(GlobalVariable.AllMonsters[card.Value.ToString()]);
                friendMonsters.Add(friend);
                if(!gameObjectMonsterReflect.ContainsKey(friendPosition1) ||
                    gameObjectMonsterReflect[friendPosition1] == null)
                {
                    gameObjectMonsterReflect.Add(friendPosition1, friend);
                    SpriteRenderer spr = friendPosition1.GetComponent<SpriteRenderer>();
                    spr.sprite = Resources.Load<Sprite>("monsters/" + card.StatusIcon);
                    return;
                }
                else if(!gameObjectMonsterReflect.ContainsKey(friendPosition2) ||
                    gameObjectMonsterReflect[friendPosition2] == null)
                {
                    gameObjectMonsterReflect.Add(friendPosition2, friend);
                    SpriteRenderer spr = friendPosition2.GetComponent<SpriteRenderer>();
                    spr.sprite = Resources.Load<Sprite>("monsters/" + card.StatusIcon);
                }
                else
                {
                    SetTip("助阵异兽已满");
                }
                break;
        }
    }

    void KrakenAttackMonster(Monster monster, GameProp card, bool hasState)
    {
        Status status;
        int demage = GetDamageValue(kraken.AttactPower * card.Value,
                                            monster, card.Attribute);
        ReduceBlood(monster, demage);
        if (hasState)
        {
            EffectPropertyStatus(monster,
                       AddStatus(monster, card.StatusIcon, card.ConsecutiveRounds, card.Value,
                       GetGameObjectByMonster(monster).transform.position));
        }
        if ((status = HaveReboundStatus(monster.StatusList)) != null)
        {
            ReduceBlood(kraken, System.Convert.ToInt32(demage * status.Value));
        }
        if (itemCondition.BloodSucking != 0)
        {
            AddBlood(kraken, System.Convert.ToInt32(demage * itemCondition.BloodSucking));
        }
    }

    IEnumerator MonsterRound(List<Monster> ownSide, List<Monster> enemys, bool isFriend)
    {
        foreach (Monster monster in ownSide)
        {
            int randomIndex = Random.Range(0, monster.SkillList.Count);
            GameProp skill = monster.SkillList[randomIndex];
            int randomEnemyIndex;
            Monster randomEnemy;
            switch (skill.Type)
            {
                case "a1b1":
                    if(skill.TargetQuantity == 3)
                    {
                        foreach(Monster enemy in enemys)
                        {
                            MonsterAttactEnemy(monster, enemy, skill, false);
                        }
                    }
                    else
                    {
                        randomEnemyIndex = Random.Range(0, enemys.Count);
                        randomEnemy = enemys[randomEnemyIndex];
                        MonsterAttactEnemy(monster, randomEnemy, skill, false);
                    }
                    yield return new WaitForSeconds(1f);
                    break;
                case "a1b2":
                    randomEnemyIndex = Random.Range(0, enemys.Count);
                    randomEnemy = enemys[randomEnemyIndex];
                    MonsterAttactEnemy(monster, randomEnemy, skill, true);
                    yield return new WaitForSeconds(1f);
                    break;
                case "a1b5":
                    if (skill.TargetQuantity == 0)
                    {
                        int value = System.Convert.ToInt32(skill.Value * GlobalVariable.
                        AllMonsters[monster.SerialNumber].BloodVolume);
                        AddBlood(monster, value);
                    }
                    else if (skill.TargetQuantity == 7)
                    {
                        foreach (Monster m in ownSide)
                        {
                            int value = System.Convert.ToInt32(skill.Value * GlobalVariable.
                        AllMonsters[m.SerialNumber].BloodVolume);
                            AddBlood(m, value);
                        }
                    }
                    break;
                case "a2c1":
                    randomEnemyIndex = Random.Range(0, enemys.Count);
                    randomEnemy = enemys[randomEnemyIndex];
                    EffectPropertyStatus(randomEnemy,
                           AddStatus(randomEnemy, skill.StatusIcon, skill.ConsecutiveRounds, skill.Value,
                           GetGameObjectByMonster(randomEnemy).transform.position));
                    break;
                case "a2c2":
                    if (skill.TargetQuantity == 0)
                    {
                        EffectPropertyStatus(monster,
                          AddStatus(monster, skill.StatusIcon, skill.ConsecutiveRounds, skill.Value,
                        GetGameObjectByMonster(monster).transform.position));
                    }
                    else if (skill.TargetQuantity == 7)
                    {
                        foreach (Monster m in ownSide)
                        {
                            EffectPropertyStatus(m,
                          AddStatus(m, skill.StatusIcon, skill.ConsecutiveRounds, skill.Value,
                        GetGameObjectByMonster(m).transform.position));
                        }
                    }
                    break;
            }
            JudegStatus(monster, GetGameObjectByMonster(monster).transform.position);
        }
        if (isFriend)
        {
            isFriendRoundOver = true;
        }
        else
        {
            friendMonsters.Remove(kraken);
            isMonsterRoundOver = true;
        }
    }

    void MonsterAttactEnemy(Monster monster, Monster enemy, GameProp skill, bool hasState)
    {
        Status status;
        int demage = GetDamageValue(monster.AttactPower * skill.Value,
                                           enemy, skill.Attribute);
        ReduceBlood(enemy, demage);
        if (hasState)
        {
            EffectPropertyStatus(enemy,
                           AddStatus(enemy, skill.StatusIcon, skill.ConsecutiveRounds, skill.Value,
                       GetGameObjectByMonster(enemy).transform.position));
        }
        GetGameObjectByMonster(monster).transform.DOShakePosition(1f, 0.07f);
        if ((status = HaveReboundStatus(enemy.StatusList)) != null)
        {
            ReduceBlood(monster, System.Convert.ToInt32(demage * status.Value));
        }
        if (enemy.Name.Equals("kraken") && IsTalentEffect(4, 10))
        {
            foreach (Status state in enemy.StatusList)
            {
                if (IsStateBad(state))
                {
                    TackBackStatus(enemy, state);
                }
            }
            DisplayTalentName(GlobalVariable.AllTalent["004"].Name);
        }
        StartCoroutine(PlayCardAnimation(skill.SerialNumber, GetGameObjectByMonster(enemy).transform));
    }

    IEnumerator WaitForRemoveCard(float second)
    {
        yield return new WaitForSeconds(second);
        ++drawCardCount;
        AddTwoCards();
    }

    IEnumerator PlayCardAnimation(string number, Transform position)
    {
        GameObject animation = (GameObject)Resources.Load("cardAnimation/"+number);
        if(animation != null)
        {
            animation = Instantiate(animation, position);
            yield return new WaitForSeconds(1f);
            Destroy(animation);
        } 
    }

    public void SetEnergyFull()
    {
        currentEnergy = maxEnergy;
        energy.transform.DOMove(energyStartPosition, 1f);
    }

    Status AddStatus(Monster monster, string statusCode, int rounds, float value, Vector3 position)
    {
        Status status = DeepCopy(GlobalVariable.AllStates[statusCode]);
        status.ResidueRounds = rounds + itemCondition.ExtendsRounds;
        status.Value = value;
        monster.StatusList.Add(status);
        if (position != Vector3.zero)
        {
            int currentStatusIndex = ++monster.StatusIndex;
            status.Index = currentStatusIndex;
            GameObject statusSprite = Instantiate(statusIcon, position +
                new Vector3(-0.27f + (monster.StatusIndexReflect.Count - 1) * 0.1f, -0.27f, 0), Quaternion.identity);
            statusSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("state/" + status.SerialNumber);
            monster.StatusIndexReflect.Add(currentStatusIndex, statusSprite);
        }
        return status;
    }

    public void JudegStatus(Monster monster, Vector3 position)
    {
        List<Status> removeStatus = new List<Status>();
        foreach(Status status in monster.StatusList)
        {
            EffectContinuedStatus(monster, status);
            --status.ResidueRounds;
            if(status.ResidueRounds <= 0)
            {
                TackBackStatus(monster, status);
                removeStatus.Add(status);
            }
        }
        foreach(Status status in removeStatus)
        {
            monster.StatusList.Remove(status);
            Destroy(monster.StatusIndexReflect[status.Index]);
            monster.StatusIndexReflect.Remove(status.Index);
            foreach(int index in monster.StatusIndexReflect.Keys)
            {
                if(index > status.Index)
                {
                    monster.StatusIndexReflect[index].transform.Translate(new Vector3(-0.1f, 0, 0));
                }
            }

        }
        
    }

    void EffectPropertyStatus(Monster monster, Status status)
    {
        float avalue = status.Value * monster.AttactPower;
        int aIntPart = (int)(avalue);
        if (avalue - aIntPart >= 0.5)
        {
            aIntPart += 1;
        }
        float dvalue = status.Value * monster.DefensivePower;
        int dIntPart = (int)(dvalue);
        if (dvalue - dIntPart >= 0.5)
        {
            dIntPart += 1;
        }
        switch (status.Code)
        {
            case "attack_add":
                status.Value = aIntPart;
                monster.AttactPower += status.Value;
                break;
            case "attack_sub":
                status.Value = aIntPart;
                monster.AttactPower -= status.Value;
                break;
            case "defend_add":
                status.Value = dIntPart;
                monster.DefensivePower += status.Value;
                break;
            case "defend_sub":
                status.Value = dIntPart;
                monster.DefensivePower -= status.Value;
                break;
            case "attack_add_defend_sub":
                monster.AttactPower += aIntPart;
                monster.DefensivePower -= dIntPart;
                break;
            
        }
    }

    Status HaveReboundStatus(List<Status> status)
    {
        foreach(Status state in status)
        {
            if (state.Code == "damage_rebound")
            {
                return state;
            }            
        }
        return null;
    }

    void TackBackStatus(Monster monster, Status status)
    {
        switch (status.Code)
        {
            case "attack_add":
                monster.AttactPower -= status.Value;
                break;
            case "attack_sub":
                monster.AttactPower += status.Value;
                break;
            case "defend_add":
                monster.DefensivePower -= status.Value;
                break;
            case "defend_sub":
                monster.DefensivePower += status.Value;
                break;

        }
    }

    void EffectContinuedStatus(Monster monster, Status status)
    {
        int value;
        switch (status.Code)
        {
            case "hp_add": 
                if(monster.Name == "kraken")
                {
                    value = System.Convert.ToInt32(status.Value * krakenMaxHealth);            
                }
                else
                {
                    value = System.Convert.ToInt32(status.Value * GlobalVariable.
                        AllMonsters[monster.SerialNumber].BloodVolume);    
                }
                AddBlood(monster, value);
                break;
            case "hp_sub":
                if (monster.Name == "kraken")
                {
                    value = System.Convert.ToInt32(status.Value * krakenMaxHealth);
                }
                else
                {
                    value = System.Convert.ToInt32(status.Value * GlobalVariable.
                        AllMonsters[monster.SerialNumber].BloodVolume);
                }
                ReduceBlood(monster, value);
                break;
        }       
    }

    void SetHealthChangeValue(int value, Monster monster, string mark)
    {
        Vector3 positon = GetGameObjectByMonster(monster).transform.position;
        if(mark == "+")
        {
            positon = positon + new Vector3(-0.6f, 0.23f, 0);
        }
        else
        {
            positon = positon + new Vector3(0.2f, 0.23f, 0);
        }
        GameObject healthChange = Instantiate(healthChangePrefab, positon, Quaternion.identity);
        TextMesh textMesh = healthChange.GetComponent<TextMesh>();
        textMesh.text = mark + value.ToString();
        if(mark == "+")
        {
            textMesh.color = Color.green;
        }
        DOTween.ToAlpha(() => textMesh.color, (color) => textMesh.color = color, 0, 1f).
           OnComplete(()=>Destroy(healthChange));
    }

    int GetDamageValue(float attact, Monster monster, int attribute)
    {
        float defend = monster.DefensivePower;
        int value = System.Convert.ToInt32(attact*attact/(attact+defend)) < 0 ? 0 : 
            System.Convert.ToInt32(attact * attact / (attact + defend));
        return value;
    }

    void DisplayTalentName(string name)
    {
        GameObject talentName = Instantiate(talentNamePrefab);
        TextMesh talentText = talentName.GetComponent<TextMesh>();
        talentText.text = name;
        DOTween.ToAlpha(() => talentText.color, (color) => talentText.color = color, 0, 2f).
           OnComplete(() => Destroy(talentName));
    }

    void JudgeMonsterDeath(Monster monster)
    {
        GameObject gameObject = GetGameObjectByMonster(monster);
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        if (monster.BloodVolume <= 0)
        {
            SetDefaultMaterial(spr);
            DOTween.ToAlpha(() => spr.color
                , x => spr.color = x, 0, 1f)
                .OnComplete(() =>
                {
                    spr.sprite = Resources.Load<Sprite>("monsters/transparent");
                    monsters.Remove(monster);
                    gameObjectMonsterReflect[gameObject] = null;
                    isAnimationEnd = true;
                });
            foreach (GameObject status in monster.StatusIndexReflect.Values)
            {
                SpriteRenderer statusSpr = status.GetComponent<SpriteRenderer>();
                DOTween.ToAlpha(() => statusSpr.color
                , x => statusSpr.color = x, 0, 1f)
                .OnComplete(() =>
                {
                    Destroy(statusSpr);
                    isAnimationEnd = true;
                });
            }
            if (itemCondition.KillPromote != 0)
            {
                kraken.AttactPower += krakenBaseAttact * itemCondition.KillPromote;
                kraken.DefensivePower += krakenBaseDefend * itemCondition.KillPromote;
            }
            if (IsTalentEffect(2, 100))
            {
                SetEnergyFull();
                DisplayTalentName(GlobalVariable.AllTalent["002"].Name);
            }
        }
    }

    void JudgeKrakenDeath()
    {
        if(kraken.BloodVolume <= 0)
        {
            kraken.BloodVolume = 0;
            if (itemCondition.FullBloodItems.Count > 0)
            {
                kraken.BloodVolume = krakenMaxHealth;
                Destroy(itemSpriteReflect[itemCondition.FullBloodItems[0]]);
                itemSpriteReflect.Remove(itemCondition.FullBloodItems[0]);
                GlobalVariable.BattleItems.Remove(itemCondition.FullBloodItems[0]);
                itemCondition.FullBloodItems.RemoveAt(0);
                
            }
            else if (itemCondition.Revive != null)
            {
                Destroy(itemSpriteReflect[itemCondition.Revive]);
                TertiaryMapSelect.SetScene(GlobalVariable.preMap);
                SceneManager.LoadScene("tertiaryMap");
            }
            else
            {
                isKrakenDeath = true;
            }
        }
    }

    void ReduceBlood(Monster monster, int value)
    {
        monster.BloodVolume -= value;
        if(monster.Name != "kraken")
        {
            JudgeMonsterDeath(monster);
        }
        else
        {
            JudgeKrakenDeath();
        }
        SetHealthChangeValue(value, monster, "-");
    }

    void AddBlood(Monster monster, int value)
    {
        monster.BloodVolume += value;
        if (monster.Name == "kraken" && monster.BloodVolume > krakenMaxHealth)
        {
            monster.BloodVolume = krakenMaxHealth;
        }
        if(monster.Name != "kraken" && monster.BloodVolume > GlobalVariable.
                        AllMonsters[monster.SerialNumber].BloodVolume)
        {
            monster.BloodVolume = GlobalVariable.
                        AllMonsters[monster.SerialNumber].BloodVolume;
        }
        SetHealthChangeValue(value, monster, "+");
    }

    public void ClickCard()
    {
        GameProp card = handCards[CardAction.currentIndex];
        if (card.TargetQuantity == 1)
        {
            RenderMonster.needClickMonster = true;            
            SetTip("请选择要攻击的目标");
        }
        else
        {
            RenderMonster.needClickMonster = false;
            selectedMonster = null;
            SetTip("请出牌");
        }
    }

    public void AddTwoCards()
    {
        if (handCards.Count == maxCardCount - 1)
        {
            AddCards(1, handCardsSprite[FindMaxKey(handCardsSprite)].
                 transform.position + new Vector3(0.15f, 0, 0), false);
            AddCards(1, cardOutPosition.position, true);
            SetTip("卡牌数量超出限制，自动销毁");
        }
        else if(handCards.Count == maxCardCount)
        {
            AddCards(2, cardOutPosition.position, true);
            SetTip("卡牌数量超出限制，自动销毁");
        }
        else
        {
            if (handCardsSprite.Count == 0)
            {
                AddCards(2, cardEndPosition.position, false);
            }
            else
            {
                AddCards(2, handCardsSprite[FindMaxKey(handCardsSprite)].
                transform.position + new Vector3(0.15f, 0, 0), false);
            }
        }
    }

    IEnumerator AddOneCard(Vector3 lastCardEndPosition, bool isDestory)
    {
        GameObject card = Instantiate(cardPrefab,
                cardStartPosition.position, Quaternion.identity);

        handCardsSprite.Add(card.GetComponent<CardAction>().index, card);

        int randomIndex = Random.Range(0, cardGroup.Count);
        GameProp randomCard = cardGroup[randomIndex];
        handCards.Add(card.GetComponent<CardAction>().index, randomCard);
        cardGroup.Remove(randomCard);

        Transform skillText = card.transform.Find("skill-text");
        string description = randomCard.Description;
        skillText.GetComponent<TextMesh>().text = Regex.Replace(description, @"\S{8}", "$0\r\n");
        SpriteRenderer cardStyle = card.transform.Find("card-style").GetComponent<SpriteRenderer>();
        Sprite style = Resources.Load<Sprite>("cardStyle/" +
            randomCard.Type.Substring(0, 2) + randomCard.EnergyConsumption);
        cardStyle.sprite = style;
        Transform cardName = card.transform.Find("card-name");
        cardName.GetComponent<TextMesh>().text = randomCard.Name;
        SpriteRenderer cardRawImg = card.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
        Sprite rawImg = Resources.Load<Sprite>("cardRawImg/" + randomCard.SerialNumber);
        cardRawImg.sprite = rawImg;
        cardStyle.sortingOrder = ++orderIndex;
        cardRawImg.sortingOrder = orderIndex + 1;

        yield return new WaitForSeconds(0.3f);
        card.transform.DOMove(lastCardEndPosition, 0.5f).OnComplete(() =>
        {
            if ((drawCardCount == 1 && !isTalent3Effect) ||
            (drawCardCount == 2 && isTalent3Effect) || drawCardCount == 0)
            {
                isAnimationEnd = true;
                isDrawCard = false;
                drawCardCount = 0;
            }
            if (isDestory)
            {
                DestoryCard(card, card.GetComponent<CardAction>().index);
            }
        });
    }

    void AddCards(int count, Vector3 lastCardEndPosition, bool isDestory)
    {
        isAnimationEnd = false;
        int diff = cardGroup.Count - count;
        if(diff == 0)
        {
            cardGroup = DeepCopy(GlobalVariable.FightCards);
            for (int i = 0; i < count; ++i)
            {
                StartCoroutine(AddOneCard(lastCardEndPosition + new Vector3(i * 0.15f, 0, 0), isDestory));
            }
        }
        else if(diff < 0)
        {
            for(int i = 0; i < cardGroup.Count; ++i)
            {
                lastCardEndPosition += new Vector3(i * 0.15f, 0, 0);
                StartCoroutine(AddOneCard(lastCardEndPosition, isDestory));
            }
            cardGroup = DeepCopy(GlobalVariable.FightCards);
            for (int i = 1; i <= -diff; ++i)
            {
                StartCoroutine(AddOneCard(lastCardEndPosition + new Vector3(i * 0.15f, 0, 0), isDestory));
            }
        }
        else
        {
            for (int i = 0; i < count; ++i)
            {
                StartCoroutine(AddOneCard(lastCardEndPosition + new Vector3(i * 0.15f, 0, 0), isDestory));
            }
        }
    }

    bool IsStateBad(Status status)
    {
        switch (status.SerialNumber)
        {
            case 1000002:
                return true;
            case 1000004:
                return true;
            case 1000006:
                return true;
        }
        return false;
    }

    public void RemoveCard()
    {
        int currentCardIndex = CardAction.currentIndex;
        GameObject currentCard = handCardsSprite[currentCardIndex];
        isAnimationEnd = false;
        currentCard.transform.DOMove(cardOutPosition.position, 0.5f)
            .OnComplete(()=>
            {
                DestoryCard(currentCard, currentCardIndex);
            });
        CardAction.isCardSelected = false;
        foreach (int i in handCardsSprite.Keys)
        {
            if (i > currentCardIndex)
            {
                handCardsSprite[i].transform.DOMove(handCardsSprite[i].transform.position + 
                    new Vector3(-0.15f, 0, 0), 0.6f).OnComplete(()=> { isAnimationEnd = true; });
            }          
        }       
    }

    void DestoryCard(GameObject currentCard, int currentCardIndex)
    {
        SpriteRenderer cardStyle = currentCard.transform.Find("card-style").GetComponent<SpriteRenderer>();
        SetDefaultMaterial(cardStyle);
        DOTween.ToAlpha(() => cardStyle.color
        , x => cardStyle.color = x, 0, 1f)
        .OnComplete(() =>
        {
            Destroy(currentCard);
            handCardsSprite.Remove(currentCardIndex);
            isAnimationEnd = true;
        });
        SpriteRenderer cardRawImg = currentCard.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
        DOTween.ToAlpha(() => cardRawImg.color
        , x => cardRawImg.color = x, 0, 1f);
        TextMesh cardName = currentCard.transform.Find("card-name").GetComponent<TextMesh>();
        DOTween.ToAlpha(() => cardName.color
        , x => cardName.color = x, 0, 1f);
        TextMesh skillText = currentCard.transform.Find("skill-text").GetComponent<TextMesh>();
        DOTween.ToAlpha(() => skillText.color
        , x => skillText.color = x, 0, 1f);
        handCards.Remove(currentCardIndex);
    }

    public void ClickSelectedMonster()
    {
        if(RenderMonster.currentIndex != -1)
            indexGameObjectReflect[RenderMonster.currentIndex].
            GetComponent<RenderMonster>().OnMouseDown();
    }

    public void ClickSelectedCard()
    {
        if(CardAction.currentIndex != -1)
        {
            handCardsSprite[CardAction.currentIndex].
                GetComponent<CardAction>().OnMouseDown();
        }
    }

    public GameObject GetGameObjectByMonster(Monster monster)
    {
        foreach(GameObject gameObject in gameObjectMonsterReflect.Keys)
        {
            if(gameObjectMonsterReflect[gameObject] == monster)
            {
                return gameObject;
            }
        }
        return null;
    }

    void SetDefaultMaterial(SpriteRenderer spr)
    {
        Material material = new Material(Shader.Find("Sprites/Default"));
        spr.material = material;
    }

    void SetMosters()
    {
        List<string> allMosterNumber = GlobalVariable.sceneMonstersDictionary[GlobalVariable.currentScene];
        int randomCount = Random.Range(1, 7);       
        bool hasBoss = false;
        for(int i = 1; i <= randomCount; ++i)
        {
            if (allMosterNumber[0].StartsWith("2") && !hasBoss)
            {
                monsterNumber.Add(allMosterNumber[0]);
                hasBoss = true;
                if(allMosterNumber.Count == 1)
                {
                    randomCount = 1;
                    break;
                }
            }
            else
            {
                int randomIndex;
                if (!hasBoss)
                {
                     randomIndex = Random.Range(0, allMosterNumber.Count);                    
                }
                else
                {
                    randomIndex = Random.Range(1, allMosterNumber.Count);
                }
                monsterNumber.Add(allMosterNumber[randomIndex]);
            }
        }
        SwitchMosterPosition(randomCount, hasBoss);
    }

    void SwitchMosterPosition(int count, bool hasBoss)
    {
        if (hasBoss)
        {
            monstersPosition5.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
            gameObjectMonsterReflect.Add(monstersPosition5, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
            switch (count)
            {
                case 1:
                    Destroy(monstersPosition3);
                    Destroy(monstersPosition4);
                    break;
                case 2:
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    Destroy(monstersPosition3);
                    Destroy(monstersPosition4);
                    break;
                case 3:
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    Destroy(monstersPosition3);
                    break;
                case 4:
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    Destroy(monstersPosition3);
                    break;
                case 5:
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[4]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[4]]));
                    break;
                case 6:
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[4]].Code);
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[5]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[4]]));
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[5]]));
                    break;
            }
        }
        else
        {
            switch (count)
            {
                case 1:
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    Destroy(monstersPosition3);
                    Destroy(monstersPosition4);
                    break;
                case 2:
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    Destroy(monstersPosition4);
                    break;
                case 3:
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    Destroy(monstersPosition4);
                    break;
                case 4:
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    break;
                case 5:
                    monstersPosition5.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[4]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition5, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[4]]));
                    break;
                case 6:
                    monstersPosition5.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[0]].Code);
                    monstersPosition4.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[1]].Code);
                    monstersPosition6.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[2]].Code);
                    monstersPosition1.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[3]].Code);
                    monstersPosition3.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[4]].Code);
                    monstersPosition2.GetComponent<RenderMonster>().SetMnoster(GlobalVariable.AllMonsters[monsterNumber[5]].Code);
                    gameObjectMonsterReflect.Add(monstersPosition5, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[0]]));
                    gameObjectMonsterReflect.Add(monstersPosition4, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[1]]));
                    gameObjectMonsterReflect.Add(monstersPosition6, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[2]]));
                    gameObjectMonsterReflect.Add(monstersPosition1, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[3]]));
                    gameObjectMonsterReflect.Add(monstersPosition3, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[4]]));
                    gameObjectMonsterReflect.Add(monstersPosition2, DeepCopy(GlobalVariable.AllMonsters[monsterNumber[5]]));
                    break;
            }
        }
        
    }

    public void SetTip(string tip)
    {
        TextMesh textMesh = tipGameObject.GetComponent<TextMesh>();
        textMesh.text = tip;
        DOTween.ToAlpha(() => textMesh.color, (color) => textMesh.color = color, 0, 1.2f)
            .OnComplete(() => { textMesh.color = new Color(255, 255, 255, 255); textMesh.text = ""; });
    }

    public static T DeepCopy<T>(T RealObject)
    {
        using (Stream objectStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, RealObject);
            objectStream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(objectStream);
        }
    }

    public int FindMaxKey<T>(Dictionary<int, T> dictionary)
    {
        int max = 0;
        foreach(int key in dictionary.Keys)
        {
            if(key > max)
            {
                max = key;
            }
        }
        return max;
    }

    private bool IsTalentEffect(int index, int chance)
    {
        if (GlobalVariable.ExistingTalent.Contains(GlobalVariable.AllTalent["00" + index]) 
            && GlobalVariable.Chance(chance))
        {
            return true;
        }
        return false;
    }
}
