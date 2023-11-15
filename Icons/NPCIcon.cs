using BingoBoardCore.AnimationHelpers;
using BingoGoalPackBingoSyncGoals.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class NPCIcon : ModItem {
        private class AnyTownNPC : AssetCycleAnimation {
            private static Random rng = new();

            public override Asset<Texture2D> getFrame(uint frame) {
                var idx = Sets.townNPCs[rng.Next(Sets.townNPCs.Count)];
                return TextureAssets.Npc[idx];
            }
        }
        public override string Texture => $"Terraria/Images/NPC_{npcId}";
        int npcId;
        int npcFrameTime;

        public override string Name => $"NPCIcon/{npcId}";

        public static Item anyTown = null!;

        public static Item angler = null!;
        public static Item golfer = null!;
        public static Item stylist = null!;
        public static Item blazingWheel = null!;
        public static Item dungeonGuardian = null!;

        public NPCIcon() {
            this.npcId = NPCID.None;
            anyTown = ModContent.GetInstance<AnyTownNPC>().Item;
        }

        public NPCIcon(int npcId, int npcFrameTime = 6) {
            this.npcId = npcId;
            this.npcFrameTime = npcFrameTime;
        }

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(npcFrameTime, Main.npcFrameCount[npcId]));
        }

        public override bool IsLoadingEnabled(Mod mod) => npcId != NPCID.None;

        public static void registerItems() {
            Item add(int id, int frameTime = 6) {
                NPCIcon icon = new(id, frameTime);
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            angler = add(NPCID.Angler);
            golfer = add(NPCID.Golfer);
            stylist = add(NPCID.Stylist);
            blazingWheel = add(NPCID.BlazingWheel, 3);
            dungeonGuardian = add(NPCID.DungeonGuardian);
        }
    }
}
