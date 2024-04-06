using UnityEngine;
using UnityEngine.UI;
namespace QuachDai.NinjaSchool.Character
{
    public class Player : Singleton<Player>
    {
         [SerializeField] string namePlayer;
         [SerializeField] int level;
         [SerializeField] float maxHp;
         [SerializeField] float hp;
         [SerializeField] float maxMp;
         [SerializeField] float mp;
         [SerializeField] float percentExp;
         [SerializeField] int gold;
         [SerializeField] int minDamage;
         [SerializeField] int maxDamage;
         [SerializeField] Image fillBarHP;
         [SerializeField] Image fillBarMP;
         [SerializeField] Text nameText;
         [SerializeField] Text hpText;
         [SerializeField] Text mpText;
         [SerializeField] Text levelText;
         [SerializeField] Text percentExpText;
         [SerializeField] Text goldText;
         [SerializeField] GameObject damagedText;
         [SerializeField] RectTransform canvas;
         [SerializeField] Animator animatorPlayer;
         [SerializeField] SetPlayer setPlayer;

        public PlayerAttack playerAttack;
        public PlayerAttacked playerAttacked;
      void Start()
        {
            Init();
        }
        protected void Init()
        {
            setPlayer = new SetPlayer();
            maxHp = setPlayer.getHPPlayerDictionary()[level];
            hp = setPlayer.getHPPlayerDictionary()[level];
            maxMp = setPlayer.getHPPlayerDictionary()[level];
            mp = setPlayer.getMPPlayerDictionary()[level];
        }
        public void IgnorePlayer()
        {
            Physics2D.IgnoreLayerCollision(7,10);
        }
        public void Update()
        {
            IgnorePlayer();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "potion")
            {
                PickUpItems pickUpItems = collision.gameObject.GetComponent<PickUpItems>();
                try
                {
                    MpSO MpSO = (MpSO)pickUpItems.slot.getItemSO();
                    InventoryUpdate.Instance.UpdateMP(pickUpItems.slot, 1);
                }
                catch
                {
                    HpSO HpSO = (HpSO)pickUpItems.slot.getItemSO();
                    InventoryUpdate.Instance.UpdateHP(pickUpItems.slot, 1);
                }

            }
            else if (collision.gameObject.tag == "money")
            {
                PickUpItems pickUpItems = collision.gameObject.GetComponent<PickUpItems>();
                MoneySO money = (MoneySO)pickUpItems.slot.getItemSO();
                gold += money.Xu;
            }
        }
        public void TextGUI(int damage, Color color)
        {
            GameObject g = Instantiate(damagedText);
            NumberTxt numberTxt = g.GetComponent<NumberTxt>();
            numberTxt.TextMove(canvas, (int)damage, new Vector3(0, 1.2f, 0), 1, 0.5f, color);
        }
        public Animator GetAnimator()
        {
            return animatorPlayer;
        }
        public Vector3 GetPosition()
        {
            return transform.position;
        }
        public void SetPositon(Vector3 _vector3)
        {
            transform.position = _vector3;
        }
        public void SetHp(float hp)
        {
            this.hp += hp;
            this.hp = this.hp >= maxHp ? maxHp : this.hp;
            fillBarHP.fillAmount = this.hp / maxHp;
            hpText.text = this.hp.ToString();
        }
        public void SetMp(float mp)
        {
            this.mp += mp;
            this.mp = this.mp >= maxMp ? maxMp : this.mp;
            fillBarMP.fillAmount = this.mp / maxMp;
            mpText.text = this.mp.ToString();
        }
        public bool SetGold(int number)
        {
            gold += number;
            if (gold <= 0)
            {
                gold = 0;
                goldText.text = 0 + "";
                return false;
            }
            goldText.text = gold.ToString();
            return true;
        }

  
 
        public void SetLevelText(int level)
        {
            levelText.text = level.ToString();
        }
        public void SetPercentExpText(float exp)
        {
            percentExpText.text = exp.ToString("F2") + "%"; ;
        }
        public int GetLevel()
        {
            return level;
        }
        public void IncreaseLevel()
        {
            level+=1;
        }
        public float GetPercentExp() {  return percentExp; }
        public void SetPercentExp(float exp) {  percentExp=exp; }
        public void IncreasePercentExp(float exp)
        { 
            percentExp += exp; 
        }
        public float GetMp() { return mp; }
        public float GetHp() { return hp; }
        public float GetMaxHp()
        {
            return maxHp;
        }
        public float GetMaxMp()
        {
            return maxMp;
        }
        public int GetMinDamage()
        {
            return minDamage;
        }
        public void SetMaxDamage()
        {
            maxDamage = setPlayer.getDamePlayerDictionary(level).Item1;
        }
        public void SetMinDamage()
        {
            minDamage = setPlayer.getDamePlayerDictionary(level).Item2;
        }
        public int GetMaxDamage()
        {
            return maxDamage;
        }
        public int GetGold()
        {
            return gold;
        }
    }

}