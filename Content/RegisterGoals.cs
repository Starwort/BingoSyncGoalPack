using BingoGoalPackBingoSyncGoals.Icons;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.AnimationHelpers;
using System;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class RegisterGoals : ModSystem {
        static Item die => BingoBoardCore.BingoBoardCore.dieIcon;
        static Item disallow => BingoBoardCore.BingoBoardCore.disallowIcon;
        static readonly Item craft = new(ItemID.WorkBench);

        // Item sets
        internal static int[] tiles = new int[] {ItemID.DirtBlock};
        internal static int[] spears = new int[] {ItemID.Spear};
        internal static int[] accessories = new int[] {ItemID.Shackle};
        internal static int[] questFish = new int[] {ItemID.AmanitaFungifin};
        internal static int[] critterContainers = new int[] {ItemID.BunnyCage};
        internal static int[] summonStaves = new int[] {ItemID.SlimeStaff};
        internal static int[] hooks = new int[] {ItemID.GrapplingHook};

        internal static int[] phmCampfires = new int[] {
            ItemID.Campfire, ItemID.CoralCampfire, ItemID.CorruptCampfire,
            ItemID.CrimsonCampfire, ItemID.DemonCampfire, ItemID.DesertCampfire,
            ItemID.FrozenCampfire, ItemID.JungleCampfire, ItemID.MushroomCampfire
        };

        internal static int[] herbs = new int[] {
            ItemID.Blinkroot, ItemID.Daybloom, ItemID.Deathweed,
            ItemID.Fireblossom, ItemID.Moonglow, ItemID.Shiverthorn,
            ItemID.Waterleaf
        };

        internal static int[] lowTierBars = new int[] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
        };

        internal static int[] bars = new int[23] {
            // Tier 1
            ItemID.CopperBar, ItemID.TinBar,
            // Tier 2
            ItemID.IronBar, ItemID.LeadBar,
            // Tier 3
            ItemID.SilverBar, ItemID.TungstenBar,
            // Tier 4
            ItemID.GoldBar, ItemID.PlatinumBar,
            // Tier 5
            ItemID.MeteoriteBar,
            // Tier 6
            ItemID.DemoniteBar, ItemID.CrimtaneBar,
            // Tier 7
            ItemID.HellstoneBar,
            // Tier 8
            ItemID.CobaltBar, ItemID.PalladiumBar,
            // Tier 9
            ItemID.MythrilBar, ItemID.OrichalcumBar,
            // Tier 10
            ItemID.AdamantiteBar, ItemID.TitaniumBar,
            // Tier 11
            ItemID.HallowedBar,
            // Tier 12
            ItemID.ChlorophyteBar,
            // Tier 13
            ItemID.ShroomiteBar, ItemID.SpectreBar,
            // Tier 14
            ItemID.LunarBar,
        };

        internal static int[] grassSeeds = new int[] {
            ItemID.GrassSeeds,
            ItemID.AshGrassSeeds,
            ItemID.JungleGrassSeeds,
            ItemID.MushroomGrassSeeds,
            ItemID.CorruptSeeds,
            ItemID.CrimsonSeeds,
            ItemID.HallowedSeeds
        };

        internal static int[] gemCritterCages = new int[] {
            ItemID.AmberBunnyCage,
            ItemID.AmberSquirrelCage,
            ItemID.AmethystBunnyCage,
            ItemID.AmethystSquirrelCage,
            ItemID.DiamondBunnyCage,
            ItemID.DiamondSquirrelCage,
            ItemID.EmeraldBunnyCage,
            ItemID.EmeraldSquirrelCage,
            ItemID.RubyBunnyCage,
            ItemID.RubySquirrelCage,
            ItemID.SapphireBunnyCage,
            ItemID.SapphireSquirrelCage,
            ItemID.TopazBunnyCage,
            ItemID.TopazSquirrelCage,
        };

        internal static int[] arrows = new int[] {
            ItemID.WoodenArrow,
            ItemID.FlamingArrow,
            ItemID.UnholyArrow,
            ItemID.JestersArrow,
            ItemID.HellfireArrow,
            ItemID.HolyArrow,
            ItemID.CursedArrow,
            ItemID.FrostburnArrow,
            ItemID.ChlorophyteArrow,
            ItemID.IchorArrow,
            ItemID.VenomArrow,
            ItemID.BoneArrow,
            ItemID.MoonlordArrow,
            ItemID.ShimmerArrow,
        };

        internal static bool appearsToBeCritterContainer(Recipe recipe) {
            var ingredients = recipe.requiredItem;
            if (ingredients.Count != 2) {
                return false;
            }
            Item? critter = null;
            if (
                ingredients[0].type != ItemID.Terrarium
                && ingredients[0].type != ItemID.Bottle
            ) {
                critter = ingredients[0];
            }
            if (
                ingredients[1].type != ItemID.Terrarium
                && ingredients[1].type != ItemID.Bottle
            ) {
                if (critter is null) {
                    critter = ingredients[1];
                } else {
                    return false;
                }
            }
            return critter is not null && critter.makeNPC > 0;
        }

        internal void loadItemSets() {
            tiles = (
                from val in ContentSamples.ItemsByType
                where val.Value.createTile != -1
                select val.Key
            ).ToArray();
            // It seems that this is inexpressible with linq
            spears = (
                ItemID.Sets.Spears
                .Select((isSpear, id) => new {isSpear, id})
                .Where(val => val.isSpear)
                .Select(val => val.id)
            ).ToArray();
            accessories = (
                from val in ContentSamples.ItemsByType
                where val.Value.accessory
                select val.Key
            ).ToArray();
            questFish = (
                from val in ContentSamples.ItemsByType
                where val.Value.questItem
                select val.Key
            ).ToArray();
            critterContainers = (
                from recipe in Main.recipe
                where appearsToBeCritterContainer(recipe)
                select recipe.createItem.type
            ).ToArray();
            summonStaves = (
                from val in ContentSamples.ItemsByType
                where Item.staff[val.Key]
                    && val.Value.CountsAsClass(DamageClass.Summon)
                select val.Key
            ).ToArray();
            hooks = (
                from val in ContentSamples.ItemsByType
                where Main.projHook[val.Value.shoot]
                select val.Key
            ).ToArray();
        }

        internal void registerGoals() {
            var tileIcon = IconAnimationSystem.registerRandAnimation(tiles);
            var accessoryIcon = IconAnimationSystem.registerRandAnimation(accessories);
            var evilBossIcon = IconAnimationSystem.registerCycleAnimation(ItemID.BrainofCthulhuTrophy, ItemID.EaterofWorldsTrophy);
            var questFishIcon = IconAnimationSystem.registerRandAnimation(questFish);

            #region Difficulty 0 goals
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
                tileIcon,
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
            #endregion

            #region Difficulty 1 goals
            register(
                "Get2Spears",
                difficulty: 1,
                IconAnimationSystem.registerRandAnimation(spears),
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
                accessoryIcon,
                text: "5",
                synergyTypes: new[] {"ME.15"}
            );
            register(
                "GetModifiedWoodSwordBowHammer",
                difficulty: 1,
                IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer),
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
            #endregion

            #region Difficulty 2 goals
            register(
                "CompleteFishingQuest",
                difficulty: 2,
                questFishIcon,
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
                IconAnimationSystem.registerRandAnimation(herbs),
                text: "7",
                modifier: new Item(ItemID.ClayPot)
            );
            register(
                "InvFullOfBlocks",
                difficulty: 2,
                tileIcon
            );
            register(
                "Have12Buffs",
                difficulty: 2,
                ModContent.GetInstance<AnyBuff>().Item,
                text: "12"
            );
            #endregion

            #region Difficulty 3 goals
            register(
                "KillAnglerWithBoulder",
                difficulty: 3,
                ModContent.GetInstance<Angler>().Item,
                modifier: new Item(ItemID.Boulder)
            );
            register(
                "Stack4BarsOnDungeon",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(lowTierBars),
                modifier: IconAnimationSystem.registerCycleAnimation(ItemID.BlueBrick, ItemID.GreenBrick, ItemID.PinkBrick),
                text: "4"
            );
            register(
                "DrownWithBreathingReed",
                difficulty: 3,
                new Item(ItemID.BreathingReed),
                modifier: die
            );
            register(
                "WearCactusArmour",
                difficulty: 3,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CactusHelmet,
                    ItemID.CactusBreastplate,
                    ItemID.CactusLeggings
                )
            );
            ;
            register(
                "GrowGemTree",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(
                    ItemID.GemTreeAmberSeed,
                    ItemID.GemTreeAmethystSeed,
                    ItemID.GemTreeDiamondSeed,
                    ItemID.GemTreeEmeraldSeed,
                    ItemID.GemTreeRubySeed,
                    ItemID.GemTreeSapphireSeed,
                    ItemID.GemTreeTopazSeed
                )
            );
            register(
                "TrashSharkBait",
                difficulty: 3,
                new Item(ItemID.SharkBait),
                modifier: new Item(ItemID.TrashCan)
            );
            register(
                "FillHouseWithBars",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(bars),
                modifier: ModContent.GetInstance<House>().Item
            );
            register(
                "GetAllCampfires",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(phmCampfires),
                text: "9"
            );
            #endregion

            #region Difficulty 4 goals
            register(
                "DownEvilBoss",
                difficulty: 4,
                evilBossIcon,
                synergyTypes: new[] {"ME.4.1", "ME.4.2"}
            );
            register(
                "WearEvilArmour",
                difficulty: 4,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimsonHelmet,
                    ItemID.CrimsonScalemail,
                    ItemID.CrimsonGreaves,
                    ItemID.ShadowHelmet,
                    ItemID.ShadowScalemail,
                    ItemID.ShadowGreaves
                ),
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "KillEvilCritter",
                difficulty: 4,
                ModContent.GetInstance<EvilCritter>().Item,
                modifier: new(ItemID.CopperShortsword)
            );
            register(
                "Sell100Hellstone",
                difficulty: 4,
                new Item(ItemID.Hellstone),
                modifier: new(ItemID.DiscountCard),
                text: "100"
            );
            register(
                "SellFlamingMace",
                difficulty: 4,
                new Item(ItemID.FlamingMace),
                modifier: new(ItemID.DiscountCard)
            );
            #endregion

            #region Difficulty 5 goals
            register(
                "BreakLivingTreeLeaves",
                difficulty: 5,
                ModContent.GetInstance<LivingLeaf>().Item,
                modifier: new(ItemID.CopperPickaxe)
            );
            register(
                "EatGrubSoup",
                difficulty: 5,
                new Item(ItemID.GrubSoup)
            );
            register(
                "Get4CritterContainers",
                difficulty: 5,
                IconAnimationSystem.registerRandAnimation(critterContainers),
                text: "4"
            );
            register(
                "GetLemonadeOrAppleJuice",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(ItemID.Lemonade, ItemID.AppleJuice),
                modifier: craft
            );
            register(
                "WearVanityWinnerSet",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PlaguebringerHelmet,
                    ItemID.PlaguebringerChestplate,
                    ItemID.PlaguebringerGreaves,
                    ItemID.RoninHat,
                    ItemID.RoninShirt,
                    ItemID.RoninPants,
                    ItemID.TimelessTravelerHood,
                    ItemID.TimelessTravelerRobe,
                    ItemID.TimelessTravelerBottom,
                    ItemID.FloretProtectorHelmet,
                    ItemID.FloretProtectorChestplate,
                    ItemID.FloretProtectorLegs,
                    ItemID.CapricornMask,
                    ItemID.CapricornChestplate,
                    ItemID.CapricornLegs,
                    ItemID.CapricornTail,
                    ItemID.TVHeadMask,
                    ItemID.TVHeadSuit,
                    ItemID.TVHeadPants
                )
            );
            register(
                "Get4Shrooms",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.GlowingMushroom,
                    ItemID.GreenMushroom,
                    ItemID.Mushroom,
                    ItemID.StrangeGlowingMushroom,
                    ItemID.TealMushroom,
                    ItemID.ViciousMushroom,
                    ItemID.VileMushroom
                ),
                text: "4"
            );
            register(
                "Get3Watches",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CopperWatch,
                    ItemID.TinWatch,
                    ItemID.SilverWatch,
                    ItemID.TungstenWatch,
                    ItemID.GoldWatch,
                    ItemID.PlatinumWatch
                ),
                text: "3"
            );
            register(
                "GetTrash",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FishingSeaweed,
                    ItemID.OldShoe,
                    ItemID.TinCan
                ),
                text: "3"
            );
            #endregion

            #region Difficulty 6 goals
            register(
                "MakePotions.Magic",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MagicPowerPotion,
                    ItemID.ManaRegenerationPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Explore",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MiningPotion,
                    ItemID.ShinePotion,
                    ItemID.NightOwlPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Water",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WaterWalkingPotion,
                    ItemID.FlipperPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Trans",
                difficulty: 6,
                new Item(ItemID.GenderChangePotion),
                modifier: craft
            );
            register( // TODO find/make better icons for these
                "FindBiome.SurfaceMushroom",
                difficulty: 6,
                new Item(ItemID.DarkBlueSolution)
            );
            register(
                "FindBiome.EvilOcean",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PurpleSolution,
                    ItemID.RedSolution
                ),
                modifier: new(ItemID.TreasureMap)
            );
            register(
                "FindBiome.EvilDesert",
                difficulty: 6,
                IconAnimationSystem.registerRandAnimation(
                    ItemID.EbonsandBlock,
                    ItemID.CorruptSandstone,
                    ItemID.CorruptHardenedSand,
                    ItemID.CrimsandBlock,
                    ItemID.CrimsonSandstone,
                    ItemID.CrimsonHardenedSand
                )
            );
            register(
                "MakePotions.Titan",
                difficulty: 6,
                new Item(ItemID.TitanPotion),
                modifier: craft
            );
            #endregion

            #region Difficulty 7 goals
            register(
                "DeadMenTellNoTales",
                difficulty: 7,
                new Item(ItemID.DeadMansChest),
                modifier: die,
                synergyTypes: new[] {"ME.9"}
            );
            register(
                "Get5WoodArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WoodHelmet,
                    ItemID.WoodBreastplate,
                    ItemID.WoodGreaves,
                    ItemID.RichMahoganyHelmet,
                    ItemID.RichMahoganyBreastplate,
                    ItemID.RichMahoganyGreaves,
                    ItemID.EbonwoodHelmet,
                    ItemID.EbonwoodBreastplate,
                    ItemID.EbonwoodGreaves,
                    ItemID.ShadewoodHelmet,
                    ItemID.ShadewoodBreastplate,
                    ItemID.ShadewoodGreaves,
                    ItemID.PearlwoodHelmet,
                    ItemID.PearlwoodBreastplate,
                    ItemID.PearlwoodGreaves,
                    ItemID.BorealWoodHelmet,
                    ItemID.BorealWoodBreastplate,
                    ItemID.BorealWoodGreaves,
                    ItemID.PalmWoodHelmet,
                    ItemID.PalmWoodBreastplate,
                    ItemID.PalmWoodGreaves,
                    ItemID.AshWoodHelmet,
                    ItemID.AshWoodBreastplate,
                    ItemID.AshWoodGreaves,
                    ItemID.SpookyHelmet,
                    ItemID.SpookyBreastplate,
                    ItemID.SpookyLeggings
                ),
                text: "5",
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "WearPumpkinArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PumpkinHelmet,
                    ItemID.PumpkinBreastplate,
                    ItemID.PumpkinLeggings
                )
            );
            register(
                "WearFossilArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FossilHelm,
                    ItemID.FossilShirt,
                    ItemID.FossilPants
                )
            );
            register(
                "GetSummons",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(summonStaves),
                text: "7"
            );
            register(
                "Get100Gel",
                difficulty: 7,
                new Item(ItemID.Gel),
                text: "100"
            );
            register(
                "StackHighTierBars",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimtaneBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar,
                    ItemID.DemoniteBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar
                ),
                modifier: new(ItemID.SnowBlock)
            );
            register(
                "Get4GrassSeeds",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(grassSeeds),
                text: "4"
            );
            #endregion

            #region Difficulty 8 goals
            register(
                "GetGemCritterCage",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(gemCritterCages)
            );
            register(
                "Get99Seeds",
                difficulty: 8,
                new Item(ItemID.Seed),
                text: "99"
            );
            register(
                "HelpGolfer",
                difficulty: 8,
                ModContent.GetInstance<Golfer>().Item,
                shouldEnable: (mode, _) => mode == BingoMode.Lockout
            );
            register(
                "Get6Arrows",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(arrows),
                text: "6"
            );
            register(
                "GetSilverBullets",
                difficulty: 8,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.SilverBullet,
                    ItemID.TungstenBullet
                )
            );
            register(
                "Get8Hooks",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(hooks),
                text: "8"
            );
            register(
                "Have5Debuffs",
                difficulty: 8,
                ModContent.GetInstance<AnyDebuff>().Item,
                text: "5"
            );
            #endregion

            #region Difficulty 9 goals
            #endregion

            #region Difficulty 10 goals
            #endregion

            #region Difficulty 11 goals
            #endregion

            #region Difficulty 12 goals
            #endregion

            #region Difficulty 13 goals
            #endregion

            #region Difficulty 14 goals
            #endregion

            #region Difficulty 15 goals
            #endregion

            #region Difficulty 16 goals
            #endregion

            #region Difficulty 17 goals
            #endregion

            #region Difficulty 18 goals
            #endregion

            #region Difficulty 19 goals
            #endregion

            #region Difficulty 20 goals
            #endregion

            #region Difficulty 21 goals
            #endregion

            #region Difficulty 22 goals
            #endregion

            #region Difficulty 23 goals
            #endregion

            #region Difficulty 24 goals
            #endregion
        }

        public override void PostSetupContent() {
            loadItemSets();
            registerGoals();
        }
    }
}
