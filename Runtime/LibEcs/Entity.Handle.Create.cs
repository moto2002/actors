using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Pixeye.Framework
{
	[Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks | Option.DivideByZeroChecks, false)]
	public static partial class Entity
	{
		public static ent Create()
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;


			Initialize(id, age);
			return new ent(id, age);
		}
		public static ent Create(ModelComposer model)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age);

			model(entity);
			EntityOperations.Set(entity, 0, EntityOperations.Action.Activate);

			return entity;
		}
		
		public static ent Create(string prefabID, Vector3 position = default, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefabID, position) : Obj.Spawn(prefabID, position);
			return new ent(id, age);
		}
		public static ent Create(string prefabID, ModelComposer model, Vector3 position = default, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefabID, position) : Obj.Spawn(prefabID, position);
			model(entity);
			EntityOperations.Set(entity, 0, EntityOperations.Action.Activate);

			return entity;
		}

		public static ent Create(GameObject prefab, Vector3 position = default, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;


			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefab, position) : Obj.Spawn(prefab, position);

			return new ent(id, age);
		}
		public static ent Create(GameObject prefab, ModelComposer model, Vector3 position = default, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefab, position) : Obj.Spawn(prefab, position);
			model(entity);
			EntityOperations.Set(entity, 0, EntityOperations.Action.Activate);

			return entity;
		}

		public static ent CreateFor(GameObject prefab, ModelComposer model, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age, pooled);
			transforms[id] = prefab.transform;
			model(entity);
			EntityOperations.Set(entity, 0, EntityOperations.Action.Activate);
			return entity;
		}
		public static ent CreateFor(GameObject obj, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop    = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			Initialize(id, age, pooled);
			transforms[id] = obj.transform;
			return new ent(id, age);
		}

		//===============================//
		// Blueprints
		//===============================//
		 #if ODIN_INSPECTOR
	 
		public static ent Create(BlueprintEntity bpAsset)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age);
			bpAsset.Execute(entity);
			return entity;
		}

		public static ent Create(string prefabID, BlueprintEntity bpAsset, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefabID) : Obj.Spawn(prefabID);
			bpAsset.Execute(entity);
			return entity;
		}

		public static ent Create(GameObject prefab, BlueprintEntity bpAsset, bool pooled = false)
		{
			int  id;
			byte age = 0;

			if (ent.entityStackLength > 0)
			{
				var  pop = ent.entityStack.Dequeue();
				byte ageOld = pop.age;
				id = pop.id;
				unchecked
				{
					age = (byte) (ageOld + 1);
				}

				ent.entityStackLength--;
			}
			else
				id = ent.lastID++;

			var entity = new ent(id, age);
			Initialize(id, age, pooled);
			transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefab) : Obj.Spawn(prefab);
			bpAsset.Execute(entity);
			return entity;
		}
		#endif
	}
}