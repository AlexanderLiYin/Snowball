using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opsive.UltimateInventorySystem.Equipping
{
    using Opsive.Shared.Game;
    using Opsive.UltimateInventorySystem.Core;
    using Opsive.UltimateInventorySystem.Core.DataStructures;
    using Opsive.UltimateInventorySystem.Core.InventoryCollections;
    using Opsive.UltimateInventorySystem.Storage;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using EventHandler = Opsive.Shared.Events.EventHandler;

    /// <summary>
    /// The Equipper component is used to equip items by converting them to ItemObjects.
    /// </summary>
    public class NewEquipper : MonoBehaviour, IDatabaseSwitcher
    {
        [Tooltip("The equippers inventory.")]
        [SerializeField] protected Inventory m_Inventory;
        [Tooltip("The equippers itemCollection within the inventory.")]
        [SerializeField]
        protected ItemCollectionID m_EquipmentItemCollectionID =
            new ItemCollectionID("Equipped", ItemCollectionPurpose.Equipped);
        [Tooltip("The attribute name fo the equipment prefab (visual).")]
        [SerializeField] protected string m_EquipablePrefabAttributeName = "EquipmentPrefab";
        [Tooltip("The attribute name fo the usable item prefab (functional).")]
        [SerializeField] protected string m_UsableItemPrefabAttributeName = "UsableItemPrefab";
        [Tooltip("The item slot set used to restruct the items that can be equipped.")]
        [SerializeField] protected ItemSlotSet m_ItemSlotSet;
        [Tooltip("The item object slots which holds the equipped item.")]
        [SerializeField] protected ItemObjectSlot[] m_Slots;

        protected ItemSlotCollection m_EquipmentItemCollection;
        public SnowPrincess player;

        /// <summary>
        /// Initialize the Equiper.
        /// </summary>
        protected virtual void Start()
        {
            //If inventory is null, find inventory component
            if (m_Inventory == null) { m_Inventory = GetComponent<Inventory>(); }

            //If conversion of inventory into item slot collection has failed, print out error
            m_EquipmentItemCollection = m_Inventory.GetItemCollection(m_EquipmentItemCollectionID) as ItemSlotCollection;
            if (m_EquipmentItemCollection == null)
            {
                Debug.LogWarning("Your inventory does not have an equipment Item Collection.");
                return;
            }

            //Register Events(Add a listener functions On added Item To Inventory and On Removed Item From Inventory)
            EventHandler.RegisterEvent<ItemInfo, ItemStack>(m_Inventory, EventNames.c_Inventory_OnAdd_ItemInfo_ItemStack, OnAddedItemToInventory);
            EventHandler.RegisterEvent<ItemInfo>(m_Inventory, EventNames.c_Inventory_OnRemove_ItemInfo, OnRemovedItemFromInventory);

            var equipmentItemAmounts = m_EquipmentItemCollection.GetAllItemStacks();
            if (equipmentItemAmounts == null)
            {
                Debug.LogWarning("The Equipment Item Collection is null.");
                return;
            }
            for (int i = 0; i < equipmentItemAmounts.Count; i++)
            {
                Equip(equipmentItemAmounts[i].Item);
            }
        }

        /// <summary>
        /// Make sure to unregister the listener on Destroy.
        /// </summary>
        private void OnDestroy()
        {
            EventHandler.UnregisterEvent<ItemInfo, ItemStack>(m_Inventory, EventNames.c_Inventory_OnAdd_ItemInfo_ItemStack, OnAddedItemToInventory);
            EventHandler.UnregisterEvent<ItemInfo>(m_Inventory, EventNames.c_Inventory_OnRemove_ItemInfo, OnRemovedItemFromInventory);
        }

        /// <summary>
        /// Equip item that was added to the equipment collection.
        /// </summary>
        /// <param name="originItemInfo">The origin Item info.</param>
        /// /// <param name="addedItemStack">The added item stack.</param>
        private void OnAddedItemToInventory(ItemInfo originItemInfo, ItemStack addedItemStack)
        {
            if (addedItemStack == null) { return; }
            if (addedItemStack.ItemCollection == m_EquipmentItemCollection)
            {
                var index = m_EquipmentItemCollection.GetItemSlotIndex(addedItemStack);
                Equip(addedItemStack.Item, index);
            }
        }

        /// <summary>
        /// Unequip an item that was removed from the equipment collection.
        /// </summary>
        /// <param name="removedItemInfo">The removed Item info.</param>
        private void OnRemovedItemFromInventory(ItemInfo removedItemInfo)
        {
            if (removedItemInfo.ItemCollection == m_EquipmentItemCollection)
            {
                UnEquip(removedItemInfo.Item);
            }
        }

        /// <summary>
        /// Equip an item.
        /// </summary>
        /// <param name="item">The item to equip.</param>
        /// <returns>Return true only if the item equipped successfully.</returns>
        public virtual bool Equip(Item item)
        {
            /*
            //Check for available empty slots.
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject != null) { continue; }
                if (m_Slots[i].Category != null && m_Slots[i].Category.InherentlyContains(item) == false) { continue; }

                return Equip(item, i);
            }

            //Check for any slot (even used ones).
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].Category != null && m_Slots[i].Category.InherentlyContains(item) == false) { continue; }

                return Equip(item, i);
            }

            return false;
            */

            /*
            // Change an attribute value on the sword item
            if (item.TryGetAttributeValue<int>("Attack", out var intAttributeValue))
            {
                print("Equipping item");
                player.attack += intAttributeValue;
            }
            else
                print("Equip failed");
            */
            return true;
        }

        /// <summary>
        /// Equip an item to a specific slot.
        /// </summary>
        /// <param name="item">The item to equip.</param>
        /// <param name="index">The slot to equip to.</param>
        /// <returns>True if equipped successfully.</returns>
        public virtual bool Equip(Item item, int index)
        {
            /*
            var slot = m_Slots[index];

            if (slot.Category != null && slot.Category.InherentlyContains(item) == false) { return false; }
            var itemObject = CreateItemObject(item);

            slot.SetItemObject(itemObject);
            */
            //Like the equipe function above, I don't need slots but I think I need the event handler to execute the event so I'll keep that.
            EventHandler.ExecuteEvent(this, EventNames.c_Equipper_OnChange);
            if (item.TryGetAttributeValue<int>("Attack", out var intAttributeValue))
            {
                player.attack += intAttributeValue;
                return true;
            }
            else
            {
                print("Equip failed");
                return false;
            }
        }

        /// <summary>
        /// Get the Equipment stats by retrieving the total value of the attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The total amount for the attribute.</returns>
        public virtual int GetEquipmentStatInt(string attributeName)
        {
            return (int)GetEquipmentStatFloat(attributeName);
        }

        /// <summary>
        /// Get the Equipment stats by retrieving the total value of the attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The total amount for the attribute.</returns>
        public virtual float GetEquipmentStatFloat(string attributeName)
        {
            var stat = 0f;
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject == null) { continue; }
                var item = m_Slots[i].ItemObject.Item;

                if (item.TryGetAttributeValue<int>(attributeName, out var intAttributeValue))
                {
                    stat += intAttributeValue;
                }
                if (item.TryGetAttributeValue<float>(attributeName, out var floatAttributeValue))
                {
                    stat += floatAttributeValue;
                }
            }

            return stat;
        }

        /// <summary>
        /// Get a preview stat total by simulating adding a new item.
        /// </summary>
        /// <param name="attributeName">The attribute.</param>
        /// <param name="itemPreview">The item to preview.</param>
        /// <returns>The total attribute value.</returns>
        public int GetEquipmentStatPreviewAdd(string attributeName, Item itemPreview)
        {
            var stat = 0f;
            for (int i = 0; i < m_Slots.Length; i++)
            {

                Item item = null;

                if (itemPreview == null)
                {
                    if (m_Slots[i].ItemObject == null) { continue; }
                    item = m_Slots[i].ItemObject.Item;
                }
                else if (m_Slots[i].Category.InherentlyContains(itemPreview.Category))
                {
                    item = itemPreview;
                }
                else
                {
                    if (m_Slots[i].ItemObject == null) { continue; }
                    item = m_Slots[i].ItemObject.Item;
                }

                if (item.TryGetAttributeValue<int>(attributeName, out var intAttributeValue))
                {
                    stat += intAttributeValue;
                }
                if (item.TryGetAttributeValue<float>(attributeName, out var floatAttributeValue))
                {
                    stat += floatAttributeValue;
                }
            }

            return (int)stat;
        }

        /// <summary>
        /// Preview the attribute stat by simulating removing an item.
        /// </summary>
        /// <param name="attributeName">The attribute.</param>
        /// <param name="itemPreview">The item to preview remove.</param>
        /// <returns>The total attribute value.</returns>
        public int GetEquipmentStatPreviewRemove(string attributeName, Item itemPreview)
        {
            var stat = 0f;
            for (int i = 0; i < m_Slots.Length; i++)
            {

                if (m_Slots[i].ItemObject == null) { continue; }
                var item = m_Slots[i].ItemObject.Item;
                if (item == itemPreview) { continue; }

                if (item.TryGetAttributeValue<int>(attributeName, out var intAttributeValue))
                {
                    stat += intAttributeValue;
                }
                if (item.TryGetAttributeValue<float>(attributeName, out var floatAttributeValue))
                {
                    stat += floatAttributeValue;
                }
            }

            return (int)stat;
        }

        /// <summary>
        /// UnEquip an item.
        /// </summary>
        /// <param name="item">The item to unequip.</param>
        public virtual void UnEquip(Item item)
        {
            /*
            for (int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].ItemObject == null || m_Slots[i].ItemObject.Item != item) { continue; }

                UnEquip(i);
                return;
            }*/

            if (item.TryGetAttributeValue<int>("Attack", out var intAttributeValue))
            {
                player.attack -= intAttributeValue;
            }
            else
            {
                print("Unequip failed");
            }
        }

        /// <summary>
        /// UnEquip the item at the slot.
        /// </summary>
        /// <param name="index">The slot.</param>
        public virtual void UnEquip(int index)
        {
            /*
            var itemObject = m_Slots[index].ItemObject;

            m_Slots[index].SetItemObject(null);

            if (ObjectPoolBase.IsPooledObject(itemObject.gameObject))
            {
                ReturnItemObjectToPool(itemObject);
            }
            else
            {
                Destroy(itemObject.gameObject);
            }
            */
            //Like previously, I'm not using any item objects but I'm quite confident that the unequip function is necessary.
            EventHandler.ExecuteEvent(this, EventNames.c_Equipper_OnChange);
        }

        /// <summary>
        /// Check if the object contained by this component are part of the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>True if all the objects in the component are part of that database.</returns>
        bool IDatabaseSwitcher.IsComponentValidForDatabase(InventorySystemDatabase database)
        {
            if (database == null) { return false; }

            return (m_ItemSlotSet as IDatabaseSwitcher)?.IsComponentValidForDatabase(database) ?? true;
        }

        /// <summary>
        /// Replace any object that is not in the database by an equivalent object in the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>The objects that have been changed.</returns>
        ModifiedObjectWithDatabaseObjects IDatabaseSwitcher.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(InventorySystemDatabase database)
        {
            if (database == null) { return null; }

            (m_ItemSlotSet as IDatabaseSwitcher)?.ReplaceInventoryObjectsBySelectedDatabaseEquivalents(database);

            return new UnityEngine.Object[] { m_ItemSlotSet };
        }
    }
}


