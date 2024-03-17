using Terraria;
using Terraria.ModLoader;

namespace BingoSyncGoalPack.MonitorHooks {
    internal abstract class PlayerAttackTracker : ModPlayer {
        public override string Name => this.GetType().AssemblyQualifiedName ?? this.GetType().Name;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone) {
            processHitNPC(target, hit);
        }

        protected virtual void onHit(NPC target, NPC.HitInfo hit) {
        }

        protected virtual void onKill(NPC target, NPC.HitInfo hit) {
        }

        void processHitNPC(NPC target, NPC.HitInfo hit) {
            onHit(target, hit);
            if (target.life <= 0) {
                onKill(target, hit);
            }
        }
    }
    internal abstract class TrackerSystem : ModSystem {
        public override string Name => this.GetType().AssemblyQualifiedName ?? this.GetType().Name;
    }
    internal abstract class PlayerTracker : ModPlayer {
        public override string Name => this.GetType().AssemblyQualifiedName ?? this.GetType().Name;
    }
    internal abstract class ItemTracker : GlobalItem {
        public override string Name => this.GetType().AssemblyQualifiedName ?? this.GetType().Name;
    }
}
