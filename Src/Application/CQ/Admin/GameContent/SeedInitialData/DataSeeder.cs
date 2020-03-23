﻿namespace Application.SeedInitialData
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Game;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::Domain.Entities.Common;

    public class DataSeeder
    {
        private readonly IFFDbContext context;

        public DataSeeder(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync(CancellationToken cancellationToken)
        {
            await this.SeedUsers(cancellationToken);

            await this.SeedPlayerSpells(cancellationToken);

            await this.SeedPlayerImages(cancellationToken);

            await this.SeedEnemySpells(cancellationToken);

            await this.SeedEnemyImages(cancellationToken);
        }

        private async Task SeedUsers(CancellationToken cancellationToken)
        {
            this.context.AppUsers.Add(new AppUser
            {
                UserName = "Pesho the Slayer",
                Units = new List<Unit>(),
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEnemyImages(CancellationToken cancellationToken)
        {
            this.context.Images.Add(new Image
            {
                Name = "Beast",
                Path = "https://i.ibb.co/tm9p0Bq/Beast.png",
                Description = "A bloodthirsty animal,which also likes to party for some reason...",
            });
            this.context.Images.Add(new Image
            {
                Name = "BeastRare",
                Path = "https://i.ibb.co/YhPcrdk/Beast-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "BeastHeroic",
                Path = "https://i.ibb.co/NVdyxh5/Bear-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Demon",
                Path = "https://i.ibb.co/Mf1WWjq/Demon.png",
                Description = "Fearsome and cunning! Something is wrong with his head (I mean the PNG file).",
            });
            this.context.Images.Add(new Image
            {
                Name = "DemonRare",
                Path = "https://i.ibb.co/tYPNYVr/Demon-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "DemonHeroic",
                Path = "https://i.ibb.co/rHVZhHM/Demon-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Giant",
                Path = "https://i.ibb.co/HpF09kD/Giant.png",
                Description = "Not to be confused with the Iron Giant.",
            });
            this.context.Images.Add(new Image
            {
                Name = "GiantRare",
                Path = "https://i.ibb.co/8XjdXby/Giant-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "GiantHeroic",
                Path = "https://i.ibb.co/XjvgFxk/Giant-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Gryphon",
                Path = "https://i.ibb.co/ydLmqmL/Gryphon.png",
                Description = "These halfbreeds don't just exist in World of Warcraft!",
            });
            this.context.Images.Add(new Image
            {
                Name = "GryphonRare",
                Path = "https://i.ibb.co/1J3KskV/Gryphon-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "GryphonHeroic",
                Path = "https://i.ibb.co/8dbFYx7/Gryphon-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Reptile",
                Path = "https://i.ibb.co/PskPtmp/Reptile.png",
                Description = "Actually kind of a dinosaur/lizard thingy... not very sure.",
            });
            this.context.Images.Add(new Image
            {
                Name = "ReptileRare",
                Path = "https://i.ibb.co/59VHzwY/Reptile-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "ReptileHeroic",
                Path = "https://i.ibb.co/wd1HqhQ/Reptile-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Saint",
                Path = "https://i.ibb.co/bgdLZny/Saint.png",
                Description = "You'll pay for not going to church on sundays!",
            });
            this.context.Images.Add(new Image
            {
                Name = "SaintRare",
                Path = "https://i.ibb.co/tJQKJcx/Saint-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "SaintHeroic",
                Path = "https://i.ibb.co/dgGbS3t/Saint-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Skeleton",
                Path = "https://i.ibb.co/72jY07Q/Skeleton.png",
                Description = "{Insert a /Spooky/ joke here.}",
            });
            this.context.Images.Add(new Image
            {
                Name = "SkeletonRare",
                Path = "https://i.ibb.co/rQPCZWf/Skeleton-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "SkeletonHeroic",
                Path = "https://i.ibb.co/TqDMrY5/Skeleton-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Wyrm",
                Path = "https://i.ibb.co/0QcMBhp/Wyrm.png",
                Description = "Picture this guy beneath the toilet seat next time you take a dump. I dare you!",
            });
            this.context.Images.Add(new Image
            {
                Name = "WyrmRare",
                Path = "https://i.ibb.co/BgjswQW/WyrmRare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "WyrmHeroic",
                Path = "https://i.ibb.co/V9gh3KY/Wyrm-Heroic.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Zombie",
                Path = "https://i.ibb.co/NLF8yxW/Zombie.png",
                Description = "Sapiosexual. Not very smart.",
            });
            this.context.Images.Add(new Image
            {
                Name = "ZombieRare",
                Path = "https://i.ibb.co/3rJB9hG/Zombie-Rare.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "ZombieHeroic",
                Path = "https://i.ibb.co/9crHfr7/Zombie-Heroic.png",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPlayerImages(CancellationToken cancellationToken)
        {
            this.context.Images.Add(new Image
            {
                Name = "Warrior",
                Path = "https://i.ibb.co/XVJ5cHJ/Warrior.png",
                Description = "If you want to spam one button and lose brain cells simultaneously, you should probably play CS: GO." +
                "Main Stat: Strength.",
                IconURL = "https://i.ibb.co/wyMw3jR/Warrior-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Hunter",
                Path = "https://i.ibb.co/DDPXJbv/Hunter.png",
                Description = "He could have a shotgun but that would be way too much OP." +
               "Main Stat: Agility.",
                IconURL = "https://i.ibb.co/FDj0HbP/Hunter-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Mage",
                Path = "https://i.ibb.co/n6q7zgb/Mage.png",
                Description = "Like cards? Go to Vegas. Like bunnies? Open a rabbit farm. Want to 1-shot someone? [CLICK ME]!" +
                "Main Stat: Intellect.",
                IconURL = "https://i.ibb.co/k55MXgG/MageIcon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Naturalist",
                Path = "https://i.ibb.co/Ht6ZBtv/Druid.png",
                Description = "Don't worry. I've already donated 5 bucks to that *Beast* guy." +
                "Main Stat: Spirit.",
                IconURL = "https://i.ibb.co/gmK4VjW/Druid-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Necroid",
                Path = "https://i.ibb.co/Ms0bv1v/Necroid.png",
                Description = "Actually, you don't wanna know about this guy. I've warned you." +
                "Main Stat: Intellect.",
                IconURL = "https://i.ibb.co/0rf3kG3/Necroid-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Paladin",
                Path = "https://i.ibb.co/yNX0SZn/Paladin.png",
                Description = "Damage? Got it. Health? Got it. Girlfriend? ... :(" +
               "Main Stat: Strength.",
                IconURL = "https://i.ibb.co/yVVp9Md/Paladin-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Priest",
                Path = "https://i.ibb.co/xhDTxW6/Priest.png",
                Description = "Don't worry. He won't molest you." +
               "Main Stat: Spirit.",
                IconURL = "https://i.ibb.co/pWd8pbq/Priest-Icon.png",
            });
            this.context.Images.Add(new Image
            {
                Name = "Rogue",
                Path = "https://i.ibb.co/K5YgbHG/Rogue.png",
                Description = "He steals money. Enough said, you greedy bastard." +
               "Main Stat: Agility.",
                IconURL = string.Empty,
            });
            this.context.Images.Add(new Image
            {
                Name = "Shaman",
                Path = "https://i.ibb.co/fStYvFC/Shaman.png",
                Description = "Freezing, zapping and stoning people to death was never such fun." +
               "Main Stat: Stamina.",
                IconURL = "https://i.ibb.co/kDrCmXw/Shaman-Icon.png",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEnemySpells(CancellationToken cancellationToken)
        {
            // Beast
            this.context.Spells.Add(new Spell
            {
                Name = "Furious Roar",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Bite",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thick Hide",
                ManaRequirment = 50,
                ClassType = "Beast",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Lick Wounds",
                ManaRequirment = 20,
                ClassType = "Beast",
                UserType = "Enemy",
            });

            // Demon
            this.context.Spells.Add(new Spell
            {
                Name = "Corruption",
                ManaRequirment = 30,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Blast",
                ManaRequirment = 30,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Eye Of The Void",
                ManaRequirment = 20,
                ClassType = "Demon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Ripping Hell-Fire",
                ManaRequirment = 80,
                ClassType = "Demon",
                UserType = "Enemy",
            });

            // Giant
            this.context.Spells.Add(new Spell
            {
                Name = "Overgrowth",
                ManaRequirment = 40,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Calming Mind",
                ManaRequirment = 10,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Mind",
                ManaRequirment = 50,
                ClassType = "Giant",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Overpowering Fist",
                ManaRequirment = 50,
                ClassType = "Giant",
                UserType = "Enemy",
            });

            // Gryphon
            this.context.Spells.Add(new Spell
            {
                Name = "Diving Claw",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Petryfying Gaze",
                ManaRequirment = 50,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Gust",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Peck",
                ManaRequirment = 30,
                ClassType = "Gryphon",
                UserType = "Enemy",
            });

            // Reptile
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Spit",
                ManaRequirment = 30,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Reflelcting Scales",
                ManaRequirment = 30,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Skin Change",
                ManaRequirment = 40,
                ClassType = "Reptile",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Scratch",
                ManaRequirment = 15,
                ClassType = "Reptile",
                UserType = "Enemy",
            });

            // Saint
            this.context.Spells.Add(new Spell
            {
                Name = "Sacred Words",
                ManaRequirment = 40,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Illumination",
                ManaRequirment = 30,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Smite",
                ManaRequirment = 15,
                ClassType = "Saint",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Judgement Day",
                ManaRequirment = 50,
                ClassType = "Saint",
                UserType = "Enemy",
            });

            // Skeleton
            this.context.Spells.Add(new Spell
            {
                Name = "Tombstone",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Wrath Of The Necropolis",
                ManaRequirment = 50,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Suffocation",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Horrifying Scream",
                ManaRequirment = 30,
                ClassType = "Skeleton",
                UserType = "Enemy",
            });

            // Wyrm
            this.context.Spells.Add(new Spell
            {
                Name = "Tidal Slash",
                ManaRequirment = 15,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Dive",
                ManaRequirment = 30,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Speed",
                ManaRequirment = 30,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder",
                ManaRequirment = 50,
                ClassType = "Wyrm",
                UserType = "Enemy",
            });

            // Zombie
            this.context.Spells.Add(new Spell
            {
                Name = "Infecting Bite",
                ManaRequirment = 40,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Feed",
                ManaRequirment = 50,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutation",
                ManaRequirment = 50,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Decay",
                ManaRequirment = 10,
                ClassType = "Zombie",
                UserType = "Enemy",
            });
            await this.context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPlayerSpells(CancellationToken cancellationToken)
        {
            // Hunter
            this.context.Spells.Add(new Spell
            {
                Name = "Hasting Arrow",
                ManaRequirment = 20,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Grass Hop",
                ManaRequirment = 50,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Volley Shot",
                ManaRequirment = 30,
                ClassType = "Hunter",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Sharp Eye",
                ManaRequirment = 50,
                ClassType = "Hunter",
                UserType = "Player",
            });

            // Mage
            this.context.Spells.Add(new Spell
            {
                Name = "Water Ball",
                ManaRequirment = 30,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Fire Ball",
                ManaRequirment = 25,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Conversion",
                ManaRequirment = 0,
                ClassType = "Mage",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "All-Out Blast!",
                ManaRequirment = 100,
                ClassType = "Mage",
                UserType = "Player",
            });

            // Naturalist
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Touch",
                ManaRequirment = 50,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thorn Blast",
                ManaRequirment = 35,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Nature's Gift",
                ManaRequirment = 0,
                ClassType = "Naturalist",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Pouring Raind",
                ManaRequirment = 0,
                ClassType = "Naturalist",
                UserType = "Player",
            });

            // Necroid
            this.context.Spells.Add(new Spell
            {
                Name = "Shadow Touch",
                ManaRequirment = 25,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Life Drain",
                ManaRequirment = 35,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Blind",
                ManaRequirment = 15,
                ClassType = "Necroid",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mutual Darkness",
                ManaRequirment = 0,
                ClassType = "Necroid",
                UserType = "Player",
            });

            // Paladin
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Strike",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Burning Light",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Vicious Spell-Guard",
                ManaRequirment = 30,
                ClassType = "Paladin",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Divine Rune",
                ManaRequirment = 15,
                ClassType = "Paladin",
                UserType = "Player",
            });

            // Priest
            this.context.Spells.Add(new Spell
            {
                Name = "Holy Light",
                ManaRequirment = 30,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Mana Drain",
                ManaRequirment = 10,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Staff Smash",
                ManaRequirment = 12,
                ClassType = "Priest",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Blessing",
                ManaRequirment = 50,
                ClassType = "Priest",
                UserType = "Player",
            });

            // Rogue
            this.context.Spells.Add(new Spell
            {
                Name = "Stab",
                ManaRequirment = 12,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Poison Dagger",
                ManaRequirment = 30,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Evasion",
                ManaRequirment = 50,
                ClassType = "Rogue",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Thievery",
                ManaRequirment = 50,
                ClassType = "Rogue",
                UserType = "Player",
            });

            // Shaman
            this.context.Spells.Add(new Spell
            {
                Name = "Thunder Strike",
                ManaRequirment = 50,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Earth Strike",
                ManaRequirment = 50,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Flame Strike",
                ManaRequirment = 25,
                ClassType = "Shaman",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Water Strike",
                ManaRequirment = 25,
                ClassType = "Shaman",
                UserType = "Player",
            });

            // Warrior
            this.context.Spells.Add(new Spell
            {
                Name = "Head Smash",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Hyper Strength",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Raging Blow",
                ManaRequirment = 12,
                ClassType = "Warrior",
                UserType = "Player",
            });
            this.context.Spells.Add(new Spell
            {
                Name = "Disarm",
                ManaRequirment = 50,
                ClassType = "Warrior",
                UserType = "Player",
            });

            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
