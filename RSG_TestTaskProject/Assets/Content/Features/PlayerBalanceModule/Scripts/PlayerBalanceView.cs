using TMPro;
using UnityEngine;

namespace Content.Features.PlayerBalanceModule.Scripts
{
    public class PlayerBalanceView : MonoBehaviour, IPlayerBalanceView
    {
        [SerializeField]
        private TMP_Text _balanceText;

        public void UpdateBalance(int newBalance)
        {
            _balanceText.text = newBalance.ToString();
        }
    }
}