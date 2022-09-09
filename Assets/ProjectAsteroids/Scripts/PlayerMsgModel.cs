using UnityEngine;
using System.Collections;

/// <summary>
/// Делегирование модели (выполняется при изменении информации пользователя)
/// </summary>

public delegate void OnValueChange(int val);

public class PlayerMsgModel
{
    // Уровень игрока
    private int playerLevel;
    
    // Опыт игрока
    private int playerExperience;
    
    // Опыт обновления игрока
    private int playerFullExperience;
    
    // Количество золотых монет
    private int goldNum;
    
    // Объявить объект делегата и получить событие, срабатывающее при изменении уровня
    public OnValueChange OnLevelChange;
    
    // Объявить объект делегата и получить событие, которое запускается при изменении опыта
    public OnValueChange OnExperienceChange;
    
    // Объявление объекта делегата и получение события, запускаемого при изменении опыта обновления
    public OnValueChange OnFullExperienceChange;

    // Объявить объект делегата и получить событие, которое запускается при изменении количества золотых монет
    public OnValueChange OnGoldNumChange;

    //Единичный случай
    private static PlayerMsgModel mod;

    public static PlayerMsgModel GetMod()
    {
        if (mod == null)
            mod = new PlayerMsgModel();
        
        return mod;
    }

    /// <summary>
    /// Атрибуты уровня игрока
    /// </summary>
    /// <value>The player level.</value>
    public int PlayerLevel
    {
        get
        {
            return playerLevel;
        }
        set
        {
            playerLevel = value;
            // Если доверенный объект не пустой
            if (OnLevelChange != null)
            {
              //  Выполнить поручение
                OnLevelChange(playerLevel);
            }
        }
    }

    /// <summary>
    /// Атрибуты опыта игрока
    /// </summary>
    /// <value>The player experience.</value>
    public int PlayerExperience
    {
        get
        {
            return playerExperience;
        }
        set
        {
            playerExperience = value;

            if (OnExperienceChange != null)
                OnExperienceChange(playerExperience);
        }
    }

    /// <summary>
    /// Атрибуты опыта улучшения игрока
    /// </summary>
    /// <value>The player full experience.</value>
    public int PlayerFullExperience
    {
        get
        {
            return playerFullExperience;
        }

        set
        {
            playerFullExperience = value;
            
            if (OnFullExperienceChange != null)
                OnFullExperienceChange(playerFullExperience);
        }
    }

    /// <summary>
    /// Атрибут количества золотых монет
    /// </summary>
    /// <value>The gold number.</value>
    public int GoldNum
    {
        get
        {
            return goldNum;
        }
        set
        {
            goldNum = value;

            if (OnGoldNumChange != null)
                OnGoldNumChange(goldNum);
        }
    }
}