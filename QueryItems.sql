INSERT INTO [dbo].[Items](Name, Description, Category, Price) 
VALUES ('Arcane Ring',
'
Restores 75 mana to all nearby allies.
Radius: 1200.
Mana Restored: 75.
Cooldown: 40.
+8 Intelligence.
+3 Armor.
','Tier 1',500),
('Elixir',
'
Restores 500 health and 250 mana to the target over 6 seconds.
If the unit is attacked by an enemy hero or Roshan, the effect is lost.
Default Cast Range: 250.
Buffer Cast Range: 500.
Max Health Restored: 500.
Max Mana Restored: 250.
Duration: 6.
Cooldown: 0.
','Tier 1',300),
('Iron Talon',
'
Targets a non-player enemy unit to remove 40% of its current HP.
If cast on a tree or ward, instantly destroys it.
Cast Range (Tree/Unit): 350.
Cast Range (Other): 450.
Current Health as Damage: 40%.
Cooldown: 25 / 4.
+2 Armor.
','Tier 1',400),
('Mango Tree',
'
Targets the ground to plant a mango tree that provides unlimited mango power. The tree generates Enchanted Mangoes every 60 seconds, and provides unobstructed vision in the area.
Cast Range: 200.
Vision Radius: 1200.
Mango Drop Radius: 200.
Mango Spawn Interval: 60.
Tree Duration: Permanent.
Cooldown: 0.
','Tier 1',800),
('Poor Mans Shield',
'
Gives a 100% chance to block 20 damage from incoming attacks on melee heroes, and 10 damage on ranged.
Has a 50% chance to block damage from creeps.
Hero Proc Chance: 100%.
Non-Hero Proc Chance: 50%.
Blocked Damage (Melee): 20.
Blocked Damage (Ranged): 10.
+6 Agility.
','Tier 1',350),
('Trusty Shovel',
'
Channel for 1 second.
Can find a Bounty Rune, a Flask, a 2 charged TP Scroll bundle, or an enemy Kobold.
Channel Time: 1.
Bounty Rune Drop Chance: 16%.
Healing Salve Drop Chance: 28%.
Town Portal Scroll Drop Chance: 28%.
Kobold Drop Chance: 28%.
Cooldown: 55.
+150 Health.
','Tier 1',220),
('Broom Handle',
'
+3 Armor.
+12 Attack damage.
+35 Attack range (melee).
','Tier 1',150),
('Faded Broach',
'
+225 Mana.
+25 Movement speed.
','Tier 1',500),
('Keen Optic',
'
+1 Mana regeneration.
+75 Cast range.
','Tier 1',120),
('Ocean Heart',
'
Provides you with 6 HP regen and 3 mana regen while in the river.
River Health Regeneration Bonus: 6.
River Mana Regeneration Bonus: 3.
+5 Strength.
+5 Agility.
+5 Intelligence.
','Tier 1',700),
('Royal Jelly',
'
Grants a target allied unit a permanent buff that provides +2.5 Health Regen and +1.25.
Cast Range: 250.
Health Regeneration Bonus: 2.5.
Mana Regeneration Bonus: 1.25.
Cooldown: 0.
Cannot be used by illusions. Illusions do not copy the buff.
','Tier 1',55),
('Ironwood Tree',
'
Targets the ground to plant a happy little tree that lasts for 20 seconds.
Cast Range: 800.
Duration: 20.
Cooldown: 4.
+7 Strength.
+7 Agility.
+7 Intelligence.
','Tier 1',900),
('Clumsy Net',
'
Ensnares the target enemy and yourself for 2 seconds.
Cast Range: 900.
Duration: 2.
Cooldown: 25.
Partially pierces spell immunity. Cannot be cast on spell immune enemies.
Pierces spell immunity on the caster.
Blocked by Linkens Sphere. Blocked upon impact.
+5 Strength.
+5 Agility.
+5 Intelligence.
+2 Mana regeneration.
','Tier 2',1100),

('Essence Ring',
'
Heal 425 and gain 425 max health for 15 seconds.
Max Health Bonus: 425.
Duration: 15.
Cooldown: 20.
Mana: 200.
+6 Intelligence.
+2.5 Mana regeneration.
','Tier 2',1200),

('Imp Claw',
'
Empowers your next attack, causing it to be a critical strike dealing 130% damage.
Critical Damage: 130%.
Cooldown: 8.
Can be used by illusions. Red critical numbers are before illusion and armor reduction.
+24 Attack damage.
','Tier 2',1600),

('Philosophers Stone',
'
+200 Mana.
-35 Attack damage.
+60 Gold per minute.
','Tier 2',1900),

('Ring of Aquila',
'
Grants 1.25 mana regeneration and 2 armor to nearby allies.
Deactivate to stop affecting non-hero units.
Radius: 1200.
Mana Regeneration Bonus: 1.25.
Armor Bonus: 2.
Aura Linger Duration: 0.5.
Cooldown: 0.
Can be used by illusions. Illusions bestow the aura, but do not benefit from the armor.
+3 Strength.
+9 Agility.
+3 Intelligence.
+7 Attack damage.
','Tier 2',1650),

('Vambrace (Agility)',
'
+6 Strength.
+12 Agility.
+6 Intelligence.
+12 Attack speed.
','Tier 2',1320),

('Vambrace (Strength)',
'
+12 Strength.
+6 Agility.
+6 Intelligence.
+10% Magic resistance.
','Tier 2',1260),

('Vambrace (Intelligence)',
'
+6 Strength.
+6 Agility.
+12 Intelligence.
+6% Spell damage.
','Tier 2',1100),

('Dragon Scale',
'
Causes attacks to burn the enemy, dealing 12 damage per second for 3 seconds.
Affects buildings.
Damage per Second: 12.
Duration: 3.
+5 Health regeneration.
+5 Armor.
','Tier 2',1980),

('Grove Bow',
'
Reduces magic resistance of the attacked enemy by 12%.
Magic Resistance Reduction: 12%.
Duration: 6.
+10 Attack speed.
+100 Attack range (ranged).
','Tier 2',1060),

('Nether Shawl',
'
-4 Armor.
+8% Spell damage.
+20% Magic resistance.
','Tier 2',1010),

('Pupils Gift',
'
+13 Secondary attributes.
','Tier 2',1500),

('Vampire Fangs',
'
+15% Lifesteal.
+8% Spell lifesteal.
+250 Night vision.
','Tier 2',1560),

('Craggy Coat',
'
+13 Armor.
-35 Attack speed.
','Tier 3',3700),

('Greater Faerie Fire',
'
Instantly restores 500 health.
Health Restored: 500.
Cooldown: 10.
+30 Attack damage.
','Tier 3',3500),

('Mind Breaker',
'
The next attack silences the hit enemy for 2 seconds.
Duration: 2.
Cooldown: 20.
+25 Attack speed.
+25 Attack damage.
','Tier 3',3200),

('Paladin Sword',
'
+17% Health regen amplification.
+17% Lifesteal amplification.
+17 Attack damage.
+17% Lifesteal.
','Tier 3',3460),

('Repair Kit',
'
Targets a building, restoring 40% of its health over 30 seconds. Also grants +10 armor and +4 Multishot attack during this period.
Default Cast Range: 600.
Buffer Cast Range: 850.
Total Health Restored: 40%.
Armor Bonus: 10.
Bonus Attack Targets: 4.
Duration: 30.
Cooldown: 0.
+13 Health regeneration.
','Tier 3',3400),

('Telescope',
'
Lowers Scan cooldown by 50%. Increases attack and cast range of allies in a 1200 unit radius.
Radius: 1200.
Scan Cooldown Reduction: 50%.
Attack Range Bonus (Ranged): 125.
Cast Range Bonus: 125.
Aura Linger Duration: 0.5.
','Tier 3',3200),

('Enchanted Quiver',
'
Empowers your next Ranged Attack with +400 bonus range, 225 bonus magical damage and True Strike.
Attack Range Bonus: 400.
Damage: 225.
Cooldown: 8.
Partially usable by illusions. Illusions do not apply the damage, but get the extra range and True Strike.
','Tier 3',3100),

('Helm of the Undying',
'
Survive for extra 5 seconds after receiving a killing blow.
Duration: 5.
Cooldown: 0.
+6 Armor.
','Tier 3',3000),

('Orb of Destruction',
'
Attacks reduce the targets armor and movement speed. Slow amount varies based on whether the wearer is melee or ranged.
Move Speed Slow (Melee): 30%.
Move Speed Slow (Ranged): 15%.
Armor Reduction: 6.
Duration: 4.
','Tier 3',3220),

('Quickening Charm',
'
Reduces the cooldown time of all spells and items by 13%.
Cooldown Reduction: 13%.
+9 Health regeneration.
','Tier 3',3600),

('Spider Legs',
'
Grants you 24 movement speed and free pathing for 3 seconds. Walking over trees causes them to be destroyed.
Move Speed Bonus: 24.
Duration: 3.
Cooldown: 10.
+24% Movement speed.
+30% Turn rate.
','Tier 3',3400),

('Titan Sliver',
'
+16% Base attack damage.
+16% Magic resistance.
+16% Status resistance.
','Tier 3',3900),

('Flicker',
'
Dispells debuffs and blinks you to a random spot within 600 range. Does not get disabled on incoming damage.
Blink Range: 600.
Cooldown: 5.
Mana: 25.
','Tier 4',4200),

('Illusionists Cape',
'
Creates an image under your control.
Number of Illusions: 1.
Illusion Damage Dealt: 50%.
Illusion Damage Taken: 150%.
Duration: 20.
Cooldown: 30.
+10 Strength.
+10 Agility.
','Tier 4',4300),

('Minotaur Horn',
'
Grants Spell Immunity for 1.75 seconds.
Duration: 1.75.
Cooldown: 32.
+20 Strength.
','Tier 4',4900),

('Princes Knife',
'
The next attack hexes the hit enemy into a frog for 1.5 seconds.
Set Movement Speed: 140.
Duration: 1.5.
Cooldown: 12.
+60 Projectile speed.
','Tier 4',4590),

('The Leveller',
'
+50 Attack speed.
+25% Attack damage.
','Tier 4',4800),

('Witless Shako',
'
+1000 Health.
-400 Mana.
','Tier 4',4300),

('Havoc Hammer',
'
Knocks back enemies in 300 range in front of you, slowing them by 50% for 3 seconds.
Radius: 300.
Knockback Distance: 250.
Movement Speed Slow: 50%.
Knockback Duration: 0.3.
Slow Duration: 3.
Cooldown: 10.
+18 Strength.
+35 Attack damage.
','Tier 4',4100),

('Magic Lamp',
'
When the wearers health falls below 15% they will receive a hard dispel and be healed for 300 health.
Health Threshold: 15%.
Heal: 300.
Cooldown: 60.
+400 Health.
','Tier 4',4010),

('Ninja Gear',
'
Casts Smoke of Deceit on yourself only.
Dispel Radius: 1025.
Fade Time: 0.
Move Speed Bonus: 15%.
Duration: 35.
Cooldown: 45.
+20 Agility.
+30 Movement speed.
','Tier 4',4400),

('Spell Prism',
'
Reduces the cooldown time of all spells and items by 20%.
Cooldown Reduction: 20%.
+12 Strength
+12 Agility.
+12 Intelligence.
+4 Mana regeneration.
','Tier 4',4500),

('Timeless Relic',
'
+25% Debuff duration.
+15% Spell damage.
','Tier 4',4990),

('Apex',
'
+80% Primary attribute.
','Tier 5',5500),

('Book of the Dead',
'
Summons 6 level 3 Necronomicon Units that last 75 seconds.
Number of Warriors: 3.
Number of Archers: 3.
Duration: 75.
Cooldown: 90.
+35 Strength.
+35 Intelligence.
','Tier 5',5600),

('Force Boots',
'
Dispels the user and pushes them 800 units in the direction they are facing.
Push Distance: 800.
Push Duration: 0.65.
Cooldown: 6Mana: 75.
+50% Movement speed.
','Tier 5',5100),

('Mirror Shield',
'
Block and reflect most targeted spells back to their caster every once every 4 seconds.
Cooldown: 4.
+20 Strength.
+20 Agility.
+20 Intelligence.
','Tier 5',5240),

('Pirate Hat',
'
Creates a bounty rune between you and your victim when you kill an enemy hero.
Can be used by illusions. If an illusion makes the kill, the rune is created between the illusion and the killed hero.
+250 Attack speed.
','Tier 5',5400),

('Stygian Desolator',
'
Your attacks reduce the targets armor by 12 for 15 seconds.
Armor Reduction: 12.
Duration: 15.
+100 Attack damage.
','Tier 5',5800),

('Fallen Sky',
'
Transforms into a meteor that strikes down at the target area after 0.5 seconds in a 315 AoE, stunning enemies for 2 seconds and dealing impact damage. Continues to deal damage every 1 seconds to enemy units and buildings for 6 seconds.
Cast Range: 1600.
Impact Radius: 315.
Effect Delay: 0.5.
Impact Damage (Units): 150.
Impact Damage (Buildings): 75.
Damage per Second (Units): 90.
Damage per Second (Buildings): 50.
Burn Duration: 6.
Stun Duration: 2.
Cooldown: 15.
+20 Strength.
+20 Intelligence.
+15 Health regeneration.
+10 Mana regeneration.
','Tier 5',5900),

('Ballista',
'
Knocks enemies back with every attack.
Knockback Distance: 50.
Knockback Duration: 0.2.
+400 Attack range (ranged).
','Tier 5',5990),

('Ex Machina',
'
Reset the cooldowns on all items (except Refresher Orb).
Cooldown: 30.
+25 Armor.
','Tier 5',5100),

('Fusion Rune',
'
Grants the target the bonuses of every Power Rune for 50 seconds. Each use consumes a charge.
Default Cast Range: 250.
Buffer Cast Range: 500.
Cooldown Reduction: 30%.
Mana Loss Reduction: 30%.
Attack Damage Bonus: 100%.
Haste Speed: 550.
Number of Illusions: 2.
Illusion Damage Dealt: 35%.
Illusion Damage Taken (Melee): 200%.
Illusion Damage Taken (Ranged): 300%.
Fade Time: 2.
Max Health as Regeneration per Second: 6%.
Max Mana as Regeneration per Second: 6%.
Duration: 50.
Cooldown: 120.
','Tier 5',5600),

('Phoenix Ash',
'
Lethal damage is prevented and instead the wearer is healed to half health and non-ultimate ability cooldowns reset. Gets consumed on trigger.
Max Health Restore: 50%.
','Tier 5',5800),

('Seer Stone',
'
+450 Cast range.
+450 vision.
','Tier 5',5000),

('Woodland Striders',
'
Create a path of trees behind you for 3 seconds. Trees last up to 60 seconds.
Duration: 3.
Tree Duration: 60.
Cooldown: 20.
+70 Health regeneration.
+50% Movement speed.
','Tier 5',5600),

('Trident',
'
+33 Strength.
+33 Agility.
+33 Intelligence.
+33% Health regen amplification.
+33% Lifesteal amplification.
+33 Attack speed.
+33% Spell damage.
+33% Status resistance.
+33% Mana loss reduction.
+33 Movement speed.
','Tier 5',5010);




