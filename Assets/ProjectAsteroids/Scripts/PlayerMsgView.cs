using UnityEngine;
using UnityEngine.UI;

public class PlayerMsgView : MonoBehaviour
{
    //UI
    public Text playerLevel;
    public Text playerExperience;
    public Text goldNum;
    public Button experienceUpButton;

    void Start()
    {
        //Привязка заказных мероприятий
        PlayerMsgModel.GetMod().OnLevelChange += SetLevel;

        //Привязка заказных мероприятий
        PlayerMsgModel.GetMod().OnExperienceChange += SetExperience;

        PlayerMsgModel.GetMod().OnFullExperienceChange += SetFullExperience;
        PlayerMsgModel.GetMod().OnGoldNumChange += SetGoldNum;

        // Просмотр функции управления кнопкой привязки
        experienceUpButton.onClick.AddListener(
            PlayerMsgController.controller.OnExperienceUpButtonClick);
    }

    // Изменить значение UILevel
    public void SetLevel(int level)
    {
        playerLevel.text = level.ToString();
    }

    // Изменить значение пользовательского интерфейса
    public void SetExperience(int experience)
    {
        // Отсоединить строку с помощью "/"
        string[] str = playerExperience.text.Split(new char[] { '/' });

        //Реорганизуйтесь с новой ценностью опыта
        playerExperience.text = experience + "/" + str[1];
    }
    
    public void SetFullExperience(int fullExiperience)
    {
        string[] str = playerExperience.text.Split(new char[] { '/' });
        playerExperience.text = str[0] + "/" + fullExiperience;
    }
    
    public void SetGoldNum(int goldn)
    {
        goldNum.text = goldn.ToString();
    }
}