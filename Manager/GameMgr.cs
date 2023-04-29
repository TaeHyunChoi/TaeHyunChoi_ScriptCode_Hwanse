using UnityEngine;

public class GameMgr
{
    //## Map
    private static MapData NowMap;
    private static MapData LastMap;
    private static Vector3 lastFieldPos;

    public static int NowOrder { get => nowOrder; }
    private static int nowOrder;

    public static void ChangeMapData(ushort mapCode)
    {
        LastMap = NowMap;
        lastFieldPos = UnitMgr.MyPC.Pos;
        NowMap = DataMgr.MapTBL.Find(map => map.Code == mapCode);
    }


    public static void Battle_Enter()
    {
        ChangeMapData(mapCode: NowMap.BattleMapCode);   //������ ������ ����
        UnitMgr.Battle_InitUnitList(NowMap);            //������ �����ϴ� ���� ���� ����, �߰�
        UnitMgr.Battle_SetPosition();                   //ȭ�� ���� ���� ��ġ ����
        CameraMgr.OnBattleCam(true);                    //���� ī�޶� ����

        UnitMgr.Battle_SelectAction(nowOrder = 0);  //[0]��° ���� �׼� ����
    }
    public static void Battle_NextTurn()
    {
        //End Battle
        if (UnitMgr.IsEndBattle())
        {
            Debug.Log("End Battle");
            return;
        }


        //End All Units Turn: �����ҴɵǸ� �׳� Remove�� �����߰ڴ�
        if (UnitMgr.IsEndCycle(nowOrder))
        {
            UnitMgr.Battle_OrderByShellSort();
            nowOrder = -1;
            Debug.Log($"New Cycle");
        }

        //Next Trun
        UnitMgr.Battle_SelectAction(++nowOrder);
    }
    private static void Battle_End()
    { 
        
    }
}