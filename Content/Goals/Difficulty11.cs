﻿using BingoBoardCore.Common;
using System.Collections.Generic;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using BingoBoardCore.AnimationHelpers;
using BingoBoardCore.Common.Systems;

namespace BingoGoalPackBingoSyncGoals.Content.Goals {
    public class RockBottom : Goal {
        public override Item icon => Icons.Achievement.RockBottom;
        public override int difficultyTier => 11;
    }

    public class HelpStylist : Goal {
        public override Item icon => Icons.Npc.Stylist;
        public override int difficultyTier => 11;
        public override bool enable(
            BingoMode mode, int numPlayers, bool isSharedWorld
        ) => !isSharedWorld || mode == BingoMode.Lockout;
    }

    public class IntoOrbit : Goal {
        public override Item icon => Icons.Achievement.IntoOrbit;
        public override int difficultyTier => 11;
    }

    public class DownKSSpace : Goal {
        public override Item icon => new(ItemID.KingSlimeTrophy);
        public override int difficultyTier => 11;
        public override Item? modifierIcon => Icons.Bestiary.Island;
        public override IList<string> synergyTypes => new[] {"ME.3.1"};
    }

    public class See3BlazingWheels : Goal {
        public override Item icon => Icons.Npc.BlazingWheel;
        public override int difficultyTier => 11;
        public override string modifierText => "3";
    }

    public class TraverseWholeWorld : Goal {
        public override Item icon => ModContent.GetInstance<Icons.Map>().Item;
        public override int difficultyTier => 11;
    }

    public class FindTemple : Goal {
        public override Item icon => Icons.Bestiary.Temple;
        public override int difficultyTier => 11;
    }

    public class Get5GemStaves : Goal {
        public override Item icon => IconAnimationSystem.registerRandAnimation(Sets.GemStaves);
        public override int difficultyTier => 11;
        public override string modifierText => "5";
    }
}