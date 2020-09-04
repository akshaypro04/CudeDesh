
using UnityEngine;

public class LevelScoreManager : MonoBehaviour
{
    float LevelSelectiondata;
    public int[] Value;

    public void SelectPlayerLevel()
    {
        LevelSelectiondata = GameManager.instances.GetEnemyTotalDamage();   // according last damage point player unlocks levels
        print("player Damage points : " + LevelSelectiondata);
        LevelSelector();
    }

                    //// U N L O C K I N G   L E V E L S 
    void LevelSelector()
    {
        for (int i = 0; i < Value.Length; i++)        
        {
            try
            {
                if (LevelSelectiondata >= Value[i] && LevelSelectiondata < Value[i + 1])       
                {
                    GameManager.instances.Setlevel(i);                                  //till in last level 
                    GameManager.instances.SetEnemyTotalDamage(Value[i]);
                }
            }
            catch
            {
                GameManager.instances.Setlevel(Value.Length - 1);                       // last level
                GameManager.instances.SetEnemyTotalDamage(Value[Value.Length - 1]);     // in last level value
            }
        }
    }

}
