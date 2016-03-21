using UnityEngine;
using System.Collections;
using System;

public class PlayGlobalVariables : MonoBehaviour {
    public static int money = 0;
    public static int experience = 0;

    public static void addMoney(int n)
    {
        money += n;
        experience += n;


        Game.current.currentProfile.money = money;
        Game.current.currentProfile.exp = experience;
            


        SaveLoad.Save();
    }

    public static void reduceMoney(int n)
    {

        
        try
        {
            if ((money - n) >= 0)
            {
                money -= n;
                Game.current.currentProfile.money = money;
                Game.current.currentProfile.exp = experience;
                
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("NullReference => [reduceMoney (" + n + ") : void]");
        }

        SaveLoad.Save();
    }

    public static void setMoney(int n)
    {
        try
        {
            money = n;

            Game.current.currentProfile.money = money;
            Game.current.currentProfile.exp = experience;
            
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("NullReference => [setMoney (" + n + ") : void]");
        }

        SaveLoad.Save();
    }

    public static void reduceMoneyAndExperience(int n)
    {
        try
        {
            if ((money - n) >= 0)
            {
                money -= n;
                experience = money;
                Game.current.currentProfile.money = money;
                Game.current.currentProfile.exp = experience;
                
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("NullReference => [reduceMoneyAndExperience (" + n + ") : void]");
        }

        SaveLoad.Save();
    }

    public static bool hasEnoughExperience(int exp)
    {
        bool ret = false;

        if(experience >= exp)
        {
            ret = true;
        }

        return ret;
    }

    public static float getEffectsVolume()
    {
        return Game.current.currentProfile.effectsVol;
    }

    public static float getMusicVolume()
    {
        return Game.current.currentProfile.musicVol;
    }



}
