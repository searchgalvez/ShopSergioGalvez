/////////////////////////////////////////////////////////////////////////////
// TODO:    BEFORE YOU WRITE ANY CODE: 
//          Read the Instructions.doc file.
//          Run the example.exe to see how this program will behave.
//          Read through all of the TODOs. This will give you an overview
//          of how the program will be put together.
//          
//          Do not modify any existing program code unless expressly 
//          instructed to do so.
//
//          The program does not have to look exactly like the example.
//          (For instance, the text doesn't have to be centered on screen)
//          It only needs to function the same.

//=============================================================================
// Program's main file, which houses the Main method.
//
// You should probably start working on the TODOs in the Item class first and 
// then move on to Inventory.cs and finally program.cs.
// You do not need to concern yourself w/ methods outside Main, in this file.
//
//=============================================================================

// TODO: When all work is done in Item.cs and Inventory.cs uncomment the following line.
// #define INVENTORY

using System;
using FSPG;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            /**********************************************************************
             *                                                                    *
             *    Do not remove (or 'comment out') any of the lines that begin    *
             *    with # (pound sign). These are part of the program              *
             *                                                                    *
             **********************************************************************/

#if INVENTORY
            Item HealthPotion = new Item();
            HealthPotion.SetName("Health Potion");
            HealthPotion.SetCost(10);
            Item MagicPotion = new Item("Magic Potion", 15);
            Item IronDagger = new Item("Iron Dagger", 30);
            Item WoodenClub = new Item("Wooden Club", 20);
            Item DaedricHelm = new Item("Daedric Helm", 120);
            Item MageRobe = new Item("Mage Robe", 50);
            Item AkaviriKatana = new Item("Akaviri Katana", 200);
            Item WabbaJack = new Item ("Wabbajack",500);

            Item[] PlayerStartingItems = { HealthPotion, HealthPotion, MagicPotion, WoodenClub };

            Item[] StoreStartingItems = { HealthPotion, MagicPotion, MagicPotion, IronDagger,
                                               DaedricHelm, MageRobe, AkaviriKatana, WabbaJack };
#endif // INVENTORY   

            // TODO: Define an Inventory object for the player,
            //		 an Inventory object for the store. 
            Inventory playerInv = new Inventory();
            Inventory storeInv = new Inventory();

            // TODO: Ask the user for their name and define a string for the
            //       name. Store their input in the string. If they entered 
            //       an empty string (e.g. "") assign them a default name.
            Utility.WriteCentered("What is your name? ");
            string playerName = Console.ReadLine();
            if (playerName.Length == 0)
                playerName = "Player One";

            // TODO: Use the Gold property to give the player inventory 200 Gold.
            playerInv.SetGold(200);
            for (int index = 0; index < objArray1.Length; ++index)

            // TODO: Use the AddItem method to add each item in the
            //		 PlayerStartingItems array to the player's inventory.
            {
                Item toAdd = objArray1[index];
                playerInv.AddItem(toAdd);
            }

            // TODO: Use the Gold property to give the store inventory 350 Gold.
            storeInv.SetGold(350);
            for (int index = 0; index < objArray2.Length; ++index) 

                // TODO: Use the AddItem method to add each item in the
                //		 StoreStartingItems array to the store's inventory.
                storeInv.AddItem(objArray2[index]);

            while (true) 
            {
                int sel = 0;
                do
                {
                    Console.Clear();

                    // TODO: Call the ShowInventories method and pass in the player's name,
                    //		 the player's inventory and the store's inventory.
                    Program.ShowInventories(playerName, playerInv, storeInv);

                    Console.SetCursorPosition(5, 18);
                    Console.Write("What would you like to do?"
                        + "1) Buy"
                        + "2) Sell"
                        + "3) Leave"
                        + "_");

                    sel = Utility.ReadInt();

                } while (!Utility.IsReadGood() || (sel < 1 || sel > 3));

                if (3 == sel) 
                    break;

                bool doBuy = false;
                if (1 == sel)
                {
                    doBuy = true;
                }

                // TODO: Call the DoTransaction method and send it the player's name,
                //		 the player's inventory, the store's inventory and the doBuy variable.
                Program.DoTransaction(playerName, playerInv, storeInv, doBuy);
                
                    else
                        break;
                
            }

            Console.Clear();
            Utility.WriteCentered("Thanks! Come back again!");
            Utility.WaitForEnterKey();
        }

#if INVENTORY
        static void ShowInventories(string playerName, Inventory playerInv, Inventory storeInv)
        {
            Console.SetCursorPosition(2, 2);
            Console.Write(playerName + "'s inventory: ");
            playerInv.DisplayInventory(4, 3);

            Console.SetCursorPosition(39, 2);
            Console.Write("The Store's inventory: ");
            storeInv.DisplayInventory(41, 3);
        }

        static void DoTransaction(string playerName, Inventory playerInv, Inventory storeInv, bool buy)
        {
            if (buy)
            {
                DoBuy(playerName, playerInv, storeInv);
            }
            else
            {
                DoSell(playerName, playerInv, storeInv);
            }
        }

        static void DoBuy(string playerName, Inventory playerInv, Inventory storeInv)
        {
            string itemName = "";

            do
            {
                Console.Clear();
                ShowInventories(playerName, playerInv, storeInv);
                Console.SetCursorPosition(5, 18);
                Console.Write("What would you like to buy? (Type the item name): __________\b\b\b\b\b\b\b\b\b\b");

                itemName = Console.ReadLine();

            } while (itemName.Length == 0);

            Item itemToBuy = storeInv.GetItem(itemName);

            if (null == itemToBuy)
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("The Store does not have that item!");
                Utility.WaitForEnterKey();
                return;
            }

            if (itemToBuy.GetCost() > playerInv.Gold)
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("You can not afford that item!");
                Utility.WaitForEnterKey();
                return;
            }

            if (!playerInv.AddItem(itemToBuy))
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("You do not have room for that item!");
                Utility.WaitForEnterKey();
                return;
            }

            playerInv.Gold = playerInv.Gold - itemToBuy.GetCost();
            storeInv.Gold = storeInv.Gold + itemToBuy.GetCost();

            storeInv.RemoveItem(itemName);
        }

        static void DoSell(string playerName, Inventory playerInv, Inventory storeInv)
        {
            string itemName = "";

            do
            {
                Console.Clear();
                ShowInventories(playerName, playerInv, storeInv);
                Console.SetCursorPosition(5, 18);
                Console.Write("What would you like to sell? (Type the item name): __________\b\b\b\b\b\b\b\b\b\b");
                itemName = Console.ReadLine();

            } while (itemName.Length == 0);

            Item itemToSell = playerInv.GetItem(itemName);

            if (itemToSell == null)
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("You do not have that item!");
                Utility.WaitForEnterKey();
                return;
            }

            if (itemToSell.GetCost() > storeInv.Gold)
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("The Store can not afford to buy that item!");
                Utility.WaitForEnterKey();
                return;
            }

            if (!storeInv.AddItem(itemToSell))
            {
                Console.SetCursorPosition(5, 20);
                Console.Write("The Store does not have room for that item!");
                Utility.WaitForEnterKey();
                return;
            }

            storeInv.Gold = storeInv.Gold - itemToSell.GetCost();
            playerInv.Gold = playerInv.Gold + itemToSell.GetCost();

            playerInv.RemoveItem(itemName);
        }
#endif // INVENTORY
    }
}
