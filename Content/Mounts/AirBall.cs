using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AvatarTheLastAirbender.Content.Mounts
{
    public class AirBall: ModMount
	{
		public override void SetStaticDefaults()
		{
			// Movement
			MountData.jumpHeight = 5; // How high the mount can jump.
			MountData.acceleration = 0.19f; // The rate at which the mount speeds up.
			MountData.jumpSpeed = 4f; // The rate at which the player and mount ascend towards (negative y velocity) the jump height when the jump button is pressed.
			MountData.blockExtraJumps = false; // Determines whether or not you can use a double jump (like cloud in a bottle) while in the mount.
			MountData.constantJump = true; // Allows you to hold the jump button down.
			MountData.heightBoost = 0; // Height between the mount and the ground
			MountData.fallDamage = 0.5f; // Fall damage multiplier.
			MountData.runSpeed = 11f; // The speed of the mount
			MountData.dashSpeed = 8f; // The speed the mount moves when in the state of dashing.
            MountData.flightTimeMax = 180; // The amount of time in frames a mount can be in the state of flying.

            // Misc
			MountData.fatigueMax = 0;
			// The ID number of the buff assigned to the mount.
			MountData.buff = ModContent.BuffType<Buffs.AirBallMountBuff>();

			// Effects
			// MountData.spawnDust = ModContent.DustType<Dusts.Sparkle>(); // The ID of the dust spawned when mounted or dismounted.

			// Frame data and player offsets
			MountData.totalFrames = 4; // Amount of animation frames for the mount

			// Fills an array with values for less repeating code
			var playerYOffsets = Enumerable.Repeat(20, MountData.totalFrames).ToArray();
			playerYOffsets[1] += 2;
			playerYOffsets[3] -= 2;
			MountData.playerYOffsets = playerYOffsets;

			MountData.xOffset = 16;
			MountData.yOffset = 0;
			MountData.playerHeadOffset = 22;
			MountData.bodyFrame = 3;
			// Standing
			MountData.standingFrameCount = 4;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			// Running
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 12;
			MountData.runningFrameStart = 0;
			// Flying
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			// In-air
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			// Idle
			MountData.idleFrameCount = 4;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			// Swim
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;

			if (!Main.dedServ) {
				MountData.textureWidth = MountData.backTexture.Width() + 20;
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}
	}
}
