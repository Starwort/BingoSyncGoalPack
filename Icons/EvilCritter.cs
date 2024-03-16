using BingoBoardCore.AnimationHelpers;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace BingoSyncGoalPack.Icons {
    internal class EvilCritter : AssetCycleAnimation {
        DrawAnimationVariantVertical animation = new(7, 1, 6, 6);

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, animation);
        }

        (
            short npcId,
            int sheetFrameCount,
            int variantFrameStart,
            int variantFrameCount,
            int variantFrameDuration
        )[] parameters = new[] {
            (NPCID.CorruptBunny, 7, 1, 6, 6),
            (NPCID.CrimsonBunny, 7, 1, 6, 6),
            (NPCID.CrimsonGoldfish, 6, 0, 4, 6),
            (NPCID.CrimsonGoldfish, 6, 4, 2, 6),
            (NPCID.CorruptGoldfish, 6, 0, 4, 6),
            (NPCID.CorruptGoldfish, 6, 4, 2, 6),
            (NPCID.CorruptPenguin, 12, 0, 3, 6),
            (NPCID.CorruptPenguin, 12, 3, 3, 6),
            (NPCID.CorruptPenguin, 12, 6, 3, 6),
            (NPCID.CorruptPenguin, 12, 9, 3, 6),
            (NPCID.CrimsonPenguin, 12, 0, 3, 6),
            (NPCID.CrimsonPenguin, 12, 3, 3, 6),
            (NPCID.CrimsonPenguin, 12, 6, 3, 6),
            (NPCID.CrimsonPenguin, 12, 9, 3, 6),
        };

        public override Asset<Texture2D> getFrame(uint frame) {
            var animParams = parameters[frame % parameters.Length];
            animation.variantStart = animParams.variantFrameStart;
            animation.sheetFrameCount = animParams.sheetFrameCount;
            animation.FrameCount = animParams.variantFrameCount;
            animation.FrameCounter = 0;
            animation.Frame = 0;
            animation.TicksPerFrame = animParams.variantFrameDuration;
            return TextureAssets.Npc[animParams.npcId];
        }
    }
}
