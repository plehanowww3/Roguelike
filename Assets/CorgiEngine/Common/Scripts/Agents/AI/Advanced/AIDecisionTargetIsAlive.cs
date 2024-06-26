﻿using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// This decision will return true if the Brain's current target is alive
	/// </summary>
	[AddComponentMenu("Corgi Engine/Character/AI/Decisions/AI Decision Target is Alive")]
	// [RequireComponent(typeof(Character))]
	public class AIDecisionTargetIsAlive : AIDecision
	{
		protected Character _character;
        
		/// <summary>
		/// On Decide we check whether the Target is alive or not
		/// </summary>
		/// <returns></returns>
		public override bool Decide()
		{
			return CheckIfTargetIsAlive();
		}

		/// <summary>
		/// Returns true if the Brain's Target is alive (this will require that the Target has a Character component)
		/// </summary>
		/// <returns></returns>
		protected virtual bool CheckIfTargetIsAlive()
		{
			if (_brain.Target == null)
			{
				return false;
			}

			_character = _brain.Target.gameObject.MMGetComponentNoAlloc<Character>();

			if (_character == null)
			{
				_character = _brain.Target.gameObject.GetComponentInParent<Character>();
			}
			
			if (_character != null)
			{
				if (_character.ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead)
				{
					return false;
				}
				else
				{ 
					return true;
				}
			}            

			return false;
		}
	}
}