﻿namespace Application.SeedInitialData
{
    using Application.Common.Interfaces;
    using Domain.Entities.Common.Social;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using global::Domain.Entities.Common;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class DataSeeder
    {
        private readonly IFFDbContext context;

        public DataSeeder(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            await this.SeedUsersAsync(cancellationToken);

            await this.SeedPlayerSpellsAsync(cancellationToken);

            await this.SeedFigthingClassesAsync(cancellationToken);

            await this.SeedEnemySpellsAsync(cancellationToken);

            await this.SeedMonstersAsync(cancellationToken);

            await this.SeedMonsterRaritiesAsync(cancellationToken);

            await this.SeedStatusesAsync(cancellationToken);

            await this.SeedToolsAsync(cancellationToken);

            await this.SeedMainMaterialsAsync(cancellationToken);
        }

        private async Task SeedMainMaterialsAsync(CancellationToken cancellationToken)
        {
            // Main
            this.context.Materials.Add(new Material
            {
                Name = "Oak Log",
                Type = "Wood",
                ImageURL = "/images/Items/Oak-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Walnut Log",
                Type = "Wood",
                ImageURL = "/images/Items/Walnut-Log.png",
                IsRefineable = true,
                FuelCount = 2,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Birch Log",
                Type = "Wood",
                ImageURL = "/images/Items/Birch-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Mahogany Log",
                Type = "Wood",
                ImageURL = "/images/Items/Mahogany-Log.png",
                IsRefineable = true,
                FuelCount = 1,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Coal Ore",
                Type = "Ore",
                ImageURL = "/images/Items/Coal-Ore.png",
                FuelCount = 3,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Copper Ore",
                Type = "Ore",
                ImageURL = "/images/Items/Copper-Ore.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Iron Ore",
                Type = "Ore",
                ImageURL = "/images/Items/Iron-Ore.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Gold Ore",
                Type = "Ore",
                ImageURL = "/images/Items/Gold-Ore.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Leather Scraps",
                Type = "Leather",
                ImageURL = "/images/Items/Leather-Scraps.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Animal Fur",
                Type = "Leather",
                ImageURL = "/images/Items/Animal-Fur.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Light Leather",
                Type = "Leather",
                ImageURL = "/images/Items/Light-Leather.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Fine Leather",
                Type = "Leather",
                ImageURL = "/images/Items/Fine-Leather.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Cotton",
                Type = "Cloth",
                ImageURL = "/images/Items/Cotton.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Linen Cloth",
                Type = "Cloth",
                ImageURL = "/images/Items/Linen-Cloth.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Silk",
                Type = "Cloth",
                ImageURL = "/images/Items/Silk.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Mint",
                Type = "Herb",
                ImageURL = "/images/Items/Mint.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Coriander",
                Type = "Herb",
                ImageURL = "/images/Items/Coriander.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Lavender",
                Type = "Herb",
                ImageURL = "/images/Items/Lavender.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Buttercup",
                Type = "Herb",
                ImageURL = "/images/Items/Herb-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Water Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Water-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Earth Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Earth-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Air Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Air-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Fire Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Fire-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Shiny Scale",
                Type = "Scale",
                ImageURL = "/images/Items/Shiny-Scale.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Transparent Scale",
                Type = "Scale",
                ImageURL = "/images/Items/Transparent-Scale.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Golden Necklace",
                Type = "Metal",
                RelatedMaterials = "Gold Scraps 2, Iron Scraps 2",
                ImageURL = "/images/Items/Golden-Necklace.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Hard Scale",
                Type = "Scale",
                ImageURL = "/images/Items/Hard-Scale.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Tomato",
                Type = "Vegetables",
                ImageURL = "/images/Items/Tomato.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Lettuce",
                Type = "Vegetables",
                ImageURL = "/images/Items/Lettuce.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Turnip",
                Type = "Vegetables",
                ImageURL = "/images/Items/Turnip.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Pumpkin",
                Type = "Vegetables",
                ImageURL = "/images/Items/Pumpkin.png",
                IsRefineable = true,
            });

            // Profession
            this.context.Materials.Add(new Material
            {
                Name = "Dry Branch",
                Type = "Wood",
                ImageURL = "/images/Items/Dry-Branch.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Green Leaves",
                Type = "Wood",
                ImageURL = "/images/Items/Green-Leaves.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Tree Stump",
                Type = "Wood",
                ImageURL = "/images/Items/Tree-Stump.png",
                IsRefineable = true,
                FuelCount = 1,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Acorn",
                Type = "Wood",
                ImageURL = "/images/Items/Acorn.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Granite",
                Type = "Rock",
                ImageURL = "/images/Items/Granite.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Marble",
                Type = "Rock",
                ImageURL = "/images/Items/Marble.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Quartzite",
                Type = "Rock",
                ImageURL = "/images/Items/Quartzite.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Obsidian",
                Type = "Rock",
                ImageURL = "/images/Items/Obsidian.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Animal Stomach",
                Type = "Meat",
                ImageURL = "/images/Items/Animal-Stomach.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Animal Skull",
                Type = "Bones",
                RelatedMaterials = "Bone Dust 1, Bone Shards 2",
                ImageURL = "/images/Items/Animal-Skull.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Animal Bones",
                Type = "Bones",
                RelatedMaterials = "Bone Dust 2, Bone Shards 1",
                ImageURL = "/images/Items/Animal-Bones.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Fangs",
                Type = "Bones",
                ImageURL = "/images/Items/Fangs.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "T-Shirt",
                Type = "Cloth",
                RelatedMaterials = "Cloth 1, String 2",
                ImageURL = "/images/Items/T-Shirt.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Shoes",
                Type = "Leather",
                RelatedMaterials = "Leather 1,String 2",
                ImageURL = "/images/Items/Shoes.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Pants",
                Type = "Leather",
                RelatedMaterials = "Leather 1,Cloth 1,String 1",
                ImageURL = "/images/Items/Pants.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Human Soul",
                Type = "Essence",
                ImageURL = "/images/Items/Human-Soul.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Rose",
                Type = "Plant",
                ImageURL = "/images/Items/Rose.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Daisy",
                Type = "Plant",
                ImageURL = "/images/Items/Daisy.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Clay Pot",
                Type = "Furniture",
                RelatedMaterials = "Clay Dust 1,Clay Block 2",
                ImageURL = "/images/Items/Clay-Pot.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Plastic Vase",
                Type = "Furniture",
                ImageURL = "/images/Items/Plastic-Vase.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Life Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Life-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Light Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Light-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Shadow Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Shadow-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Death Essence",
                Type = "Essence",
                ImageURL = "/images/Items/Death-Essence.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "String",
                Type = "Cloth",
                ImageURL = "/images/Items/String.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Puffer Fish",
                Type = "Fish",
                RelatedMaterials = "Poison Vial 1,Fish Meat 1",
                ImageURL = "/images/Items/Puffer-Fish.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Turtle Eggs",
                Type = "Egg",
                ImageURL = "/images/Items/Turtle-Eggs.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Bottled Message",
                Type = "Junk",
                RelatedMaterials = "Glass 1,Paper 1",
                ImageURL = "/images/Items/Bottled-Message.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Potato",
                Type = "Vegetable",
                ImageURL = "/images/Items/Potato.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Corn",
                Type = "Vegetable",
                ImageURL = "/images/Items/Can.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Garden Shovel",
                Type = "Junk",
                RelatedMaterials = "Stick 1, Copper Chunks 1, Dirt 1",
                ImageURL = "/images/Items/Garden-Shovel.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Watering Can",
                Type = "Junk",
                RelatedMaterials = "Water Flask 1, Iron Chunks 1",
                ImageURL = "/images/Items/Watering-Can.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Broken Glass Cup",
                Type = "Junk",
                ImageURL = "/images/Items/Broken-Glass-Cup.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Stale Hotdog",
                Type = "Junk",
                ImageURL = "/images/Items/Stale-Hotdog.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Crushed Can",
                Type = "Junk",
                ImageURL = "/images/Items/Crushed-Can.png",
                IsRefineable = true,
            });

            // Junk
            this.context.Materials.Add(new Material
            {
                Name = "Rubber Band",
                Type = "Junk",
                ImageURL = "/images/Items/Rubber-Band.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Animal Blood",
                Type = "Junk",
                ImageURL = "/images/Items/Animal-Blood.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Dead Critters",
                Type = "Junk",
                ImageURL = "/images/Items/Dead-Critters.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Broken Skull",
                Type = "Junk",
                ImageURL = "/images/Items/Broken-Skull.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Broken Watch",
                Type = "Junk",
                RelatedMaterials = "Gold Scraps 1, Iron Scraps 1, Copper Scraps 1",
                ImageURL = "/images/Items/Broken-Watch.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Empty Plastic Bottle",
                Type = "Junk",
                RelatedMaterials = "Gold Scraps 1, Iron Scraps 1, Copper Scraps 1",
                ImageURL = "/images/Items/Empty-Plastic-Bottle.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Broken Cogs",
                Type = "Junk",
                RelatedMaterials = "Copper Scraps 1, Iron Scraps 1",
                ImageURL = "/images/Items/Broken-Cogs.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Rusty Pipes",
                Type = "Junk",
                RelatedMaterials = "Copper Scraps 2",
                ImageURL = "/images/Items/Rusty-Pipes.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Dead Battery",
                Type = "Junk",
                RelatedMaterials = "Iron Scraps 1, Golden Scraps 1",
                ImageURL = "/images/Items/Dead-Battery.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Cracked Water Orb",
                Type = "Junk",
                RelatedMaterials = "/images/Items/Cracked-Water-Orb.png",
                ImageURL = "https://ibb.co/K0GgNk2",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Coal Piece",
                Type = "Junk",
                ImageURL = "/images/Items/Coal-Piece.png",
                IsRefineable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Water Flask",
                Type = "Junk",
                ImageURL = "/images/Items/Water-Flask.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Worm",
                Type = "Junk",
                ImageURL = "/images/Items/Worm.png",
            });
            this.context.Materials.Add(new Material
            {
                Name = "Withered Roots",
                Type = "Junk",
                RelatedMaterials = "Stick 1,Dirt 1",
                ImageURL = "/images/Items/Withered-Roots.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Mud",
                Type = "Junk",
                RelatedMaterials = "Water Flask 1,Dirt 1",
                ImageURL = "/images/Items/Mud.png",
                IsDisolveable = true,
            });
            this.context.Materials.Add(new Material
            {
                Name = "Broken Branches",
                Type = "Junk",
                ImageURL = "/images/Items/Broken-Branches.png",
                IsRefineable = true,
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedToolsAsync(CancellationToken cancellationToken)
        {
            this.context.Tools.Add(new Tool
            {
                Name = "Saw",
                Durability = 10,
                ImageURL = "/images/Items/Saw.png",
                BuyPrice = 20,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Hammer",
                Durability = 10,
                ImageURL = "/images/Items/Hammer.png",
                BuyPrice = 20,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Sandpaper",
                Durability = 10,
                ImageURL = "/images/Items/Sandpaper.png",
                BuyPrice = 10,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Anvil",
                Durability = 30,
                ImageURL = "/images/Items/Anvil.png",
                BuyPrice = 60,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Knife",
                Durability = 10,
                ImageURL = "/images/Items/Knife.png",
                BuyPrice = 20,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Needle",
                Durability = 20,
                ImageURL = "/images/Items/Needle.png",
                BuyPrice = 10,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Ruler",
                Durability = 50,
                ImageURL = "/images/Items/Ruler.png",
                BuyPrice = 30,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Scissors",
                Durability = 20,
                ImageURL = "/images/Items/Scissors.png",
                BuyPrice = 40,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Knitting Kit",
                Durability = 20,
                ImageURL = "/images/Items/Knitting-Kit.png",
                BuyPrice = 10,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Mortar and Pestle",
                Durability = 30,
                ImageURL = "/images/Items/Mortar-and-Pestle.png",
                BuyPrice = 60,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Protective Mask",
                Durability = 10,
                ImageURL = "/images/Items/Protective-Mask.png",
                BuyPrice = 20,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Cooling Rod",
                Durability = 20,
                ImageURL = "/images/Items/Cooling-Rod.png",
                BuyPrice = 40,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Heavy Sandpaper",
                Durability = 20,
                ImageURL = "/images/Items/Heavy-Sandpaper.png",
                BuyPrice = 30,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Mixing Bowl",
                Durability = 30,
                ImageURL = "/images/Items/Mixing-Bowl.png",
                BuyPrice = 50,
            });
            this.context.Tools.Add(new Tool
            {
                Name = "Cutting Board",
                Durability = 30,
                ImageURL = "/images/Items/Cutting-Board.png",
                BuyPrice = 30,
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedUsersAsync(CancellationToken cancellationToken)
        {
            this.context.AppUsers.Add(new AppUser
            {
                UserName = "Pesho the Slayer [Not a real user]",
                Heroes = new List<Hero>(),
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonsterRaritiesAsync(CancellationToken cancellationToken)
        {
            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Bear-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Bear",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Bear-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Demon-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Demon",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Demon-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Giant-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Giant",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Giant-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Gryphon-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Gryphon",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Gryphon-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Reptile-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Reptile",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Reptile-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Saint-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Saint",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Saint-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Skeleton-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Skeleton",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Skeleton-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Wyrm-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Wyrm",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Wyrm-Heroic.png",
                StatAmplifier = 0.2,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Rare",
                ImageURL = "/images/Sprites/Zombie-Rare.png",
                StatAmplifier = 0.1,
            });

            this.context.MonstersRarities.Add(new MonsterRarity
            {
                MonsterName = "Zombie",
                Rarity = "Heroic",
                ImageURL = "/images/Sprites/Zombie-Heroic.png",
                StatAmplifier = 0.2,
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMonstersAsync(CancellationToken cancellationToken)
        {
            this.context.Monsters.Add(new Monster
            {
                Name = "Bear",
                MaxHP = 80,
                HealthRegen = 3,
                MaxMana = 75,
                ManaRegen = 5,
                AttackPower = 10,
                MagicPower = 5,
                ArmorValue = 5,
                ResistanceValue = 1,
                CritChance = 2,
                ImageURL = "/images/Sprites/Bear.png",
                Description = "A bloodthirsty animal,which also likes to party for some reason...",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Reptile",
                MaxHP = 60,
                HealthRegen = 2,
                MaxMana = 60,
                ManaRegen = 7,
                AttackPower = 12,
                MagicPower = 5,
                ArmorValue = 3,
                ResistanceValue = 3,
                CritChance = 5,
                ImageURL = "/images/Sprites/Reptile.png",
                Description = "Actually kind of a dinosaur/lizard thingy... not very sure.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Zombie",
                MaxHP = 72,
                HealthRegen = 4,
                MaxMana = 80,
                ManaRegen = 5,
                AttackPower = 8,
                MagicPower = 3,
                ArmorValue = 2.6,
                ResistanceValue = 2,
                CritChance = 2,
                ImageURL = "/images/Sprites/Zombie.png",
                Description = "Sapiosexual. Not very smart.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Skeleton",
                MaxHP = 62,
                HealthRegen = 8,
                MaxMana = 70,
                ManaRegen = 2,
                AttackPower = 12,
                MagicPower = 3,
                ArmorValue = 1.5,
                ResistanceValue = 2,
                CritChance = 9,
                ImageURL = "/images/Sprites/Skeleton.png",
                Description = "{Insert a /Spooky/ joke here.}",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Wyrm",
                MaxHP = 100,
                HealthRegen = 2,
                MaxMana = 80,
                ManaRegen = 10,
                AttackPower = 8.3,
                MagicPower = 11.6,
                ArmorValue = 4.6,
                ResistanceValue = 3,
                CritChance = 3,
                ImageURL = "/images/Sprites/Wyrm.png",
                Description = "Picture this guy beneath the toilet seat next time you take a dump. I dare you!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Giant",
                MaxHP = 186,
                HealthRegen = 3,
                MaxMana = 90,
                ManaRegen = 10,
                AttackPower = 7.8,
                MagicPower = 6,
                ArmorValue = 5,
                ResistanceValue = 5,
                CritChance = 2,
                ImageURL = "/images/Sprites/Giant.png",
                Description = "Not to be confused with the Iron Giant.",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Gryphon",
                MaxHP = 65,
                HealthRegen = 2,
                MaxMana = 110,
                ManaRegen = 8,
                AttackPower = 12,
                MagicPower = 5,
                ArmorValue = 4,
                ResistanceValue = 4,
                CritChance = 7,
                ImageURL = "/images/Sprites/Gryphon.png",
                Description = "These halfbreeds don't just exist in World of Warcraft!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Saint",
                MaxHP = 120,
                HealthRegen = 2,
                MaxMana = 120,
                ManaRegen = 8,
                AttackPower = 8,
                MagicPower = 15,
                ArmorValue = 2,
                ResistanceValue = 6,
                CritChance = 3,
                ImageURL = "/images/Sprites/Saint.png",
                Description = "You'll pay for not going to church on sundays!",
            });

            this.context.Monsters.Add(new Monster
            {
                Name = "Demon",
                MaxHP = 120,
                HealthRegen = 3.6,
                MaxMana = 100,
                ManaRegen = 6,
                AttackPower = 14,
                MagicPower = 8,
                ArmorValue = 7.3,
                ResistanceValue = 3.2,
                CritChance = 5.6,
                ImageURL = "/images/Sprites/Demon.png",
                Description = "Fearsome and cunning! Something is wrong with his head (I mean the PNG file).",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedFigthingClassesAsync(CancellationToken cancellationToken)
        {
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Warrior",
                MaxHP = 260,
                HealthRegen = 8.9,
                MaxMana = 110,
                ManaRegen = 6.2,
                AttackPower = 23,
                MagicPower = 8,
                ArmorValue = 5.8,
                ResistanceValue = 4,
                CritChance = 3.8,
                ImageURL = "/images/Sprites/Warrior.png",
                Description = "If you want to spam one button and lose brain cells simultaneously, you should probably play CS: GO." +
                "Main Stat: Strength.",
                IconURL = "/images/Icons/Warrior-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Hunter",
                MaxHP = 215,
                HealthRegen = 6.4,
                MaxMana = 110,
                ManaRegen = 6.6,
                AttackPower = 29,
                MagicPower = 13,
                ArmorValue = 4.5,
                ResistanceValue = 3.5,
                CritChance = 6,
                ImageURL = "/images/Sprites/Hunter.png",
                Description = "He could have a shotgun but that would be way too much OP." +
               "Main Stat: Agility.",
                IconURL = "/images/Icons/Hunter-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Mage",
                MaxHP = 210,
                HealthRegen = 5.8,
                MaxMana = 140,
                ManaRegen = 10,
                AttackPower = 18,
                MagicPower = 24,
                ArmorValue = 3,
                ResistanceValue = 8.8,
                CritChance = 2.8,
                ImageURL = "/images/Sprites/Mage.png",
                Description = "Like cards? Go to Vegas. Like bunnies? Open a rabbit farm. Want to 1-shot someone? [CLICK ME]!" +
                "Main Stat: Intellect.",
                IconURL = "/images/Icons/Mage-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Naturalist",
                MaxHP = 225,
                HealthRegen = 9.6,
                MaxMana = 130,
                ManaRegen = 12,
                AttackPower = 15,
                MagicPower = 22,
                ArmorValue = 4.8,
                ResistanceValue = 3.2,
                CritChance = 4,
                ImageURL = "/images/Sprites/Druid.png",
                Description = "Don't worry. I've already donated 5 bucks to that *Beast* guy." +
                "Main Stat: Spirit.",
                IconURL = "/images/Icons/Druid-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Necroid",
                MaxHP = 200,
                HealthRegen = 6.8,
                MaxMana = 150,
                ManaRegen = 10,
                AttackPower = 15,
                MagicPower = 30,
                ArmorValue = 3.6,
                ResistanceValue = 4,
                CritChance = 3,
                ImageURL = "/images/Sprites/Necroid.png",
                Description = "Actually, you don't wanna know about this guy. I've warned you." +
                "Main Stat: Intellect.",
                IconURL = "/images/Icons/Necroid-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Paladin",
                MaxHP = 225,
                HealthRegen = 10,
                MaxMana = 120,
                ManaRegen = 8,
                AttackPower = 22,
                MagicPower = 16,
                ArmorValue = 6,
                ResistanceValue = 7.3,
                CritChance = 4,
                ImageURL = "/images/Sprites/Paladin.png",
                Description = "Damage? Got it. Health? Got it. Girlfriend? ... :(" +
               "Main Stat: Strength.",
                IconURL = "/images/Icons/Paladin-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Priest",
                MaxHP = 190,
                HealthRegen = 8,
                MaxMana = 180,
                ManaRegen = 12,
                AttackPower = 15.6,
                MagicPower = 28,
                ArmorValue = 3,
                ResistanceValue = 5.6,
                CritChance = 3,
                ImageURL = "/images/Sprites/Priest.png",
                Description = "Don't worry. He won't molest you." +
               "Main Stat: Spirit.",
                IconURL = "/images/Icons/Priest-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Rogue",
                MaxHP = 195,
                HealthRegen = 6,
                MaxMana = 110,
                ManaRegen = 6,
                AttackPower = 26,
                MagicPower = 7.2,
                ArmorValue = 3.8,
                ResistanceValue = 2.5,
                CritChance = 6.3,
                ImageURL = "/images/Sprites/Rogue.png",
                Description = "He steals money. Enough said, you greedy bastard." +
               "Main Stat: Agility.",
                IconURL = "/images/Icons/Rogue-Icon.png",
            });
            this.context.FightingClasses.Add(new FightingClass
            {
                ClassType = "Shaman",
                MaxHP = 210,
                HealthRegen = 7,
                MaxMana = 130,
                ManaRegen = 11,
                AttackPower = 20,
                MagicPower = 18,
                ArmorValue = 4,
                ResistanceValue = 6,
                CritChance = 4,
                ImageURL = "/images/Sprites/Shaman.png",
                Description = "Freezing, zapping and stoning people to death was never such fun." +
               "Main Stat: Stamina.",
                IconURL = "/images/Icons/Shaman-Icon.png",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEnemySpellsAsync(CancellationToken cancellationToken)
        {
            // Beast
            this.context.Spells.Add(new Spell
            {
                Name = "Furious Roar",
                ManaRequirement = 0.2,
                ClassType = "Bear",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.2,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Bite",
                ManaRequirement = 0.2,
                ClassType = "Bear",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thick Hide",
                ManaRequirement = 0.5,
                ClassType = "Bear",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.8,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Lick Wounds",
                ManaRequirement = 0.4,
                ClassType = "Bear",
                Type = "Heal,Health,Self",
                Power = 0.22,
                BuffOrEffectTarget = "Self",
            });

            // Demon
            this.context.Spells.Add(new Spell
            {
                Name = "Corruption",
                ManaRequirement = 0.3,
                ClassType = "Demon",
                Type = "Buff,hRegen,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Punch",
                ManaRequirement = 0.25,
                ClassType = "Demon",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 0.9,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Eye Of The Void",
                ManaRequirement = 0.25,
                ClassType = "Demon",
                Type = "Buff,Armor,Target,Negative",
                Power = 0.33,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Ripping Hell-Fire",
                ManaRequirement = 0.65,
                ClassType = "Demon",
                Type = "Damage,Magical,Self",
                Power = 1.42,
                ResistanceAffect = 0.88,
            });

            // Giant
            this.context.Spells.Add(new Spell
            {
                Name = "Overgrowth",
                ManaRequirement = 0.22,
                ClassType = "Giant",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.36,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Calming Mind",
                ManaRequirement = 0.12,
                ClassType = "Giant",
                Type = "Buff,mRegen,Self,Positive",
                Power = 0.3,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Mind",
                ManaRequirement = 0.4,
                ClassType = "Giant",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.3,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Overpowering Fist",
                ManaRequirement = 0.4,
                ClassType = "Giant",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 0.65,
            });

            // Gryphon
            this.context.Spells.Add(new Spell
            {
                Name = "Diving Claw",
                ManaRequirement = 0.3,
                ClassType = "Gryphon",
                Type = "Damage,Physical,Self",
                Power = 1.18,
                ResistanceAffect = 0.5,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Petryfying Gaze",
                ManaRequirement = 0.5,
                ClassType = "Gryphon",
                Type = "Buff,hRegen,Target,Negative",
                Power = 0.42,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Gust",
                ManaRequirement = 0.3,
                ClassType = "Gryphon",
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Peck",
                ManaRequirement = 0.2,
                ClassType = "Gryphon",
                Type = "Damage,Physical,Self",
                Power = 1.15,
                ResistanceAffect = 0.85,
            });

            // Reptile
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Spit",
                ManaRequirement = 0.3,
                ClassType = "Reptile",
                Type = "Damage,Magical,Self",
                Power = 1.2,
                ResistanceAffect = 0.9,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Reflelcting Scales",
                ManaRequirement = 0.3,
                ClassType = "Reptile",
                Type = "Damage,Physical,Target",
                Power = 0.4,
                AdditionalEffect = "Armor,Positive",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Skin Change",
                ManaRequirement = 0.3,
                ClassType = "Reptile",
                Type = "Buff,Res,Self,Positive",
                Power = 0.6,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Scratch",
                ManaRequirement = 0.15,
                ClassType = "Reptile",
                Type = "Damage,Physical,Self",
                Power = 1.22,
                ResistanceAffect = 1,
            });

            // Saint
            this.context.Spells.Add(new Spell
            {
                Name = "Sacred Words",
                ManaRequirement = 0.4,
                ClassType = "Saint",
                Type = "Heal,Magical,Self",
                Power = 1.8,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Illumination",
                ManaRequirement = 0.35,
                ClassType = "Saint",
                Type = "Buff,Magic,Target,Negative",
                Power = 0.28,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Smite",
                ManaRequirement = 0.12,
                ClassType = "Saint",
                Type = "Damage,Magical,Self",
                Power = 1,
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Judgement Day",
                ManaRequirement = 0.42,
                ClassType = "Saint",
                Type = "Damage,Magical,Self",
                Power = 1.22,
                AdditionalEffect = "Mana,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.5,
            });

            // Skeleton
            this.context.Spells.Add(new Spell
            {
                Name = "Tombstone",
                ManaRequirement = 0.15,
                ClassType = "Skeleton",
                Type = "Buff,Res,Self,Positive",
                Power = 1.2,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Wrath Of The Necropolis",
                ManaRequirement = 0.4,
                ClassType = "Skeleton",
                Type = "Damage,Physical/Magical,Self",
                Power = 1,
                SecondaryPower = 0.65,
                ResistanceAffect = 0.7,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Suffocation",
                ManaRequirement = 0.3,
                ClassType = "Skeleton",
                Type = "Damage,Physical,Self",
                Power = 1.1,
                AdditionalEffect = "hRegen,Negative,mRegen,Negative",
                EffectPower = 0.12,
                SecondaryPower = 0.15,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Horrifying Scream",
                ManaRequirement = 0.3,
                ClassType = "Skeleton",
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            // Wyrm
            this.context.Spells.Add(new Spell
            {
                Name = "Tidal Slash",
                ManaRequirement = 0.18,
                ClassType = "Wyrm",
                Type = "Damage,Physical,Self",
                Power = 1.15,
                AdditionalEffect = "Magic,Positive",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Dive",
                ManaRequirement = 0.3,
                ClassType = "Wyrm",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.2,
                AdditionalEffect = "Res,Positive",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Speed",
                ManaRequirement = 0.3,
                ClassType = "Wyrm",
                Type = "Buff,mRegen,Self,Positve",
                Power = 0.6,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder",
                ManaRequirement = 0.5,
                ClassType = "Wyrm",
                Type = "Damage,Magical,Self",
                Power = 1.3,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.28,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.8,
            });

            // Zombie
            this.context.Spells.Add(new Spell
            {
                Name = "Infecting Bite",
                ManaRequirement = 0.4,
                ClassType = "Zombie",
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 1,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Feed",
                ManaRequirement = 0.3,
                ClassType = "Zombie",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.25,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutation",
                ManaRequirement = 0.4,
                ClassType = "Zombie",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.4,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.6,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Decay",
                ManaRequirement = 0.15,
                ClassType = "Zombie",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.5,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
            });
            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPlayerSpellsAsync(CancellationToken cancellationToken)
        {
            // Hunter
            this.context.Spells.Add(new Spell
            {
                Name = "Hasting Arrow",
                ManaRequirement = 0.12,
                ClassType = "Hunter",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                ResistanceAffect = 1,
                AdditionalEffect = "Crit,Positive",
                BuffOrEffectTarget = "Self",
                EffectPower = 0.05,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Grass Hop",
                ManaRequirement = 0.5,
                ClassType = "Hunter",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.7,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Shot",
                ManaRequirement = 0.25,
                ClassType = "Hunter",
                Type = "Damage,Physical/Magical,Self",
                Power = 0.5,
                SecondaryPower = 0.7,
                ResistanceAffect = 0.5,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Sharp Eye",
                ManaRequirement = 0.5,
                ClassType = "Hunter",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.3,
                BuffOrEffectTarget = "Self",
            });

            // Mage
            this.context.Spells.Add(new Spell
            {
                Name = "Water Ball",
                ManaRequirement = 0.2,
                ClassType = "Mage",
                Type = "Damage,Magical,Self",
                Power = 0.7,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.22,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Fire Ball",
                ManaRequirement = 0.25,
                ClassType = "Mage",
                Type = "Damage,Magical/MaxHP,Self/Target",
                Power = 0.8,
                SecondaryPower = 0.05,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 0.7,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Conversion",
                ManaRequirement = 0,
                ClassType = "Mage",
                Type = "Buff,Mana,Self,Positive",
                Power = 0.25,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self/Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "All-Out Blast!",
                ManaRequirement = 0.8,
                ClassType = "Mage",
                Type = "Damage,Magical,Self",
                Power = 2,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.2,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 0,
            });

            // Naturalist
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Touch",
                ManaRequirement = 0.4,
                ClassType = "Naturalist",
                Type = "Heal,Magical,Self",
                Power = 0.5,
                AdditionalEffect = "Armor,Positive",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thorn Blast",
                ManaRequirement = 0.28,
                ClassType = "Naturalist",
                Type = "Damage,Magical,Self",
                Power = 0.75,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Gift",
                ManaRequirement = 0,
                ClassType = "Naturalist",
                Type = "Buff,hRegen,Self,Positive",
                Power = 1.2,
                AdditionalEffect = "Magic,Positive,Health,Negative",
                EffectPower = 0.1,
                SecondaryPower = 0.05,
                BuffOrEffectTarget = "Caster/Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Pouring Rain",
                ManaRequirement = 0,
                ClassType = "Naturalist",
                Type = "Buff,Mana,Self,Positive",
                Power = 0.3,
                AdditionalEffect = "mRegen,Negative",
                EffectPower = 0.15,
                BuffOrEffectTarget = "Caster",
            });

            // Necroid
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Touch",
                ManaRequirement = 0.28,
                ClassType = "Necroid",
                Type = "Damage,CurrentMana/MaxHP,Self/Target",
                Power = 0.11,
                SecondaryPower = 0.08,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.3,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Life Syphon",
                ManaRequirement = 0.4,
                ClassType = "Necroid",
                Type = "Damage,Magical/MaxHP,Self/Target",
                Power = 0.5,
                SecondaryPower = 0.08,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Arcane Bane",
                ManaRequirement = 0.2,
                ClassType = "Necroid",
                Type = "Buff,Magic,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutual Darkness",
                ManaRequirement = 0,
                ClassType = "Necroid",
                Type = "Damage,MaxHP,Self",
                Power = 0.15,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.07,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });

            // Paladin
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Strike",
                ManaRequirement = 0.15,
                ClassType = "Paladin",
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "Magic,Positive",
                EffectPower = 0.1,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 0.7,

            });
            this.context.Spells.Add(new Spell
            {
                Name = "Burning Light",
                ManaRequirement = 0.15,
                ClassType = "Paladin",
                Type = "Damage,Magical,Self",
                Power = 1.1,
                ResistanceAffect = 1,

            });
            this.context.Spells.Add(new Spell
            {
                Name = "Vicious Spell-Guard",
                ManaRequirement = 0.35,
                ClassType = "Paladin",
                Type = "Buff,Res,Self,Positive",
                Power = 0.55,
                BuffOrEffectTarget = "Self",

            });
            this.context.Spells.Add(new Spell
            {
                Name = "Divine Rune",
                ManaRequirement = 0.2,
                ClassType = "Paladin",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.15,
                BuffOrEffectTarget = "Self",
            });

            // Priest
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Light",
                ManaRequirement = 0.3,
                ClassType = "Priest",
                Type = "Heal,Magical,Self",
                Power = 1.1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Drain",
                ManaRequirement = 0.08,
                ClassType = "Priest",
                Type = "Buff,Mana,Target,Negative",
                Power = 0.2,
                AdditionalEffect = "Mana,Positive",
                SecondaryPower = 0.2,
                BuffOrEffectTarget = "Target/Self",

            });
            this.context.Spells.Add(new Spell
            {
                Name = "Staff Smash",
                ManaRequirement = 0.14,
                ClassType = "Priest",
                Type = "Damage,Physical,Self",
                Power = 1.2,
                AdditionalEffect = "Armor,Negative",
                EffectPower = 0.18,
                BuffOrEffectTarget = "Target",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Blessing",
                ManaRequirement = 0.35,
                ClassType = "Priest",
                Type = "Buff,Magic,Self,Positive",
                Power = 0.25,
                AdditionalEffect = "hRegen,Negative",
                EffectPower = 0.4,
                BuffOrEffectTarget = "Self",
            });

            // Rogue
            this.context.Spells.Add(new Spell
            {
                Name = "Stab",
                ManaRequirement = 0.12,
                ClassType = "Rogue",
                Type = "Damage,Physical,Self",
                Power = 1.05,
                AdditionalEffect = "Attack,Positive",
                EffectPower = 0.08,
                BuffOrEffectTarget = "Self",
                ResistanceAffect = 1,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Dagger",
                ManaRequirement = 0.28,
                ClassType = "Rogue",
                Type = "Damage,Physical/Magical,Self",
                Power = 0.2,
                SecondaryPower = 1.1,
                ResistanceAffect = 0.6,
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Evasion",
                ManaRequirement = 0.4,
                ClassType = "Rogue",
                Type = "Buff,Armor,Self,Positive",
                Power = 0.55,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.35,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thievery",
                ManaRequirement = 0.45,
                ClassType = "Rogue",
                Type = "Buff,Gold,Self,Positive",
                Power = 4,
                BuffOrEffectTarget = "Self",
            });

            // Shaman
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder Strike",
                ManaRequirement = 0.45,
                ClassType = "Shaman",
                Type = "Damage,Magical/Physical,Self",
                Power = 1.2,
                SecondaryPower = 0.2,
                AdditionalEffect = "Res,Negative",
                EffectPower = 0.4,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Target",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Earth Strike",
                ManaRequirement = 0.45,
                ClassType = "Shaman",
                Type = "Damage,Physical/Magical,Self",
                Power = 1.2,
                SecondaryPower = 0.2,
                AdditionalEffect = "Health,Positive",
                EffectPower = 0.08,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Flame Strike",
                ManaRequirement = 0.25,
                ClassType = "Shaman",
                Type = "Damage,Physical/Magical,Self",
                Power = 1.15,
                SecondaryPower = 0.11,
                AdditionalEffect = "Attack,Positive",
                EffectPower = 0.15,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Water Strike",
                ManaRequirement = 0.24,
                ClassType = "Shaman",
                Type = "Damage,Magical,Self",
                Power = 1.1,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.22,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",
            });

            // Warrior
            this.context.Spells.Add(new Spell
            {
                Name = "Head Smash",
                ManaRequirement = 0.35,
                ClassType = "Warrior",
                Type = "Damage,Physical,Self",
                Power = 1.3,
                AdditionalEffect = "Health,Negative",
                EffectPower = 0.08,
                ResistanceAffect = 1,
                BuffOrEffectTarget = "Self",

            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Strength",
                ManaRequirement = 0.35,
                ClassType = "Warrior",
                Type = "Buff,Attack,Self,Positive",
                Power = 0.2,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Blow",
                ManaRequirement = 0.13,
                ClassType = "Warrior",
                Type = "Damage,Physical,Self",
                Power = 1,
                AdditionalEffect = "mRegen,Positive",
                EffectPower = 0.24,
                ResistanceAffect = 0.8,
                BuffOrEffectTarget = "Self",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Disarm",
                ManaRequirement = 0.50,
                ClassType = "Warrior",
                Type = "Buff,Attack,Target,Negative",
                Power = 0.2,
                BuffOrEffectTarget = "Target",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedStatusesAsync(CancellationToken cancellationToken)
        {
            this.context.Statuses.Add(new Status
            {
                DisplayName = "UnSet",
                IClass = "far fa-meh-blank",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Meh",
                IClass = "far fa-meh",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Happy",
                IClass = "far fa-smile",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Star",
                IClass = "far fa-grin-stars",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Tired",
                IClass = "far fa-tired",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "In Love",
                IClass = "far fa-grin-hearts",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Fresh",
                IClass = "far fa-grin-tongue-wink",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Status",
                IClass = "far fa-frown",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "WTF",
                IClass = "fas fa-flushed",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "LUL",
                IClass = "far fa-grin-squint-tears",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Angry",
                IClass = "far fa-angry",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Focused",
                IClass = "fas fa-podcast",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Chilling",
                IClass = "far fa-hand-peace",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Cat",
                IClass = "fas fa-cat",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Home With My Dog",
                IClass = "fas fa-dog",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "Having A Snack",
                IClass = "fas fa-drumstick-bite",
            });

            this.context.Statuses.Add(new Status
            {
                DisplayName = "9000+ IQ",
                IClass = "fas fa-brain",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
