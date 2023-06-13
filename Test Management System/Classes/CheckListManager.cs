using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Management_System.Entities;

namespace Test_Management_System.Classes
{
    public class CheckListManager
    {
        private ObservableCollection<CheckListItem> allChecklistItems;

        Testing_ToolEntity db = new Testing_ToolEntity();
        public ObservableCollection<CheckListItem> AllChecklistItems
        {
            get { return allChecklistItems; }
            set { allChecklistItems = value; }
        }
        private int checkListID;
        public CheckListManager(int checkListID)
        {
            allChecklistItems = new ObservableCollection<CheckListItem>();
            this.checkListID = checkListID;
        }

        public void LoadExistingChecklistItems()
        {
            List<CheckListItem> existingItems = db.CheckListItem.Where(x=>x.CheckListID == checkListID).ToList();
            allChecklistItems.Clear();
            foreach (var item in existingItems)
            {
                //item.CLPriorityID = item.CheckListPriority?.CLPriorityID;
                //item.CLStatusID = item.CheckListStatus.CLStatusID;
                allChecklistItems.Add(item);
            }
        }

        public void AddNewChecklistItem(CheckListItem newItem)
        {
            allChecklistItems.Add(newItem);
            db.CheckListItem.Add(newItem);
            db.SaveChanges();
            LoadExistingChecklistItems();
        }

        public void DeleteChecklistItem(CheckListItem item)
        {
            allChecklistItems.Remove(item);
            db.CheckListItem.Remove(item);
            db.SaveChanges();
        }
    }
}
