using System.Globalization;
using SellerTestScripts.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace SellerTestScripts.Views
{
    public class PlayerBalanceView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _balanceLabel;

        private IBalanceService _balanceService;

        private void Start()
        {
            _balanceService = ServiceLocator.Instance.Get<IBalanceService>();
            _balanceService.BalanceChanged += ShowBalance;
            ShowBalance(_balanceService.Balance);
        }

        private void ShowBalance(float balance)
        {
            _balanceLabel.text = balance.ToString(CultureInfo.InvariantCulture);
        }

        private void OnDestroy()
        {
            _balanceService.BalanceChanged -= ShowBalance;
        }
    }
}