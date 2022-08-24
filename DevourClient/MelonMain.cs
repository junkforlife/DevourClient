﻿using UnityEngine;
using MelonLoader;
using System.Threading;
using DevourClient.Helpers;

namespace DevourClient
{
    public class Load : MelonMod
    {
        bool flashlight_toggle = false;
        bool flashlight_colorpick = false;
        bool player_esp_colorpick = false;
        bool azazel_esp_colorpick = false;
        bool level_70 = false;
        bool level_666 = false;
        bool change_server_name = false;
        bool change_steam_name = false;
        bool fly = false;
        float fly_speed = 5;
        public bool _IsAutoRespawn = false;
        public static bool exp_modifier = false;
        public static float exp = 1000f;
        bool player_esp = false;
        bool player_snapline = false;
        bool azazel_esp = false;
        bool azazel_snapline = false;
        bool item_esp = false;
        bool spam_message = false;

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("For the Queen !");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                try
                {
                    GameUI gameUI = UnityEngine.Object.FindObjectOfType<GameUI>();

                    if (Settings.Settings.menu_enable)
                    {
                        gameUI.HideMouseCursor();
                    }
                    else
                    {
                        gameUI.ShowMouseCursor();
                    }
                }
                catch { }

                Settings.Settings.menu_enable = !Settings.Settings.menu_enable;
            }

            if (this.flashlight_toggle && Player.IsInGame())
            {
                Hacks.Misc.BigFlashlight(false);
            }
            else if (!this.flashlight_toggle && Player.IsInGame())
            {
                Hacks.Misc.BigFlashlight(true);
            }

            if (this.spam_message)
            {
                MelonLogger.Msg("done");
                Hacks.Misc.MessageSpam(Settings.Settings.message_to_spam);
            }

            if (this.level_70 != this.level_666 && !Player.IsInGame())
            {
                if (this.level_70)
                {
                    Hacks.Misc.SetRank(70);
                }
                else
                {
                    Hacks.Misc.SetRank(666);
                }
            }

            if (this.change_server_name && !Player.IsInGame())
            {
                Hacks.Misc.SetServerName("patate on top !");
            }

            if (this.change_steam_name && !Player.IsInGame())
            {
                Hacks.Misc.SetSteamName("patate");
            }

            if (this.fly && Player.IsInGameOrLobby())
            {
                Hacks.Misc.Fly(this.fly_speed);
            }
            
            if(Player.IsInGame() && _IsAutoRespawn && Helpers.Player.IsPlayerCrawling())
            {
                Hacks.Misc.AutoRespawn();                
            }
        }

        public override void OnGUI()
        {
            if (this.player_esp || this.player_snapline)
            {
                foreach (NolanBehaviour player in UnityEngine.Object.FindObjectsOfType<NolanBehaviour>() as UnhollowerBaseLib.Il2CppReferenceArray<NolanBehaviour>)
                {
                    if (player != null)
                    {


                        Vector3 pivotPos = player.transform.position; //Pivot point NOT at the origin, at the center
                        Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f; //At the feet
                        Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

                        if (Camera.main == null)
                        {
                            continue;
                        }

                        Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                        Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                        if (w2s_footpos.z > 0f)
                        {
                            //string playername = player.field_Private_PhotonView_0.field_Private_ObjectPublicObInBoStBoHaStObInHaUnique_0.field_Private_String_0;//player.photonView._Controller_k__BackingField.NickName;

                            if (player.entity.IsOwner)
                            {
                                continue;
                            }

                            Render.Render.DrawBoxESP(w2s_footpos, w2s_headpos, Settings.Settings.player_esp_color, "", this.player_snapline, this.player_esp);
                        }

                    }
                }
            }

            if (this.azazel_esp || this.azazel_snapline)
            {
                SurvivalAzazelBehaviour survivalAzazel = UnityEngine.Object.FindObjectOfType<SurvivalAzazelBehaviour>();
                if (survivalAzazel != null)
                {


                    Vector3 pivotPos = survivalAzazel.transform.position; //Pivot point NOT at the origin, at the center
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

                    if (Camera.main != null)
                    {
                        Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                        Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                        if (w2s_footpos.z > 0f)
                        {
                            Render.Render.DrawBoxESP(w2s_footpos, w2s_headpos, Settings.Settings.azazel_esp_color, "Azazel", this.azazel_snapline, this.azazel_esp);
                        }
                    }
                }
            }

            if (Settings.Settings.menu_enable) //Si on appuie sur INSERT
            {
                GUI.Label(new Rect(300, Settings.Settings.y, 100, 30), "Devour Client"); //Titre du menu
                this.flashlight_toggle = GUI.Toggle(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 100, 150, 20), this.flashlight_toggle, "Big Flashlight"); //Checkbox Flashlight
                this.spam_message = GUI.Toggle(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 250, 150, 20), this.spam_message, "Chat Spam"); //Checkbox Chat Spam
                this.level_70 = GUI.Toggle(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 190, 150, 20), this.level_70, "Level 70"); //Checkbox lvl 70
                this.level_666 = GUI.Toggle(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 220, 150, 20), this.level_666, "Level 666"); //Checkbox lvl 70
                this.change_server_name = GUI.Toggle(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 40, 150, 20), this.change_server_name, "Change server name"); //Checkbox servername
                this.change_steam_name = GUI.Toggle(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 70, 150, 20), this.change_steam_name, "Change steam name"); //Checkbox servername
                this.fly = GUI.Toggle(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 100, 150, 20), this.fly, "Fly"); //Checkbox fly
                this.fly_speed = GUI.HorizontalSlider(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 130, 100, 10), this.fly_speed, 5f, 20f); //Slider for the fly speed
                GUI.Label(new Rect(Settings.Settings.x + 310, Settings.Settings.y + 125, 100, 30), this.fly_speed.ToString()); //Prints the value of the slider;
                this._IsAutoRespawn = GUI.Toggle(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 190, 150, 20), this._IsAutoRespawn, "Auto-Respawn");
                
                Load.exp_modifier = GUI.Toggle(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 40, 150, 20), Load.exp_modifier, "Exp Modifier");
                Load.exp = GUI.HorizontalSlider(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 70, 100, 10), Load.exp, 1000f, 3000f); //Slider for the fly speed
                GUI.Label(new Rect(Settings.Settings.x + 500, Settings.Settings.y + 65, 100, 30), Load.exp.ToString()); //Prints the value of the slider;

                this.player_esp = GUI.Toggle(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 100, 150, 20), this.player_esp, "Player ESP");
                this.player_snapline = GUI.Toggle(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 130, 150, 20), this.player_snapline, "Player Snapline");

                this.azazel_esp = GUI.Toggle(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 190, 150, 20), this.azazel_esp, "Azazel ESP");
                this.azazel_snapline = GUI.Toggle(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 220, 150, 20), this.azazel_snapline, "Azazel Snapline");

                if (GUI.Button(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 40, 150, 20), "Unlock Achievements"))
                {
                    Thread AchievementsThread = new Thread(
                        new ThreadStart(Hacks.Unlock.Achievements));
                    AchievementsThread.Start();

                    MelonLogger.Msg("Achievements Unlocked !");
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 70, 150, 20), "Unlock Doors") && Player.IsInGame())
                {
                    Hacks.Unlock.Doors();

                    MelonLogger.Msg("Doors Unlocked !");
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 250, 150, 20), "Azazel ESP Color"))
                {
                    azazel_esp_colorpick = !azazel_esp_colorpick;
                    MelonLogger.Msg("azazel_esp_colorpick color picker : " + azazel_esp_colorpick.ToString());

                }

                if (azazel_esp_colorpick)
                {
                    Color azazel_esp_colorpick_color_input = DevourClient.Helpers.GUIHelper.ColorPick("Azazel ESP Color", Settings.Settings.azazel_esp_color);
                    Settings.Settings.azazel_esp_color = azazel_esp_colorpick_color_input;
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 390, Settings.Settings.y + 160, 150, 20), "Player ESP Color"))
                {
                    player_esp_colorpick = !player_esp_colorpick;
                    MelonLogger.Msg("player_esp_colorpick color picker : " + player_esp_colorpick.ToString());

                }

                if (player_esp_colorpick)
                {
                    Color player_esp_colorpick_color_input = DevourClient.Helpers.GUIHelper.ColorPick("Player ESP Color", Settings.Settings.player_esp_color);
                    Settings.Settings.player_esp_color = player_esp_colorpick_color_input;
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 130, 150, 20), "Flashlight Color")) 
                {
                    flashlight_colorpick = !flashlight_colorpick;
                    MelonLogger.Msg("Flashlight color picker : "+ flashlight_colorpick.ToString());

                }

                if (flashlight_colorpick)
                {
                    Color flashlight_color_input = DevourClient.Helpers.GUIHelper.ColorPick("Flashlight Color", Settings.Settings.flashlight_color);
                    Settings.Settings.flashlight_color = flashlight_color_input;

                    if (Player.IsInGame())
                    {
                        Hacks.Misc.FlashlightColor(flashlight_color_input);
                    }
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 160, 150, 20), "TP Keys") && Player.IsInGame())
                {
                    Hacks.Misc.TPKeys();
                    MelonLogger.Msg("Here are your keys !");
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 10, Settings.Settings.y + 280, 150, 20), "Instant Win") && Player.IsInGame())
                {
                    Hacks.Misc.InstantWin();
                    MelonLogger.Msg("EZ Win");
                }

                if (GUI.Button(new Rect(Settings.Settings.x + 200, Settings.Settings.y + 160, 150, 20), "Random sound"))
                {
                    Hacks.Misc.PlaySound();
                    MelonLogger.Msg("Playing a random sound !");
                }

            }
        }
    }
}
