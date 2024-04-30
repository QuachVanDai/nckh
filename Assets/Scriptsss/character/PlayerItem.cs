
using UnityEngine;
namespace QuachDai.NinjaSchool.Character
{
    public class PlayerItem : MonoBehaviour
    {

        [SerializeField] private Head _CharacterHead;
        [SerializeField] private Body _CharacterBody;
        [SerializeField] private Leg _CharacterLeg;
        [SerializeField] private Weapon characterWeapon;

        [Header("Thay đổi trang phục khi mặc trang bị")]
        [SerializeField] AvatarSO AvatarSO;
        [SerializeField] ClothSO ClothSO;
        [SerializeField] PantSO PantSO;
        //  [SerializeField] useItem weaponSO;

        public void setPant(PantSO pant)
        {
            PantSO = pant;
        }
        public void setCloth(ClothSO cloth)
        {
            ClothSO = cloth;
        }
        public void setPant(AvatarSO avatar)
        {
            AvatarSO = avatar;
        }
        // Hàm tự động tìm các đối tượng, chỉ thực thi trong Editor
        private void OnValidate()
        {
            _CharacterHead = GetComponentInChildren<Head>();
            _CharacterBody = GetComponentInChildren<Body>();
            _CharacterLeg = GetComponentInChildren<Leg>();
            characterWeapon = GetComponentInChildren<Weapon>();
        }
        private void Reset()
        {
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
        private void Update()
        {
           /* // Thay đổi Tóc
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
            }*/
            /*if (weaponSO != null)
            {
                CharacterCustomization(characterWeapon.weapon, weaponSO.GetSpriteDown);
            }*/
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
