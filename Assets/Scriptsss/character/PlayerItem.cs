
using System.IO;
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerItem : Singleton<PlayerItem>
    {

        [SerializeField] private Head _CharacterHead;
        [SerializeField] private Body _CharacterBody;
        [SerializeField] private Leg _CharacterLeg;

        [Header("Thay đổi trang phục khi mặc trang bị")]
        [SerializeField] AvatarSO AvatarSO;
        [SerializeField] ClothSO ClothSO;
        [SerializeField] PantSO PantSO;

        [SerializeField] DisguiseSO currDisguiseSO;
        [SerializeField] DisguiseSO firstDisguiseSO;
        string filePath;

        public override void Awake()
        {
            base.Awake();
            filePath = Application.persistentDataPath + "/DisguiseSO.json";
        }
        private void Start()
        {
            LoadData();
            SetDisguise();
        }
        public void SaveData()
        {
            Debug.Log("Save Data currDisguiseSO");
            string data = JsonUtility.ToJson(currDisguiseSO);
            File.WriteAllText(filePath, data);
        }
        public void SetData(DisguiseSO _disguiseSO)
        {
            currDisguiseSO = _disguiseSO;
        }
        public void LoadData()
        {
            if (File.Exists(filePath))
            {
                string data;
                if (PlayerPrefs.GetInt(TagScript.firstPlay) == 0)
                {
                    Debug.Log("First Data");
                    currDisguiseSO = firstDisguiseSO;
                }
                else
                {
                    Debug.Log("Second Data");
                    data = File.ReadAllText(filePath);
                    Debug.Log(data);
                    JsonUtility.FromJsonOverwrite(data, currDisguiseSO);
                }
            }
            SaveData();
        }
        private void OnValidate()
        {
            _CharacterHead = GetComponentInChildren<Head>();
            _CharacterBody = GetComponentInChildren<Body>();
            _CharacterLeg = GetComponentInChildren<Leg>();
        }
        public void SetDisguise()
        {
            AvatarSO = currDisguiseSO.disguiseSO.Head;
            ClothSO = currDisguiseSO.disguiseSO.Body;
            PantSO   = currDisguiseSO.disguiseSO.Leg;
            // Thay đổi Tóc
            if (AvatarSO != null)
            {
                CharacterCustomization(_CharacterHead.headIdle, AvatarSO.GetSpriteIdle);
                CharacterCustomization(_CharacterHead.headRun, AvatarSO.GetSpriteRun);
                CharacterCustomization(_CharacterHead.headAttack, AvatarSO.GetSpriteAttack);
                CharacterCustomization(_CharacterHead.headDown, AvatarSO.GetSpriteDown);
            }
            //// Thay đổi Áo
            if (ClothSO != null)
            {
                CharacterCustomization(_CharacterBody.bodyIdle, ClothSO.GetSpriteIdle);
                CharacterCustomization(_CharacterBody.bodyRun, ClothSO.GetSpriteRun);
                CharacterCustomization(_CharacterBody.bodyAttack, ClothSO.GetSpriteAttack);
                CharacterCustomization(_CharacterBody.bodyDown, ClothSO.GetSpriteDown);
            }
            //// Thay đổi Quần
            if (PantSO != null)
            {
                CharacterCustomization(_CharacterLeg.legIdle, PantSO.GetSpriteIdle);
                CharacterCustomization(_CharacterLeg.legRun, PantSO.GetSpriteRun);
                CharacterCustomization(_CharacterLeg.legAttack, PantSO.GetSpriteAttack);
                CharacterCustomization(_CharacterLeg.legDown, PantSO.GetSpriteDown);
            }
        }
        // Hàm thay đổi trang phục
        private void CharacterCustomization(GameObject[] outfits, Sprite[] sprites)
        {

            if (outfits.Length > 0)
            {
                if (sprites != null && sprites.Length > 0)
                {
                    for (int i = 0; i < outfits.Length; i++)
                    {
                        outfits[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
                    }
                }

            }
        }
    }
}
