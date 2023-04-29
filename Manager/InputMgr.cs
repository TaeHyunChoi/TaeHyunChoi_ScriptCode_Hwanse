using UnityEngine;

public class InputMgr
{
    public delegate void InputDelegate();
    public static InputDelegate Update;

    private static int input = IDxINPUT.NONE;

    private static bool isCombo;

    public static void SetMode(int type)
    {
        //�⺻ �Է°�
        Update =  Base;
        Update += Option;

        //��Ȳ�� �Է°� �߰�
        switch (type)
        {
            case IDxINPUT.FIELD:            Update += Field;             break;
            case IDxINPUT.BATTLE_MENU:      Update += BattleAction;      break;
            case IDxINPUT.BATTLE_TARGERT:   Update += BattleTargeting;   break;
            case IDxINPUT.BATTLE_COMBO:     Update += BattleCombo;       break;
            case IDxINPUT.CHEAT:            Update += Cheat;             break;
            default: break;
        }

        //�Է°� �ʱ�ȭ
        Update += Reset;
    }


    private static void Base()
    {
        if (Input.GetButtonDown("Up"))
            input |= IDxINPUT.UP;
        if (Input.GetButtonDown("Down"))
            input |= IDxINPUT.DOWN;
        if (Input.GetButtonDown("Left"))
            input |= IDxINPUT.LEFT;
        if (Input.GetButtonDown("Right"))
            input |= IDxINPUT.RIGHT;

        if (Input.GetButtonDown("Enter"))
            input |= IDxINPUT.ENTER;
        if (Input.GetButtonDown("Cancel"))
            input |= IDxINPUT.CANCEL;
        if (Input.GetButtonDown("Option"))
            input |= IDxINPUT.OPTION;
    }
    private static void Option()
    { 
        
    }
    private static void Reset()
    {
        input ^= input;
    }


    private static void Field()
    {
        //GetButton: �ٿ� ������ �Էµǵ���
        if (Input.GetButton("Up"))
            input |= IDxINPUT.UP;
        if (Input.GetButton("Down"))
            input |= IDxINPUT.DOWN;
        if (Input.GetButton("Left"))
            input |= IDxINPUT.LEFT;
        if (Input.GetButton("Right"))
            input |= IDxINPUT.RIGHT;

        if ((input & IDxINPUT.DIRECTION) != 0)
            UnitMgr.Field_PlayerMoveTo(input);

        //npc, ������ ����� ��ȣ�ۿ� �뵵
        if ((input & IDxINPUT.ENTER) != 0)
            Debug.Log("ENTER");
    }
    private static void BattleAction()
    {
        if (input == 0)
            return;

        UIMgr.Battle_SelectMenu(input);
    }
    private static void BattleTargeting()
    {
        if (input == 0)
            return;

        UIMgr.Battle_SelectTarget(input);
    }
    private static void BattleCombo()
    {
        if (Input.GetButton("Up"))
            input |= IDxINPUT.UP;
        if (Input.GetButton("Down"))
            input |= IDxINPUT.DOWN;
        if (Input.GetButton("Left"))
            input |= IDxINPUT.LEFT;
        if (Input.GetButton("Right"))
            input |= IDxINPUT.RIGHT;
        
        if (isCombo & Input.GetButtonDown("Trigger"))
            UIMgr.Show(IDxUI.BATTLE_COMBO, true);
        if (isCombo & Input.GetButton("Trigger"))
            input |= IDxINPUT.TRIGGER;
        if (Input.GetButtonUp("Trigger"))
            isCombo = false;

        if (!isCombo)
        {
            UIMgr.UpdateUI_BattleCombo(active: false);
            UnitMgr.Battle_SlowUnitAnime(slow: false);
            return;
        }

        if ((input & IDxINPUT.TRIGGER) != 0)
        {
            UIMgr.UpdateUI_BattleCombo(active: true);
            UnitMgr.Battle_SlowUnitAnime(slow: true);
        }
        if ((input & IDxINPUT.DIRECTION) != 0)
        { 
            
        }
    }

    public static void Set_IsCombo(bool isOn)
    {
        isCombo = isOn;
    }

    private static void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GameMgr.Battle_Enter();
    }
}