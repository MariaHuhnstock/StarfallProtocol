using UnityEngine;
using System.Collections.Generic;
using StarfallProtocol.Core;
using StarfallProtocol.Player;

namespace StarfallProtocol.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private UpgradeData[] _allUpgrades;
        [SerializeField] private UpgradeSelectUI _upgradeSelectUI;
        [SerializeField] private UpgradeInventory _upgradeInventory;
        [SerializeField] private int _scoreInterval = 500;

        private int _nextThreshold;
        private readonly HashSet<UpgradeType> _acquiredNonStackable = new HashSet<UpgradeType>();

        private void Start()
        {
            _nextThreshold = _scoreInterval;
        }

        private void Update()
        {
            if (ScoreManager.Instance == null) return;

            if (ScoreManager.Instance.CurrentScore >= _nextThreshold)
            {
                _nextThreshold += _scoreInterval;
                TriggerUpgradeSelection();
            }
        }

        private void TriggerUpgradeSelection()
        {
            List<UpgradeData> availablePool = GetAvailableUpgrades();

            if (availablePool.Count == 0) return; // Nichts mehr anzubieten (alle Non-Stackables vergeben)

            List<UpgradeData> choices = GetRandomUpgrades(availablePool, 3);
            Time.timeScale = 0f;
            _upgradeSelectUI.Show(choices, OnUpgradeChosen);
        }

        private List<UpgradeData> GetAvailableUpgrades()
        {
            List<UpgradeData> result = new List<UpgradeData>();
            foreach (UpgradeData upgrade in _allUpgrades)
            {
                bool alreadyOwnedAndNotStackable = !upgrade.isStackable && _acquiredNonStackable.Contains(upgrade.type);
                if (!alreadyOwnedAndNotStackable)
                {
                    result.Add(upgrade);
                }
            }
            return result;
        }

        private void OnUpgradeChosen(UpgradeData chosen)
        {
            _upgradeInventory.ApplyUpgrade(chosen);

            if (!chosen.isStackable)
            {
                _acquiredNonStackable.Add(chosen.type);
            }

            Time.timeScale = 1f;
        }

        private List<UpgradeData> GetRandomUpgrades(List<UpgradeData> sourcePool, int count)
        {
            List<UpgradeData> pool = new List<UpgradeData>(sourcePool);
            List<UpgradeData> result = new List<UpgradeData>();

            count = Mathf.Min(count, pool.Count);
            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, pool.Count);
                result.Add(pool[index]);
                pool.RemoveAt(index);
            }
            return result;
        }
    }
}