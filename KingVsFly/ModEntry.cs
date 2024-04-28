using EntityComponent;
using HarmonyLib;
using JumpKing;
using JumpKing.Mods;
using JumpKing.PauseMenu;
using JumpKing.PauseMenu.BT;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.Player;
using JumpKing.SaveThread;
using KingVsFly.Entities;
using KingVsFly.Nodes;
using KingVsFly.Patching;
using LanguageJK;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

// Patching with Harmony was a crashfest for some reason,
// so for now its "workarounds".

namespace KingVsFly
{
    [JumpKingMod("Zebra.KingVsFly")]
    public static class ModEntry
    {
        public static bool isEnabled;
        public static bool isCheckpoint;

        public static EntityCheckpoint entityCheckpoint;
        public static EntityFly entityFly;
        public static EntitySnake entitySnake;

        public static Harmony harmony;
        public static GameLoopDraw gameLoopDraw;

        public static StoryEventFlags flag;

        // DO NOT REMOVE object and GuiFormat even if they are unused!
        [MainMenuItemSetting]
        public static TextInfo AddMainBabeStats(object factory, GuiFormat format)
        {
            int record = ModSaves.Instance.mainBabeRecord;
            if (record == -1)
            {
                return new TextInfo($"{language.GAMETITLESCREEN_NEW_GAME}: -", Color.Gray);
            }
            return new TextInfo($"{language.GAMETITLESCREEN_NEW_GAME}: " + record, Color.Gray);
        }

        [MainMenuItemSetting]
        public static TextInfo AddNewBabeStats(object factory, GuiFormat format)
        {
            int record = ModSaves.Instance.newBabeRecord;
            if (record == -1)
            {
                return new TextInfo($"{language.GAMETITLESCREEN_NEW_BABE_PLUS}: -", Color.Gray);
            }
            return new TextInfo($"{language.GAMETITLESCREEN_NEW_BABE_PLUS}: " + record, Color.Gray);
        }

        [MainMenuItemSetting]
        public static TextInfo AddGhostBabeStats(object factory, GuiFormat format)
        {
            int record = ModSaves.Instance.ghostBabeRecord;
            if (record == -1)
            {
                return new TextInfo($"{language.GAMETITLESCREEN_GHOST_OF_THE_BABE}: -", Color.Gray);
            }
            return new TextInfo($"{language.GAMETITLESCREEN_GHOST_OF_THE_BABE}: " + record, Color.Gray);
        }

        [MainMenuItemSetting]
        public static ITextToggle AddToggleEnabled(object factory, GuiFormat format)
        {
            return new NodeToggleEnabled(isEnabled);
        }

        [MainMenuItemSetting]
        public static ITextToggle AddToggleCheckpoint(object factory, GuiFormat format)
        {
            return new NodeToggleCheckpoint(isCheckpoint);
        }

        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            // Debugger.Launch();
            isEnabled = false;
            isCheckpoint = true;

            harmony = new Harmony("Zebra.KingVsFly");
            gameLoopDraw = new GameLoopDraw(harmony);
        }

        /// <summary>
        /// Called by Jump King when the Level Starts
        /// </summary>
        [OnLevelStart]
        public static void OnLevelStart()
        {
            if (!isEnabled)
            {
                return;
            }
            if (Game1.instance.contentManager.root != "Content")
            {
                return;
            }

            EntityManager entityManager = EntityManager.instance;

            PlayerEntity entityPlayer = entityManager.Find<PlayerEntity>();
            if (entityPlayer == null)
            {
                return;
            }

            List<Entity> toRemoveEntities = new List<Entity>();
            foreach (var entity in entityManager.Entities)
            {
                // Removing npc and worlditem entities to give the feel of "After the events of Jump King".
                // Whatever that is supposed to mean :)
                string type = entity.GetType().ToString();
                if (type.Contains("MultiEnding")
                    || type.Contains("RavenEntity")
                    || type.Contains("OldManEntity")
                    || type.Contains("MerchantEntity")
                    || type.Contains("WorldItem")
                    || type.Contains("Achievement")
                    || type.Contains("RattmanEntity"))
                {
                    toRemoveEntities.Add(entity);
                }
            }
            foreach (var entity in toRemoveEntities)
            {
                entityManager.RemoveObject(entity);
            }

            entityFly = new EntityFly(entityPlayer);
            if (isCheckpoint)
            {
                entityCheckpoint = new EntityCheckpoint(entityPlayer);

                entityFly.entityCheckpoint = entityCheckpoint;
                entityCheckpoint.entityFly = entityFly;

                entityManager.AddObject(entityCheckpoint);
            }
            entityManager.AddObject(entityFly);

            if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedNBP))
            {
                flag = StoryEventFlags.StartedNBP;
            }
            else if (EventFlagsSave.ContainsFlag(StoryEventFlags.StartedGhost))
            {
                flag = StoryEventFlags.StartedGhost;
            }

            if (flag == StoryEventFlags.StartedNBP)
            {
                entitySnake = new EntitySnake();
                entityManager.AddObject(entitySnake);
            }
        }

        /// <summary>
        /// Called by Jump King when the Level Ends
        /// </summary>
        [OnLevelEnd]
        public static void OnLevelEnd()
        {
            if (!isEnabled)
            {
                return;
            }

            EntityManager entityManager = EntityManager.instance;

            entityManager.RemoveObject(entityFly);
            entityManager.RemoveObject(entityCheckpoint);
            entityManager.RemoveObject(entitySnake);

            entityFly = null;
            entityCheckpoint = null;
            entitySnake = null;

            SaveManager.instance?.StopSaving();
            SaveManager.instance?.AddTaskDeleteSaveFile();
        }
    }
}
