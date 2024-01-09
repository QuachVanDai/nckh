using System.Collections;
using UnityEngine;
public class PlayerAttack:NCKHMonoBehaviour
{
    [SerializeField] private SkillAnimation _skillAnimation;
    [SerializeField] private FrameSkill[] _frameSkill;
    [SerializeField] private skillRecoveryTime[] skillRecoveryTimes;
    private float distance; 
    public monsterAttacked monsterAttacted;
    private setPlayer _setPlayer = new setPlayer();
    private setMonster _setMonste = new setMonster();
    private setSkillParameters skillParameters = new setSkillParameters();
    private bool _isActtack, _isSkillLv5, _isSkillLv15, _isIncreaseDamage;

    protected override void loadComponets()
    {
     //   frameSkill = new FrameSkill[frameSkill.Length];
        base.loadComponets();
        Transform g =  transform.Find("skillAnimation");
        _skillAnimation = g.GetComponent<SkillAnimation>();
    }
    private void Start()
    {
        _isActtack = true;
        _isSkillLv5 = true;
        _isSkillLv15 = true;
        _isIncreaseDamage = false;
    }

    private void Update()
    {
        //  
        if( gameManager.Instance.IsPlaygame == false) return;
        // check to see if player is standing on the ground ?
        if (PlayerController2D.Instance.isGround() == false) return;
        if (monsterAttacted == null)
        {
            return;
        }
        // Calculate the distance from the player to the target

        distance = Vector2.Distance(transform.position, monsterAttacted.transform.position);
        if (distance > 7)
        {
            systemUi.Instance.infoMonster.gameObject.SetActive(false);
            monsterAttacted = null;
            return;
        }
 
        if (PlayerController2D.Instance.getInputSpace())
        {
            // 
            if ( distance>4) {
               TextTemplate.Instance.SetText(TagScript.khoangCach);
                return;
            }

            // if player use skilllv5 or skilllv15  , player cannot attack.
            if (useSkill.Instance.getCurrKeySkill() == 1 || useSkill.Instance.getCurrKeySkill() == 3)
            {
                TextTemplate.Instance.SetText(TagScript.useSkill); return;
            }
            // check mana
            ManaUseSkill();
            // player can attack
            if (_isActtack)
            {
                StartCoroutine(playerAttack());
            }
        }
    }

    #region người chơi đánh quái và nhận kinh nghiệm
    public IEnumerator playerAttack()
    {
        // 
        float damage = Random.Range(
            Player.Instance._setPlayer.getDamePlayerDictionary(Player.Instance.Level).Item1,
            Player.Instance._setPlayer.getDamePlayerDictionary(Player.Instance.Level).Item2) *
            _frameSkill[useSkill.Instance.getCurrKeySkill()].coefficient; //coefficient: hệ số

        // if player use skillLv15 , player can increase damage
        if (_isIncreaseDamage)
        {
            if (Player.Instance.Level >= 20)
                damage += skillParameters.getSkillLv15Parameters()[6];
            else { damage += skillParameters.getSkillLv15Parameters()[Player.Instance.Level - 14]; }
        }
        AddExp((int)damage);
        monsterAttacted.Attacked((int)damage);
        _skillAnimation.AnimationSkill(_frameSkill[useSkill.Instance.getCurrKeySkill()]);
        PlayerController2D.Instance.Animator.SetBool("IsAttack", true);
        _isActtack = false;
        Player.Instance.update_mp(_frameSkill[useSkill.Instance.getCurrKeySkill()].mp*(-1));

        yield return new WaitForSeconds(0.23f);
        PlayerController2D.Instance.Animator.SetBool("IsAttack", false);
        skillRecoveryTimes[useSkill.Instance.getCurrKeySkill()].isTime = true;
        yield return new WaitForSeconds(_frameSkill[useSkill.Instance.getCurrKeySkill()].timeSkill);
        _isActtack = true;
        skillRecoveryTimes[useSkill.Instance.getCurrKeySkill()].isTime = false;
    }
    public void AddExp(float damage)
    {
        if (monsterAttacted.currMoster._currhp < damage)
        {
            damage = monsterAttacted.currMoster._currhp;
        }
            double exp = (damage * _setMonste.getExpMonsterDictionary()[monsterAttacted.currMoster._level]*100 )
            / _setPlayer.getExpPlayerDictionary()[Player.Instance.Level];
        Player.Instance.textGUI((int)damage,Color.blue);
        if (Player.Instance.PercentExp + exp > 100)
        {
            Player.Instance.PercentExp = 0;
            Player.Instance.Level++;
            Player.Instance.TxtCurrentLevel.text = Player.Instance.Level.ToString();
        }
        else Player.Instance.PercentExp +=(float) exp;
        Player.Instance.TxtCurrentPercentExp.text = (Player.Instance.PercentExp).ToString("F2") + "%";
    }
    public void findMonster(monsterAttacked m)
    {
        monsterAttacted = m.GetComponent<monsterAttacked>();
    }
    #endregion 
    #region  người chơi sử dụng kỹ năng lv5 và lv15
    public void playerUseSkillLv5()
    {
        if (useSkill.Instance.getIsUseSkill(1) == false) {  return; }
        ManaUseSkill();
        if (!_isSkillLv5) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
        if (_isSkillLv5)
        {
            StartCoroutine(UseSkillLv5());
        }
    }
    public IEnumerator UseSkillLv5()
    {
        _skillAnimation.AnimationSkillLv5_15(_frameSkill[1]);
        _isSkillLv5 = false;
        InvokeRepeating(nameof(inCreaseHPMP), 0, 0.5f);
        skillRecoveryTimes[1].isTime = true;
        yield return new WaitForSeconds(1.5f);
        CancelInvoke(nameof(inCreaseHPMP));
        yield return new WaitForSeconds(_frameSkill[1].timeSkill - 1.5f);
        skillRecoveryTimes[1].isTime = false;
        _isSkillLv5 = true;
    }
    public void inCreaseHPMP()
    {
        float hp, mp;
        if (Player.Instance.Level >= 10)
        {
            hp = skillParameters.getSkillLv5Parameters()[6];
            mp = skillParameters.getSkillLv5Parameters()[6];
        }
        else
        { 
            hp = skillParameters.getSkillLv5Parameters()[Player.Instance.Level - 4]; 
            mp = skillParameters.getSkillLv5Parameters()[Player.Instance.Level - 4]; 
        }
        Player.Instance.update_hp(hp);
        Player.Instance.update_mp(mp);
    }
    public void playerUseSkillLv15()
    {
        if (useSkill.Instance.getIsUseSkill(3) == false) { return; }
        ManaUseSkill();
        if (!_isSkillLv15) { TextTemplate.Instance.SetText(TagScript.hoiChieu); return; }
        if (_isSkillLv15)
        {
            StartCoroutine(UseSkillLv15());
        }
    }

    public IEnumerator UseSkillLv15()
    {
        _skillAnimation.AnimationSkillLv5_15(_frameSkill[3]);
        _isSkillLv15 = false;
        _isIncreaseDamage = true;
        skillRecoveryTimes[3].isTime = true;
        yield return new WaitForSeconds(_frameSkill[3].timeSkill);
        _isSkillLv15 = true;
        _isIncreaseDamage = false;
        skillRecoveryTimes[3].isTime = false;

    }

    public void ManaUseSkill()
    {
        if (Player.Instance.Currmp < _frameSkill[useSkill.Instance.getCurrKeySkill()].mp)
        {
            Debug.Log("khong du Mana de su dung  " + Player.Instance.Currmp);
            return;
        }

    }
    #endregion
 
    void OnDrawGizmos()
    {
        if (monsterAttacted == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, monsterAttacted.transform.position);
    }
}