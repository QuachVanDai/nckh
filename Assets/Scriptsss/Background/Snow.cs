using DG.Tweening;
using QuachDai.NinjaSchool.ObjectPooling;
using System.Collections.Generic;
using UnityEngine;
namespace QuachDai.NinjaSchool.BackGround
{
    public class Snow : MonoBehaviour
    {
        [SerializeField] Vector2 posStart;
        [SerializeField] Vector2 posEnd;
        [SerializeField] ObjectPool objectPool;
        [SerializeField] KeyOjectPool keyPool;
        [SerializeField] List<GameObject> objectsList;
        [SerializeField] List<Tween> tweensList;
        [SerializeField] Tween tween;
        public float timeMove;
        // Start is called before the first frame update
        void Start()
        {
            objectsList = new List<GameObject>();
            tweensList = new List<Tween>();
            objectsList = objectPool.GetObjectList(keyPool);
            InvokeRepeating("SnowSpawm", 0, 0.1f);
        }
        void SnowSpawm()
        {
            foreach (GameObject obj in objectsList)
            {
                if (!obj.gameObject.activeSelf)
                {
                    posStart.x = Random.Range(-13f, 15f);
                    posEnd.x = posStart.x - Random.Range(3f, 6f);
                    SnowMove(obj, posStart, posEnd, Random.Range(6f, 15f));
                    break;
                }

            }
        }
        private void OnDisable()
        {
            foreach (Tween _tween in tweensList)
                _tween.Kill();
        }
        void SnowMove(GameObject gameObject, Vector2 posStart, Vector2 posEnd, float timeMove)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = posStart;
            tween = gameObject.transform.DOMove(posEnd, timeMove).OnComplete(() =>
            {
                gameObject.SetActive(false);
                gameObject.transform.position = posStart;
            });
            tweensList.Add(tween);
        }
    }
}
