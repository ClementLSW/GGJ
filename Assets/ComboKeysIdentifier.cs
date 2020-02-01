using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using System.Linq;
using SUPERLASER;

public class ComboKeysIdentifier : MonoBehaviour
{
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private Transform targetUIPanel;

    [SerializeField] private int playerNumber;

    public enum ComboKeys { UP, DOWN, LEFT, RIGHT };

    public enum ComboType { BUILD_BLOCK, BUILD_TURRET }
    [HideInInspector]
    public UnityEvent On_Build_Block_Combo = new UnityEvent();
    [HideInInspector]
    public UnityEvent On_Build_Turret_Combo = new UnityEvent();

    [Serializable]
    public class Combo
    {
        public ComboType ComboType;
        public List<ComboKeys> ComboList;
    }
    [SerializeField]
    private List<Combo> combos;

    private Queue<ComboKeys> comboHistroy = new Queue<ComboKeys>();

    private void Start()
    {
        if(playerNumber == 2)
        {
            InputManager.instance.On_P2_KEYUP_Click.AddListener(delegate { AddComboToQueue(ComboKeys.UP); });
            InputManager.instance.On_P2_KEYDOWN_Click.AddListener(delegate { AddComboToQueue(ComboKeys.DOWN); });
            InputManager.instance.On_P2_KEYLEFT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.LEFT); });
            InputManager.instance.On_P2_KEYRIGHT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.RIGHT); });
        }
        if (playerNumber == 2)
        {
            InputManager.instance.On_P3_KEYUP_Click.AddListener(delegate { AddComboToQueue(ComboKeys.UP); });
            InputManager.instance.On_P3_KEYDOWN_Click.AddListener(delegate { AddComboToQueue(ComboKeys.DOWN); });
            InputManager.instance.On_P3_KEYLEFT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.LEFT); });
            InputManager.instance.On_P3_KEYRIGHT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.RIGHT); });
        }

        switch (playerNumber)
        {
            case 2:
                InputManager.instance.On_P2_RT_Click.AddListener(delegate { CheckForCombo(); });
                InputManager.instance.On_P2_RB_Click.AddListener(delegate { ClearComboHistroy(); });
                break;
            case 3:
                InputManager.instance.On_P3_RT_Click.AddListener(delegate { CheckForCombo(); });
                InputManager.instance.On_P3_RB_Click.AddListener(delegate { ClearComboHistroy(); });
                break;
        }

        On_Build_Block_Combo.AddListener(delegate { Debug.Log("On_Build_Block_Combo"); });
        On_Build_Turret_Combo.AddListener(delegate { Debug.Log("On_Build_Turret_Combo"); });
    }

    private void AddComboToQueue(ComboKeys comboType)
    {
        comboHistroy.Enqueue(comboType);
        if (comboHistroy.Count > 7)
        {
            comboHistroy.Dequeue();
            Destroy(targetUIPanel.GetChild(0).gameObject);
        }

        GameObject arrowPrefab = null;

        switch (comboType)
        {
            case ComboKeys.UP:
                arrowPrefab = upArrow;
                break;
            case ComboKeys.DOWN:
                arrowPrefab = downArrow;
                break;
            case ComboKeys.LEFT:
                arrowPrefab = leftArrow;
                break;
            case ComboKeys.RIGHT:
                arrowPrefab = rightArrow;
                break;
        }

        Instantiate(arrowPrefab, targetUIPanel);
    }

    private void ClearComboHistroy()
    {
        comboHistroy.Clear();
        foreach(GameObject child in targetUIPanel.GetChildrensAsGameObjects())
        {
            Destroy(child);
        }
    }

    private void CheckForCombo()
    {
        List<Combo> filteredCombo = combos.Where(x => x.ComboList.Count == comboHistroy.Count).ToList();

        foreach (Combo combo in filteredCombo)
        {
            if(comboHistroy.ToList().ContainsSequence(combo.ComboList))
            {
                switch (combo.ComboType)
                {
                    case ComboType.BUILD_BLOCK:
                        On_Build_Block_Combo.Invoke();
                        break;
                    case ComboType.BUILD_TURRET:
                        On_Build_Turret_Combo.Invoke();
                        break;
                }
                ClearComboHistroy();
            }
        }
    }
}
