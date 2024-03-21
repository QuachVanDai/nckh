using System.Collections.Generic;
using UnityEngine;

namespace QuachDai.NinjaSchool.Scenes {
    public class MiniScenes : MonoBehaviour
    {
        private const string ITEM_RESOURCE_FOLDER_PATH = "Data/MiniGames";

        private static ResourceAsset<MiniScenes> asset = new(ITEM_RESOURCE_FOLDER_PATH);
        [SerializeField] List<MiniSceneData> listMiniScene = new();
        public static MiniSceneData GetMiniSceneData(MiniSceneId _id)
        {
            var _data = asset.Value.listMiniScene.Find(x => x.Id.Equals(_id));
            return _data;
        }

        public static List<MiniSceneData> GetAllMiniSceneData()
        {
            return asset.Value.listMiniScene;
        }
        public static string GetMiniscene(MiniSceneId _id)
        {
            var _data = asset.Value.listMiniScene.Find(x => x.Id.Equals(_id));
            return _data.SceneName;
        }
    }
}
