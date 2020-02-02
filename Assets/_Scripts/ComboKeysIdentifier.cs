using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using System.Linq;
using SUPERLASER;
using UnityEngine.InputSystem;

public class ComboKeysIdentifier : MonoBehaviour
{
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private Transform targetUIPanel;

    [SerializeField] private int playerNumber;
    [SerializeField] private GridController gc;

    public enum ComboKeys { UP, DOWN, LEFT, RIGHT };

    public enum ComboType { BUILD_WOOD, BUILD_METAL, BUILD_TURRET, BUILD_REPAIR }
    [HideInInspector]
    public UnityEvent On_Build_Block_Combo = new UnityEvent();
    [HideInInspector]
    public UnityEvent On_Build_Metal_Combo = new UnityEvent();
    [HideInInspector]
    public UnityEvent On_Build_Turret_Combo = new UnityEvent();
    [HideInInspector]
    public UnityEvent On_Build_Repair_Combo = new UnityEvent();

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
        if (playerNumber == 1)
        {
            InputManager.instance.On_P1_KEYUP_Click.AddListener(delegate { AddComboToQueue(ComboKeys.UP); });
            InputManager.instance.On_P1_KEYDOWN_Click.AddListener(delegate { AddComboToQueue(ComboKeys.DOWN); });
            InputManager.instance.On_P1_KEYLEFT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.LEFT); });
            InputManager.instance.On_P1_KEYRIGHT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.RIGHT); });
        }
        if (playerNumber == 2)
        {
            InputManager.instance.On_P2_KEYUP_Click.AddListener(delegate { AddComboToQueue(ComboKeys.UP); });
            InputManager.instance.On_P2_KEYDOWN_Click.AddListener(delegate { AddComboToQueue(ComboKeys.DOWN); });
            InputManager.instance.On_P2_KEYLEFT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.LEFT); });
            InputManager.instance.On_P2_KEYRIGHT_Click.AddListener(delegate { AddComboToQueue(ComboKeys.RIGHT); });
        }

        switch (playerNumber)
        {
            case 1:
                InputManager.instance.On_P1_RT_Click.AddListener(delegate { CheckForCombo(); });
                InputManager.instance.On_P1_RB_Click.AddListener(delegate { ClearComboHistroy(); });
                break;
            case 2:
                InputManager.instance.On_P2_RT_Click.AddListener(delegate { CheckForCombo(); });
                InputManager.instance.On_P2_RB_Click.AddListener(delegate { ClearComboHistroy(); });
                break;
        }

        On_Build_Block_Combo.AddListener(delegate { gc.Build(ComboType.BUILD_WOOD); });
        On_Build_Metal_Combo.AddListener(delegate { gc.Build(ComboType.BUILD_METAL); });
        On_Build_Turret_Combo.AddListener(delegate { gc.Build(ComboType.BUILD_TURRET); });
        On_Build_Repair_Combo.AddListener(delegate { gc.Build(ComboType.BUILD_REPAIR); });
    }

    private void Update()
    {
        if (playerNumber == 1)
            if (Gamepad.all[0].rightShoulder.wasPressedThisFrame && comboHistroy.Count == 0)
                gc.DestroySelectedBuilding();

        if (playerNumber == 2)
            if (Gamepad.all[1].rightShoulder.wasPressedThisFrame && comboHistroy.Count == 0)
                gc.DestroySelectedBuilding();
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
        foreach (GameObject child in targetUIPanel.GetChildrensAsGameObjects())
        {
            Destroy(child);
        }
    }

    private void CheckForCombo()
    {
        List<Combo> filteredCombo = combos.Where(x => x.ComboList.Count == comboHistroy.Count).ToList();

        foreach (Combo combo in filteredCombo)
        {
            if (comboHistroy.ToList().ContainsSequence(combo.ComboList))
            {
                switch (combo.ComboType)
                {
                    case ComboType.BUILD_WOOD:
                        On_Build_Block_Combo.Invoke();
                        break;
                    case ComboType.BUILD_METAL:
                        On_Build_Metal_Combo.Invoke();
                        break;
                    case ComboType.BUILD_TURRET:
                        On_Build_Turret_Combo.Invoke();
                        break;
                    case ComboType.BUILD_REPAIR:
                        On_Build_Repair_Combo.Invoke();
                        break;
                }
                ClearComboHistroy();
            }
        }
    }
}
