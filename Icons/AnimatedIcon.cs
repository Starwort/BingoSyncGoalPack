using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public abstract class AnimatedIcon : ModItem {
        public override string Texture => $"Terraria/Images/CoolDown";
        internal abstract Asset<Texture2D> getFrame(uint frame);
        internal void animate(uint frame) {
            TextureAssets.Item[Type] = getFrame(frame);
        }
    }
}
