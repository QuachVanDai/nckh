using QuachDai.NinjaSchool.MainCanvas;
using QuachDai.NinjaSchool.Mission;
using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Character
{
    public class Player : Singleton<Player>
    {
        [SerializeField] string namePlayer;
        [SerializeField] int level;
        [SerializeField] float expLevel;
        [SerializeField] float maxHp;
        [SerializeField] float hp;
        [SerializeField] float maxMp;
        [SerializeField] float mp;
        [SerializeField] float percentExp;
        [SerializeField] int xu;
        [SerializeField] int minDamage;
        [SerializeField] int maxDamage;
        [SerializeField] Image fillBarHP;
        [SerializeField] Image fillBarMP;
        [SerializeField] Text nameText;
        [SerializeField] Text hpText;
        [SerializeField] Text mpText;
        [SerializeField] Text levelText;
        [SerializeField] Text percentExpText;
        [SerializeField] Text xuText;
        [SerializeField] Text missionText;
        [SerializeField] GameObject damagedText;
        [SerializeField] RectTransform canvas;
        [SerializeField] Animator animatorPlayer;
        [SerializeField] SetPlayer setPlayer;
        [SerializeField] GameObject haLo;
        [SerializeField] GameObject loGo;
        [SerializeField] GameObject pet;
        [SerializeField] GameObject shadow;

        public PlayerAttack playerAttack;
        public PlayerAttacked playerAttacked;
        bool isFirstPlay;
        void Start()
        {
            Init();
        }
        protected void Init()
        {
            isFirstPlay = PlayerPrefs.GetInt(TagScript.firstPlay) == 0 ? false : true;
            setPlayer = new SetPlayer();
            if (!isFirstPlay)
                SetXu(2000);
            else
                xu = PlayerPrefs.GetInt(TagScript.xu);
            level = PlayerPrefs.GetInt(TagScript.level);
            level = level == 0 ? 1 : level;
            expLevel = setPlayer.getExpPlayerDictionary(level);

            namePlayer = PlayerPrefs.GetString(TagScript.namePlayer);
            namePlayer = namePlayer == "" ? "ADMIN" : namePlayer;
            percentExp = PlayerPrefs.GetFloat(TagScript.percentExp);
            GetLevelText();
            GetMaxDamage();
            GetMinDamage();
            hp = GetMaxHp();
            mp = GetMaxMp();
            SetHp(0);
            SetMp(0);
            SetXu(0);
            SetPercentExpText(percentExp);
            SetNamePlayer(namePlayer);
            GetFasihon();
        }
        public void GetFasihon()
        {
            bool isOption = PlayerPrefs.GetInt(KeyShowOpion.ShowHalo.ToString()) == 1 ? true : false;
            SetActiveHalo(isOption);
            isOption = PlayerPrefs.GetInt(KeyShowOpion.ShowHalo.ToString()) == 1 ? true : false;
            SetActiveLoGo(isOption);
            isOption = PlayerPrefs.GetInt(KeyShowOpion.ShowHalo.ToString()) == 1 ? true : false;
            SetActivePet(isOption);
            isOption = PlayerPrefs.GetInt(KeyShowOpion.ShowHalo.ToString()) == 1 ? true : false;
            SetActiveShadow(isOption);
        }
        public void SaveDataPlayer()
        {
            PlayerPrefs.SetInt(TagScript.firstPlay, 1);
            PlayerPrefs.SetInt(TagScript.level, level);
            PlayerPrefs.SetFloat(TagScript.percentExp, percentExp);
            PlayerPrefs.SetString(TagScript.namePlayer, nameText.text);
            PlayerPrefs.SetInt(TagScript.xu, xu);
        }

        public Animator GetAnimator()
        {
            return animatorPlayer;
        }
        public InformationMissionPanel informationMissionPanel;
        public void SetMissionText(string _quantityMonsterDestroyed, string _quantityMonsterDestroy, string _nameMonster)
        {
            if (_quantityMonsterDestroyed == "" && _quantityMonsterDestroy == "" && _nameMonster == "")
                missionText.text = "No mission";
            else
                missionText.text = "Kill " + _nameMonster + " " + _quantityMonsterDestroyed + "/ " + _quantityMonsterDestroy;
        }
        public string GetMissionText()
        {
            return missionText.text;
        }
        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void SetActiveHalo(bool _values)
        {
            haLo.SetActive(_values);
        }
        public void SetActiveLoGo(bool _values)
        {
            loGo.SetActive(_values);
        }
        public void SetActivePet(bool _values)
        {
            pet.SetActive(_values);
        }
        public void SetActiveShadow(bool _values)
        {
            shadow.SetActive(_values);
        }
        public Text GetNamePlayer()
        {
            return nameText;
        }
        public void SetNamePlayer(string _namePlayer)
        {
            nameText.text = _namePlayer;
        }
        public void SetPosition(Vector3 _vector3)
        {
            transform.position = _vector3;
        }

        public bool SetXu(int _number)
        {
            xu += _number;
            if (xu <= 0)
            {
                xu = 0;
                xuText.text = 0 + "";
                return false;
            }
            xuText.text = xu.ToString();
            return true;
        }

        public int GetXu()
        {
            return xu;
        }
        string levelStr => level.ToString();
        public void GetLevelText()
        {
            levelText.text = levelStr;
        }
        public void SetPercentExpText(float _exp)
        {
            percentExpText.text = _exp.ToString("F2") + "%";
        }
        public int GetLevel()
        {
            return level;
        }
        public void AddLevel()
        {
            level += 1;
        }
        public void IncreaseLevel()
        {
            level += 1;
            if (level > 20) level = 20;
        }
        public float GetPercentExp()
        {
            return percentExp;
        }
        public void SetPercentExp(float _exp)
        {
            percentExp = _exp;
        }
        public void IncreasePercentExp(float _exp)
        {
            percentExp += _exp;
        }
        public void SetHp(float _hp)
        {
            if (GameManager.Instance.IsPlayGame == false) return;

            this.hp += _hp;
            if (hp > maxHp) hp = maxHp;
            else if (hp <= 0) hp = 0;
            fillBarHP.fillAmount = this.hp / maxHp;
            hpText.text = this.hp.ToString();
        }
        public void SetMp(float _mp)
        {
            if (GameManager.Instance.IsPlayGame == false) return;

            this.mp += _mp;
            if (mp > maxMp) mp = maxMp;
            fillBarMP.fillAmount = this.mp / maxMp;
            mpText.text = this.mp.ToString();
        }
        public float GetMp()
        {
            return mp;
        }
        public float GetHp()
        {
            return hp;
        }
        public float GetMaxHp()
        {
            maxHp = setPlayer.getHPPlayerDictionary()[level];
            return maxHp;
        }
        public float GetMaxMp()
        {
            maxMp = setPlayer.getMPPlayerDictionary()[level];
            return maxMp;
        }
        public int GetDamage()
        {
            return Random.Range(GetMinDamage(), GetMaxDamage());
        }
        public int GetMinDamage()
        {
            minDamage = setPlayer.getDamePlayerDictionary(level).Item1;
            return minDamage;
        }
        public int GetMaxDamage()
        {
            maxDamage = setPlayer.getDamePlayerDictionary(level).Item2;
            return maxDamage;
        }

    }

}