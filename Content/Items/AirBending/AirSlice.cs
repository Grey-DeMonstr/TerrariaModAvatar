using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AvatarTheLastAirbender.Content.Items.AirBending
{
	public class AirSlice : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.damage = 10;
			Item.knockBack = 4.5f;
			Item.width = 40;
			Item.height = 40;
			Item.scale = 0.3f;
			Item.UseSound = SoundID.Item1;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(gold: 23); // Sell price is 5 times less than the buy price.
			Item.DamageType = DamageClass.Melee;
			Item.shoot = ProjectileID.RainCloudMoving;
			Item.noMelee = true; // This is set the sword itself doesn't deal damage (only the projectile does).
			Item.shootsEveryUse = true; // This makes sure Player.ItemAnimationJustStarted is set when swinging.
			Item.autoReuse = true;
		}

		public override bool Shoot(
			Player player,
			EntitySource_ItemUse_WithAmmo source,
			Vector2 position,
			Vector2 velocity,
			int type,
			int damage,
			float knockback)
		{
			// Get the melee scale of the player and item.
			float adjustedItemScale = player.GetAdjustedItemScale(Item);
			Projectile.NewProjectile(
				source,
				player.MountedCenter,
				new Vector2(player.direction, 0f),
				type,
				damage,
				knockback,
				player.whoAmI,
				player.direction * player.gravDir,
				player.itemAnimationMax,
				adjustedItemScale);

			// Sync the changes in multiplayer.
			NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
