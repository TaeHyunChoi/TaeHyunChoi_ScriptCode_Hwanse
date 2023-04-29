public class IDxUNIT
{
    public const byte SPEED_MOVE = 5;

    //Unit Index
    public const byte ATAHO     = 0;
    public const byte LINXHANG  = 1;
    public const byte SMASHU    = 2;
    public const byte COMMON    = 255;

    //Group Index
    public const byte PLAYER    = 1;
    public const byte ENEMY     = 2;
    public const byte NPC       = 3;

    //Stat
    public const byte HP        = 0;     //ü��   
    public const byte MP        = 1;     //���   
    public const byte EXP       = 2;     //����ġ
    public const byte STR       = 3;     //���� ���ݷ�
    public const byte CON       = 4;     //���� ����
    public const byte INT       = 5;     //���� ���ݷ�
    public const byte WIS       = 6;     //���� ����
    public const byte DEX       = 7;     //�����       (����, ũ��Ƽ��)
    public const byte AGI       = 8;     //���߷�       (�ൿ����, ȸ��) 
    public const byte CHA       = 9;     //ī������     (___)
    public const byte LUK       = 10;    //��           (___)
    public const byte STAT_CNT  = 11;

    //Battle Mode
    public const byte MODE_NORMAL       = 0;
    public const byte MODE_CHARGE       = 1;
    public const byte MODE_DEFENCE      = 2;
    public const byte MODE_PREEMTIVE    = 3;
    public const byte MODE_COUNTER      = 4;

    //Animation
    public const string ANIME_IDLE    = "IDLE";
    public const string ANIME_MOVE    = "MOVE";
    public const string ANIME_SKILL   = "SKILL";
    public const string ANIME_HIT     = "HIT";
    public const string ANIME_EVENT   = "EVENT";

    //[Unit.Group]_[Target Count]
    public const byte TARGET_ENM_SOLO   = 1;
    public const byte TARGET_SELF       = 2;
    public const byte TARGET_PLY_SOLO   = 3;
    public const byte TARGET_ENM_ALL    = 4;
    public const byte TARGET_PLY_ALL    = 5;
    public const byte TARGET_XOR_SELF   = 6;
}
public class IDxINPUT
{
    //Mode
    public const byte BLOCKED          =  0;
    public const byte BASE             =  1;
    public const byte FIELD            =  2;
    public const byte BATTLE_MENU      =  3;
    public const byte BATTLE_TARGERT   =  4;
    public const byte BATTLE_COMBO     =  5;
    public const byte CHEAT            = 15;

    //Direction
    public const byte DIRECTION      = 0xF0;
    public const byte UP             = 0x80;
    public const byte DOWN           = 0x40;
    public const byte LEFT           = 0x20;
    public const byte RIGHT          = 0x10;

    //Interact
    public const byte INTERACT       = 0x0F;
    public const byte ENTER          = 0x08;
    public const byte CANCEL         = 0x04;
    public const byte OPTION         = 0x02;  // System Option
    public const byte TRIGGER        = 0x01;  // joypad [LB] button 
    public const byte NONE           = 0x00;
}
public class IDxUI
{
    //UI Window
    public const byte BATTLE_SELECT = 0x00;
    public const byte BATTLE_COMBO  = 0x01;
}
public class IDxSkill
{
    public const byte BASIC   = 1;
    public const byte SOLO    = 2;
    public const byte GROUP   = 3;
    public const byte SPECIAL = 6;
}
public class IDxVALUE
{
    public static float LERP = 20 * UnityEngine.Time.deltaTime;
}