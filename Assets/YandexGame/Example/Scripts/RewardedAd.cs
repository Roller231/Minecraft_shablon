using UnityEngine;
using UnityEngine.UI;

namespace YG.Example
{
    public class RewardedAd : MonoBehaviour
    {
        [SerializeField] int AdID;
        [SerializeField] Text textMoney;

        int moneyCount = 0;


        private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
        private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

        public void Rewarded(int id)
        {
            if (id == 1)
                AdMoney();
        }

        void AdMoney()
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().haveUnreal = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().MySaxve();
        }
    }
}