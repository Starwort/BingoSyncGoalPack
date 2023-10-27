using BingoGoalPackBingoSyncGoals.Icons;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BingoBoardCore.Common.Systems;
using Terraria.GameContent;
using System;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class RegisterGoals : ModSystem {
        static Item die => BingoBoardCore.BingoBoardCore.dieIcon;
        static Item disallow => BingoBoardCore.BingoBoardCore.disallowIcon;
        static readonly Item craft = new(ItemID.WorkBench);

        Item tileGoalsIcon = new(ItemID.DirtBlock);
        int[] tiles = new int[] {ItemID.DirtBlock};
        Item spearGoalIcon = new(ItemID.Spear);
        int[] spears = new int[] {ItemID.Spear};
        Item accessoryGoalsIcon = new(ItemID.Shackle);
        int[] accessories = new int[] {ItemID.Shackle};
        Item woodToolsGoalIcon = new(ItemID.WoodenSword);
        int[] woodTools = new int[] {ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer};
        Item campfiresGoalIcon = new(ItemID.Campfire);
        int[] campfires = new int[] {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };
        Item questGoalsIcon = new(ItemID.AmanitaFungifin);
        int[] questFish = new int[] {
            ItemID.AmanitaFungifin, ItemID.Angelfish, ItemID.Batfish,
            ItemID.BloodyManowar, ItemID.Bonefish, ItemID.BumblebeeTuna,
            ItemID.Bunnyfish, ItemID.CapnTunabeard, ItemID.Catfish,
            ItemID.Cloudfish, ItemID.Clownfish, ItemID.Cursedfish,
            ItemID.DemonicHellfish, ItemID.Derpfish, ItemID.Dirtfish,
            ItemID.DynamiteFish, ItemID.EaterofPlankton, ItemID.FallenStarfish,
            ItemID.TheFishofCthulu, ItemID.Fishotron, ItemID.Fishron,
            ItemID.GuideVoodooFish, ItemID.Harpyfish, ItemID.Hungerfish,
            ItemID.Ichorfish, ItemID.InfectedScabbardfish, ItemID.Jewelfish,
            ItemID.MirageFish, ItemID.Mudfish, ItemID.MutantFlinxfin,
            ItemID.Pengfish, ItemID.Pixiefish, ItemID.ScarabFish,
            ItemID.ScorpioFish, ItemID.Slimefish, ItemID.Spiderfish,
            ItemID.TropicalBarracuda, ItemID.TundraTrout, ItemID.UnicornFish,
            ItemID.Wyverntail, ItemID.ZombieFish
        };
        Item herbsGoalIcon = new(ItemID.Daybloom);
        int[] herbs = new int[] {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };
        private AnimatedIcon[] animations = Array.Empty<AnimatedIcon>();
        internal void loadItemAnimations() {
            tiles = ContentSamples.ItemsByType.Where(val => val.Value.createTile != -1).Select(val => val.Key).ToArray();
            tileGoalsIcon.type = tiles[0];
            spears = ItemID.Sets.Spears.Select((isSpear, id) => new { isSpear, id }).Where(val => val.isSpear).Select(val => val.id).ToArray();
            spearGoalIcon.type = spears[0];
            accessories = ContentSamples.ItemsByType.Where(val => val.Value.accessory).Select(val => val.Key).ToArray();
            accessoryGoalsIcon.type = accessories[0];
            animations = new AnimatedIcon[] {ModContent.GetInstance<AnyBuff>(), ModContent.GetInstance<AnyDebuff>()};
        }

        private Random rng = new();

        public override void PreUpdateItems() {
            if (Main.GameUpdateCount % animationPeriod == 0) {
                var frame = Main.GameUpdateCount / animationPeriod;
                tileGoalsIcon.type = tiles[rng.Next(tiles.Length)];
                spearGoalIcon.type = spears[frame % spears.Length];
                accessoryGoalsIcon.type = tiles[rng.Next(accessories.Length)];
                woodToolsGoalIcon.type = woodTools[frame % woodTools.Length];
                campfiresGoalIcon.type = campfires[frame % campfires.Length];
                questGoalsIcon.type = questFish[frame % questFish.Length];
                herbsGoalIcon.type = herbs[frame % herbs.Length];
                foreach (var animation in animations) {
                    animation.animate(frame);
                }
            }
        }

        internal void registerGoals() {
            register(
                "DownEoC",
                difficulty: 0,
                new Item(ItemID.EyeofCthulhuTrophy),
                new[] {"ME.5.1", "ME.5.2"}
            );
            register(
                "DownKS",
                difficulty: 0,
                new Item(ItemID.KingSlimeTrophy),
                new[] {"ME.3.1", "ME.3.2"}
            );
            register(
                "PutFoodOnPlate",
                difficulty: 0,
                new Item(ItemID.FoodPlatter)
            );
            register(
                "Get999OfTile",
                difficulty: 0,
                tileGoalsIcon,
                text: "999"
            );
            register(
                "FillPiggyBank",
                difficulty: 0,
                new Item(ItemID.PiggyBank)
            );
            register(
                "EatCookedFish",
                difficulty: 0,
                new Item(ItemID.CookedFish)
            );
            register(
                "Suffocate7s",
                difficulty: 0,
                ModContent.GetInstance<Suffocation>().Item,
                text: "7s"
            );
            register(
                "DieToThorns",
                difficulty: 0,
                ModContent.GetInstance<Thorns>().Item,
                modifier: die
            );

            register(
                "Get2Spears",
                difficulty: 1,
                spearGoalIcon,
                text: "2"
            );
            register(
                "Get2Plat",
                difficulty: 1,
                new Item(ItemID.PlatinumCoin),
                text: "2"
            );
            register(
                "DieToAltar",
                difficulty: 1,
                ModContent.GetInstance<Altars>().Item,
                modifier: die
            );
            register(
                "Equip5Accessories",
                difficulty: 1,
                accessoryGoalsIcon,
                text: "5",
                synergyTypes: new[] {"ME.15"}
            );
            register(
                "GetModifiedWoodSwordBowHammer",
                difficulty: 1,
                woodToolsGoalIcon,
                modifier: craft
            );
            register(
                "ExplodeVillagerEnemySelf",
                difficulty: 1,
                new Item(ItemID.ExplosiveBunny),
                modifier: die,
                text: "3"
            );
            register(
                "GetCookedMarshmallow",
                difficulty: 1,
                new Item(ItemID.CookedMarshmallow)
            );
            register(
                "NoChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: (mode, _) => mode != BingoMode.Lockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "OpponentChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: (mode, teams) => mode == BingoMode.Lockout && teams == 2,
                synergyTypes: new[] {"ME.1"}
            );

            register(
                "CompleteFishingQuest",
                difficulty: 2,
                questGoalsIcon,
                text: "1",
                synergyTypes: new[] {"ME.11"}
            );
            register(
                "Get3FrogLegs",
                difficulty: 2,
                new Item(ItemID.SauteedFrogLegs),
                text: "3"
            );
            register(
                "GetRockLobster",
                difficulty: 2,
                new Item(ItemID.RockLobster)
            );
            register(
                "PlaceAllSandcastles",
                difficulty: 2,
                new Item(ItemID.SandcastleBucket),
                text: "4"
            );
            register(
                "PlantAllHerbs",
                difficulty: 2,
                herbsGoalIcon,
                text: "7",
                modifier: new Item(ItemID.ClayPot)
            );
            register(
                "InvFullOfBlocks",
                difficulty: 2,
                tileGoalsIcon
            );
            register(
                "Have12Buffs",
                difficulty: 2,
                ModContent.GetInstance<AnyBuff>().Item,
                text: "12"
            );
        }

        public override void PostSetupContent() {
            loadItemAnimations();
            registerGoals();
        }
    }
}
