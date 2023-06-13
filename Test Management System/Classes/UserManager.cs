using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Management_System.Entities;

namespace Test_Management_System.Classes
{
    public class UserManager
    {
        private ObservableCollection<string> usersInProjectList;
        private ObservableCollection<string> usersNotInProjectList;

        Testing_ToolEntity db = new Testing_ToolEntity();

        int projectID;
        public UserManager()
        {
            usersInProjectList = new ObservableCollection<string>();
            usersNotInProjectList = new ObservableCollection<string>();
        }

        public void LoadUsersInProject(int projectID)
        {
            this.projectID = projectID;
            usersInProjectList.Clear();

            var names = db.ProjectUser
                .Where(uip => uip.ProjectID == projectID)
                .Join(db.Userinfo, uip => uip.UserID, ui => ui.UserID, (uip, ui) => ui.LastName + " " + ui.FirstName)
                .ToList();

            foreach (var name in names)
            {
                usersInProjectList.Add(name);
            }
        }

        public void LoadUsersNotInProject(int projectID)
        {
            usersNotInProjectList.Clear();

            var namesNotInProject = db.Userinfo
                .Where(u => !db.ProjectUser.Any(uip => uip.UserID == u.UserID && uip.ProjectID == projectID))
                .Select(u => u.LastName + " " + u.FirstName)
                .ToList();

            foreach (var name in namesNotInProject)
            {
                usersNotInProjectList.Add(name);
            }
        }

        public void AddUserToProject(string user)
        {
            usersInProjectList.Add(user);
            usersNotInProjectList.Remove(user);

            var userInfo = user.Split(' ');
            var lastName = userInfo[0];
            var firstName = userInfo[1];

            var userToAdd = db.Userinfo.Where(x => x.RoleID == 3).FirstOrDefault(u => u.LastName == lastName && u.FirstName == firstName);
            if (userToAdd != null)
            {
                var projectUser = new ProjectUser
                {
                    ProjectID = projectID,
                    UserID = userToAdd.UserID
                };
                db.ProjectUser.Add(projectUser);
                db.SaveChanges();
            }
        }

        public void RemoveUserFromProject(string user)
        {
            usersInProjectList.Remove(user);
            usersNotInProjectList.Add(user);

            var userInfo = user.Split(' ');
            var lastName = userInfo[0];
            var firstName = userInfo[1];

            var userToRemove = db.Userinfo.Where(x=>x.RoleID == 3).FirstOrDefault(u => u.LastName == lastName && u.FirstName == firstName);
            if (userToRemove != null)
            {
                var projectUser = db.ProjectUser.FirstOrDefault(uip => uip.ProjectID == projectID && uip.UserID == userToRemove.UserID);
                if (projectUser != null)
                {
                    db.ProjectUser.Remove(projectUser);
                    db.SaveChanges();
                }
            }
        }

        public ObservableCollection<string> GetUsersInProject()
        {
            return usersInProjectList;
        }

        public ObservableCollection<string> GetUsersNotInProject()
        {
            return usersNotInProjectList;
        }

    }
}
