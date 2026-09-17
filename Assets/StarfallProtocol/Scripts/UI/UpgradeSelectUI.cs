using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

namespace StarfallProtocol.Upgrades
{
    public class UpgradeSelectUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Button[] _optionButtons;
        [SerializeField] private TMP_Text[] _optionNameTexts;
        [SerializeField] private TMP_Text[] _optionDescriptionTexts;

        private Action<UpgradeData> _onChosenCallback;

        public void Show(List<UpgradeData> choices, Action<UpgradeData> onChosen)
        {
            _onChosenCallback = onChosen;
            _panel.SetActive(true);

            for (int i = 0; i < _optionButtons.Length; i++)
            {
                if (i < choices.Count)
                {
                    UpgradeData data = choices[i];
                    _optionButtons[i].gameObject.SetActive(true);
                    _optionNameTexts[i].text = data.displayName;
                    _optionDescriptionTexts[i].text = data.description;

                    _optionButtons[i].onClick.RemoveAllListeners();
                    _optionButtons[i].onClick.AddListener(() => SelectUpgrade(data));
                }
                else
                {
                    _optionButtons[i].gameObject.SetActive(false);
                }
            }
        }

        private void SelectUpgrade(UpgradeData data)
        {
            _panel.SetActive(false);
            _onChosenCallback?.Invoke(data);
        }
    }
}