using BingoBoardCore.AnimationHelpers;
using BingoSyncGoalPack.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.Icons {
    internal class Npc : ModItem {
        private class AnyTownNPC : AssetCycleAnimation {
            private static Random rng = new();
            private DrawAnimationVariantVertical anim = new(1, 0, 6, 1);

            public AnyTownNPC() {
                Npc.AnyTown = this.Item;
            }

            public override void SetStaticDefaults() {
                Main.RegisterItemAnimation(Type, anim);
            }

            public override Asset<Texture2D> getFrame(uint frame) {
                var idx = Sets.TownNPCs[rng.Next(Sets.TownNPCs.Count)];
                anim.sheetFrameCount = Main.npcFrameCount[idx];
                anim.FrameCount = Main.npcFrameCount[idx] - NPCID.Sets.AttackFrameCount[idx];
                anim.FrameCounter = 0;
                return TextureAssets.Npc[idx];
            }
        }
        public override string Texture => $"Terraria/Images/NPC_{npcId}";
        int npcId;
        int npcFrameTime;
        int skipStartFrames;

        public override string Name => $"NPCIcon/{npcId}";

        public static Item AnyTown = null!;

        public static Item Angler = null!;
        public static Item Clothier = null!;
        public static Item Dog = null!;
        public static Item Golfer = null!;
        public static Item Stylist = null!;
        public static Item BlazingWheel = null!;
        public static Item DungeonGuardian = null!;
        public static Item MaggotZombie = null!;
        public static Item Ghost = null!;
        public static Item Raven = null!;

        public Npc() {
            this.npcId = NPCID.None;
        }

        public Npc(int npcId, int npcFrameTime = 6, int skipStartFrames = 0) {
            this.npcId = npcId;
            this.npcFrameTime = npcFrameTime;
            this.skipStartFrames = skipStartFrames;
        }

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVariantVertical(
                Main.npcFrameCount[npcId],
                skipStartFrames,
                npcFrameTime,
                Main.npcFrameCount[npcId] - NPCID.Sets.AttackFrameCount[npcId] - skipStartFrames
            ));
        }

        public override bool IsLoadingEnabled(Mod mod) => npcId != NPCID.None;

        public static void registerItems() {
            Item add(int id, int frameTime = 6, int skipStartFrames = 0) {
                Npc icon = new(id, frameTime, skipStartFrames);
                ModContent.GetInstance<BingoSyncGoalPack>().AddContent(
                    icon
                );
                return icon.Item;
            }
            Angler = add(NPCID.Angler);
            Clothier = add(NPCID.Clothier);
            Dog = add(NPCID.TownDog);
            Golfer = add(NPCID.Golfer);
            Stylist = add(NPCID.Stylist);
            BlazingWheel = add(NPCID.BlazingWheel, 3);
            DungeonGuardian = add(NPCID.DungeonGuardian);
            MaggotZombie = add(NPCID.MaggotZombie, 4);
            Ghost = add(NPCID.Ghost);
            Raven = add(NPCID.Raven, 4, 1);
        }
    }
}
