using UnityEngine;

public class PlayerMsgController : MonoBehaviour
{
    public static PlayerMsgController controller;
    private int levelUpValue = 20;

    void Awake()
    {
        controller = this;
    }

    void Start()
    {
        PlayerMsgModel.GetMod().PlayerLevel = 1;
        PlayerMsgModel.GetMod().PlayerExperience = 0;
        PlayerMsgModel.GetMod().PlayerFullExperience = 100;
        PlayerMsgModel.GetMod().GoldNum = 0;
    }

    /// <summary>
    /// Событие нажатия кнопки для улучшения восприятия
    /// </summary>
    public void OnExperienceUpButtonClick()
    {
        PlayerMsgModel.GetMod().PlayerExperience += levelUpValue;
        
        if (PlayerMsgModel.GetMod().PlayerExperience
            >= PlayerMsgModel.GetMod().PlayerFullExperience)
        {
            PlayerMsgModel.GetMod().PlayerLevel += 1;
            PlayerMsgModel.GetMod().PlayerFullExperience +=
                200 * PlayerMsgModel.GetMod().PlayerLevel;
            levelUpValue += 20;
            
            if (PlayerMsgModel.GetMod().PlayerLevel % 3 == 0)
            {
                PlayerMsgModel.GetMod().GoldNum +=
                    100 * PlayerMsgModel.GetMod().PlayerLevel;
            }
        }
    }
}