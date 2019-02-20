using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using static CitizenFX.Core.Native.API;
using MenuAPI;

namespace AlsekRGB.Client
{
    public class PaintMenu
    {
        //menu variables
        private Menu Paint;
        //menu variables
        
        //color variables
        public static int RedRGB { get; private set; } = 0;
        public static int BlueRGB { get; private set; } = 0;
        public static int GreenRGB { get; private set; } = 0;
        public bool ApplyColorPrimary { get; private set; } = false;
        public bool ApplyColorSecondary { get; private set; } = false;
        //color variables
        
        //step variables
        public int FloatStep { get; private set; } = 0;
        //step variables
        
        private void CreateMenu()
        {
            Paint = new Menu("Paint", "Painters place");
            
            /*
            ########################################################
                                 Paint
            */       
            //Box for applying primary paint
            MenuCheckboxItem paintPrimary = new MenuCheckboxItem("Apply primary RGB", "This will make your paint apply as you change it")
            {
                Style = MenuCheckboxItem.CheckboxStyle.Tick
            };
            Paint.AddMenuItem(paintPrimary);
            //Box for applying primary paint
            //Box for applying secondary paint
            MenuCheckboxItem paintSecondary = new MenuCheckboxItem("Apply secondary RGB", "This will make your paint apply as you change it")
            {
                Style = MenuCheckboxItem.CheckboxStyle.Tick
            };
            Paint.AddMenuItem(paintSecondary);
            //Box for applying secondary paint
            
            
            
            // Red Dynamic List
            string RedDyn(MenuDynamicListItem item, bool left)
            {
                if (left)
                {
                    var newvalue = RedRGB - 1;
                    if (newvalue < 0)
                    {
                        newvalue = RedRGB = 255;
                        
                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Min value allowed for ~b~Red~w~ is 0");
                        }
                    }
                    else
                    {
                        RedRGB = newvalue;
                    }
                }
                else
                {
                    var newvalue = RedRGB + 1;
                    if (newvalue > 255)
                    {
                        newvalue = RedRGB = 0;

                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Max value allowed for ~b~Red~w~ is 255");
                        }
                    }
                    else
                    {
                        RedRGB = newvalue;
                    }
                }
                return RedRGB.ToString();
            }
            MenuDynamicListItem RedDynList = new MenuDynamicListItem("Red", "0", RedDyn, "Set the red in RGB.");
            Paint.AddMenuItem(RedDynList);
            // Red Dynamic List
            
            // Green Dynamic List
            string GreenDyn(MenuDynamicListItem item, bool left)
            {
                if (left)
                {
                    var newvalue = GreenRGB - 1;
                    if (newvalue < 0)
                    {
                        newvalue = GreenRGB = 255;
                        
                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Min value allowed for ~b~Green~w~ is 0");
                        }
                    }
                    else
                    {
                        GreenRGB = newvalue;
                    }
                }
                else
                {
                    var newvalue = GreenRGB + 1;
                    if (newvalue > 255)
                    {
                        newvalue = GreenRGB = 0;

                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Max value allowed for ~b~Green~w~ is 255");
                        }
                    }
                    else
                    {
                        GreenRGB = newvalue;
                    }
                }
                return GreenRGB.ToString();
            }
            MenuDynamicListItem GreenDynList = new MenuDynamicListItem("Green", "0", GreenDyn, "Set the Green in RGB.");
            Paint.AddMenuItem(GreenDynList);
            // Green Dynamic List
            
            // Blue Dynamic List
            string BlueDyn(MenuDynamicListItem item, bool left)
            {
                if (left)
                {
                    var newvalue = BlueRGB - 1;
                    if (newvalue < 0)
                    {
                        newvalue = BlueRGB = 255;
                        
                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Min value allowed for ~b~Green~w~ is 0");
                        }
                    }
                    else
                    {
                        BlueRGB = newvalue;
                    }
                }
                else
                {
                    var newvalue = BlueRGB + 1;
                    if (newvalue > 255)
                    {
                        newvalue = BlueRGB = 0;

                        if (MainMenu.DebugMode == true)
                        {
                            Screen.ShowNotification($"AlsekRGB: Max value allowed for ~b~Green~w~ is 255");
                        }
                    }
                    else
                    {
                        BlueRGB = newvalue;
                    }
                }
                return BlueRGB.ToString();
            }
            MenuDynamicListItem BlueDynList = new MenuDynamicListItem("Blue", "0", BlueDyn, "Set the Blue in RGB.");
            Paint.AddMenuItem(BlueDynList);
            // Blue Dynamic List
            
            /*
                     Paint
            ########################################################
            */  
            
            /*
            ########################################################
                                Event handlers
            ########################################################
            */
            
            Paint.OnMenuDynamicListItemCurrentItemChange += ( _menu, _dynamicListItem, _oldCurrentItem, __newCurrentItem) => 
            {
                // Code in here would get executed whenever the value of the current item of a dynamic list item changes.
                if (MainMenu.DebugMode == true)
                {
                    Debug.WriteLine($"OnMenuDynamicListItemCurrentItemChange: [{_menu}, {_dynamicListItem}, {_oldCurrentItem}, {__newCurrentItem}]");
                }

                if (_dynamicListItem == RedDynList)
                {
                    if (ApplyColorPrimary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomPrimaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (ApplyColorSecondary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomSecondaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (MainMenu.DebugMode == true)
                    {
                        Debug.Write($"{RedRGB}");
                    }
                    else
                    {
                        return;
                    }   
                }

                if (_dynamicListItem == GreenDynList)
                {
                    if (ApplyColorPrimary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomPrimaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (ApplyColorSecondary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomSecondaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (MainMenu.DebugMode == true)
                    {
                        Debug.Write($"{GreenRGB}");
                    }
                    else
                    {
                        return;
                    }
                }

                if (_dynamicListItem == BlueDynList)
                {
                    if (ApplyColorPrimary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomPrimaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (ApplyColorSecondary == true)
                    {
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomSecondaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    if (MainMenu.DebugMode == true)
                    {
                        Debug.Write($"{BlueRGB}");
                    }
                    else
                    {
                        return;
                    }
                }
            };            
            
            Paint.OnCheckboxChange += (_menu, _item, _index, _checked) =>
            {
                // Code in here gets executed whenever a checkbox is toggled.
                if (MainMenu.DebugMode == true)
                {
                    Debug.WriteLine($"OnCheckboxChange: [{_menu}, {_item}, {_index}, {_checked}]");
                }
                if (_item == paintPrimary)
                {
                    if (_checked)
                    {
                        ApplyColorPrimary = true;
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomPrimaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    else
                    {
                        ApplyColorPrimary = false;
                    }
                }
                
                if (_item == paintSecondary)
                {
                    if (_checked)
                    {
                        ApplyColorSecondary = true;
                        var PlayerVehicle = GetPlayersLastVehicle();
                        SetVehicleCustomSecondaryColour(PlayerVehicle, RedRGB, BlueRGB, GreenRGB);
                    }
                    else
                    {
                        ApplyColorSecondary = false;
                    }
                }
            };
        }
        
        public static async void RedInput()
        {
            string result = await Functions.GetUserInput(windowTitle: "Enter a number between 0 and 255",  maxInputLength: 3);
            
            int resultint = 0;
            Int32.TryParse(result, out resultint);
            RedRGB = resultint;
            
        }
        
        public Menu GetMenu()
        {
            if (Paint == null)
            {
                CreateMenu();
            }
            return Paint;
        }
    }
}