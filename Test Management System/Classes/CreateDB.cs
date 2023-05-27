/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Management_System.Classes
{
    internal class CreateDB
    {
        public string connString { get; set; }
        public MySqlConnection conn { get; set; }

        public string name { get; set; }

        public CreateDB()
        {
            connString = "server=localhost;user=root;port=3306;password=;";
            conn = new MySqlConnection(connString);
            name = "Testing_Tool";
        }

        public void CreateOnlyDB()
        {
            conn.Open();
            string creatingDB = "CREATE DATABASE IF NOT EXISTS " + name + " ;";
            MySqlCommand cmd = new MySqlCommand(creatingDB, conn);
            cmd.ExecuteNonQuery();
        }

        public void CreateReferenceTablesInDB()
        {
            // Таблица стран
            string createCountryTable = "use " + name + "; create table if not exists Country(" +
                "CountryID int not null, " +
                "CountryName varchar(50) not null, " +
                "CountryNameTranslation varchar(50) not null, " +
                "primary key (CountryID)); ";
            MySqlCommand CreateCountryTable = new MySqlCommand(createCountryTable, conn);
            CreateCountryTable.ExecuteNonQuery();

            // Таблица вариантов количества пользователей в команде
            string createAmountOfUsersTable = "use " + name + "; create table if not exists AmountOfUsers(" +
                "AmountID int not null, " +
                "AmountLowerBound int not null, " +
                "AmountUpperBound int not null, " +
                "primary key (AmountID)); ";
            MySqlCommand CreateAmountOfUsersTable = new MySqlCommand(createAmountOfUsersTable, conn);
            CreateAmountOfUsersTable.ExecuteNonQuery();

            // Таблица компаний
            string createCompanyTable = "use " + name + "; create table if not exists Company(" +
                "CompanyID int not null, " +
                "CompanyName varchar(255) not null, " +
                "CompanyLabel varchar(10) not null, " +
                "CountryID int not null," +
                "AmountID int not null, " +
                "primary key (CompanyID), " +
                "unique (CompanyLabel), " +
                "foreign key (CountryID) references Country (CountryID)," +
                "foreign key (AmountID) references AmountOfUsers (AmountID)); ";
            MySqlCommand CreateCompanyTable = new MySqlCommand(createCompanyTable, conn);
            CreateCompanyTable.ExecuteNonQuery();

            // Таблица ролей
            string createRoleTable = "use " + name + "; create table if not exists Role(" +
                "RoleID int not null, " +
                "RoleName varchar(15) not null, " +
                "RoleNameTranslation varchar(15) not null, " +
                "primary key (RoleID)); ";
            MySqlCommand CreateRoleTable = new MySqlCommand(createRoleTable, conn);
            CreateRoleTable.ExecuteNonQuery();

            // Таблица критичности бага
            string createBugSeverityTable = "use " + name + "; create table if not exists BugSeverity " +
                "(BugSeverityID int not null, " +
                "BugSeverityName varchar(20) not null, " +
                "BugSeverityNameTranslation varchar(20) not null," +
                "primary key (BugSeverityID));";
            MySqlCommand СreateBRSeverityTable = new MySqlCommand(createBugSeverityTable, conn);
            СreateBRSeverityTable.ExecuteNonQuery();

            // Приоритет бага
            string createBugPriorityTable = "use " + name + "; create table if not exists BugPriority " +
                "(BugPriorityID int not null, " +
                "BugPriorityName varchar(20) not null," +
                "BugPriorityNameTranslation varchar(20) not null," +
                "primary key (BugPriorityID));";
            MySqlCommand СreateBRPriorityTable = new MySqlCommand(createBugPriorityTable, conn);
            СreateBRPriorityTable.ExecuteNonQuery();

            // Статус баг-репорта
            string createBRStatusTable = "use " + name + "; create table if not exists BugReportStatus " +
                "(BRStatusID int not null, " +
                "BRStatusName varchar(20) not null," +
                "BRStatusNameTranslation varchar(20) not null," +
                "primary key (BRStatusID)); ";
            MySqlCommand СreateBRStatusTable = new MySqlCommand(createBRStatusTable, conn);
            СreateBRStatusTable.ExecuteNonQuery();

            // Статус чек-листа
            string createCLStatusTable = "use " + name + "; create table if not exists CheckListStatus " +
               "(CLStatusID int not null, " +
               "CLStatusDescription varchar(20) not null," +
               "CLStatusDescriptionTranslation varchar(20) not null," +
               "primary key(CLStatusID)); ";
            MySqlCommand СreateCLStatusTable = new MySqlCommand(createCLStatusTable, conn);
            СreateCLStatusTable.ExecuteNonQuery();

            // Приоритет чек-листа
            string createCLPriorityTable = "use " + name + "; create table if not exists CheckListPriority " +
               "(CLPriorityID int not null, " +
               "CLPriorityDescription varchar(20) not null," +
               "CLPriorityDescriptionTranslation varchar(20) not null," +
               "primary key(CLPriorityID)); ";
            MySqlCommand CreateCLPriorityTable = new MySqlCommand(createCLPriorityTable, conn);
            CreateCLPriorityTable.ExecuteNonQuery();

            // Приоритет тест-кейсов
            string createTCPriorityTable = " use " + name + "; create table if not exists TestCasePriority " +
                "(TCPriorityID int not null, " +
                "TCPriorityDescription varchar(20) not null, " +
                "TCPriorityDescriptionTranslation nvarchar(20) not null," +
                "primary key (TCPriorityID)); ";
            MySqlCommand СreateTCPriorityTable = new MySqlCommand(createTCPriorityTable, conn);
            СreateTCPriorityTable.ExecuteNonQuery();

            // Критичность тест-кейсов
            string createTCSeverityTable = " use " + name + "; create table if not exists TestCaseSeverity " +
                "(TCSeverityID int not null, " +
                "TCSeverityDescription varchar(20) not null, " +
                "TCSeverityDescriptionTranslation nvarchar(20) not null," +
                "primary key (TCSeverityID)); ";
            MySqlCommand СreateTCSeverityTable = new MySqlCommand(createTCSeverityTable, conn);
            СreateTCSeverityTable.ExecuteNonQuery();

            // Вид тест-кейсов
            string createTCViewTable = "use " + name + "; create table if not exists TestCaseType " +
                "(TCTypeID int not null, " +
                "TCTypeDescription varchar(100) not null," +
                "TCTypeDescriptionTranlation nvarchar(100) not null, " +
                "primary key (TCTypeID)  ); ";
            MySqlCommand CreateTCViewTable = new MySqlCommand(createTCViewTable, conn);
            CreateTCViewTable.ExecuteNonQuery();

            // Поведение тест-кейса
            string createTCBehaviorTable = "use " + name + "; create table if not exists TestCaseBehavior " +
                "(TCBehaviorID int not null, " +
                "TCBehaviorDescription varchar(100) not null," +
                "TCBehaviorDescriptionTranlation nvarchar(100) not null, " +
                "primary key (TCBehaviorID)  ); ";
            MySqlCommand CreateTCBehaviorTable = new MySqlCommand(createTCBehaviorTable, conn);
            CreateTCBehaviorTable.ExecuteNonQuery();

            //Статус тест-кейса
            string createTCStatusTable = "use " + name + "; create table if not exists TestCaseStatus " +
                "(TCStatusID int not null, " +
                "TCStatusDescription varchar(100) not null," +
                "TCStatusDescriptionTranlation nvarchar(100) not null, " +
                "primary key (TCStatusID)); ";
            MySqlCommand CreateTCStatusTable = new MySqlCommand(createTCStatusTable, conn);
            CreateTCStatusTable.ExecuteNonQuery();




            // Приоритет тест-сьюта
            string createTSPriorityTable = "use " + name + "; create table TestSuitePriority " +
                "(TSPriorityID int not null, " +
                "TSPriorityDescription nvarchar(20) not null, " +
                "TSPriorityTranslation nvarchar(20) not null," +
                "primary key (TSPriorityID)); ";
            MySqlCommand CreateTSPriorityTable = new MySqlCommand(createTSPriorityTable, conn);
            CreateTSPriorityTable.ExecuteNonQuery();

            // Критичность тест-сьютов
            string createTSSeverityTable = " use " + name + "; create table TestSuiteSeverity " +
                "(TSSeverityID int not null, " +
                "TSSeverityDescription varchar(20) not null, " +
                "TSSeverityDescriptionTranslation nvarchar(20) not null," +
                "primary key (TSSeverityID)); ";
            MySqlCommand CreateTSSeverityTable = new MySqlCommand(createTSSeverityTable, conn);
            CreateTSSeverityTable.ExecuteNonQuery();

            // Вид тест-сьюта
            string createTSViewTable = "use " + name + "; create table TestSuiteView " +
                "(TSViewID int not null, " +
                "TSViewDescription varchar(100) not null," +
                "TSViewDescriptionTranlation nvarchar(100) not null, " +
                "primary key (TSViewID)  ); ";
            MySqlCommand CreateTSViewTable = new MySqlCommand(createTSViewTable, conn);
            CreateTSViewTable.ExecuteNonQuery();
        }

        public void FillReferenceTablesInDB()
        {
            // Заполнение ролей
            string insertIntoRoleTable = " insert into Role values " +
                "('1', 'Administrator', 'Администратор')," +
                "('2', 'TeamLead', 'Руководитель')," + // из-за того, что таблица ролей с такими ограничениями. Надо будет переделать
                "('3', 'Tester', 'Тестировщик');";
            MySqlCommand InsertIntoRoleTable = new MySqlCommand(insertIntoRoleTable, conn);
            InsertIntoRoleTable.ExecuteNonQuery();

            // Заполнение критичности БР
            string insertIntoBRSeverityTable = "insert into BugSeverity values " +
                "('0', 'Trivial', 'Тривиальный')," +
                "('1', 'Minor', 'Незначительный')," +
                "('2', 'Major', 'Значительный')," +
                "('3', 'Critical', 'Критический')," +
                "('4', 'Blocker', 'Блокирующий');";
            MySqlCommand InsertIntoBRSeverityTable = new MySqlCommand(insertIntoBRSeverityTable, conn);
            InsertIntoBRSeverityTable.ExecuteNonQuery();

            // Заполнение приоритета БР
            string insertIntoBRPriorityTable = "insert into BugPriority values" +
                "('0', 'Low', 'Низкий'), " +
                "('1', 'Medium', 'Средний'), " +
                "('2', 'High', 'Высокий'); ";
            MySqlCommand InsertIntoBRPriorityTable = new MySqlCommand(insertIntoBRPriorityTable, conn);
            InsertIntoBRPriorityTable.ExecuteNonQuery();

            // Заполнение статуса БР
            string insertIntoBRStatusTable = "insert into BugReportStatus values " +
                "('0', 'Open', 'Открыт'), " +
                "('1', 'In Progress', 'В работе'), " +
                "('2', 'Ready for check', 'Исправлен'), " +
                "('3', 'Closed', 'Закрыт'), " +
                "('4', 'Rejected', 'Отклонён'), " +
                "('5', 'Deferred', 'Отсрочен'), " +
                "('6', 'Reopened', 'Переоткрыт'); ";
            MySqlCommand InsertIntoBDStatusTable = new MySqlCommand(insertIntoBRStatusTable, conn);
            InsertIntoBDStatusTable.ExecuteNonQuery();

            // Заполнение статуса чек-листа
            string insertIntoCLStatusTable = "insert into CheckListStatus values " +
                "('0', 'Passed', 'Пройден'), " +
                "('1', 'Failed', 'Не пройден'), " +
                "('2', 'Not run', 'Не запущен'), " + // по умолчанию
                "('3', 'Blocked', 'Заблокирован'); ";
            MySqlCommand InsertIntoCLStatusTable = new MySqlCommand(insertIntoCLStatusTable, conn);
            InsertIntoCLStatusTable.ExecuteNonQuery();

            // Заполнение приоритета чек-листа
            string insertIntoCLPriorityTable = "insert into CheckListPriority values" +
                "('0', 'Low', 'Низкий'), " +
                "('1', 'Medium', 'Средний'), " +
                "('2', 'High', 'Высокий'); ";
            MySqlCommand InsertIntoCLPriorityTable = new MySqlCommand(insertIntoCLPriorityTable, conn);
            InsertIntoCLPriorityTable.ExecuteNonQuery();

            // Заполнение приоритета тест-кейса
            string insertIntoTCPriorityTable = "insert into TestCasePriority values" +
                "('0', 'Low', 'Низкий'), " +
                "('1', 'Medium', 'Средний'), " +
                "('2', 'High', 'Высокий'); ";
            MySqlCommand InsertIntoTCPriorityTable = new MySqlCommand(insertIntoTCPriorityTable, conn);
            InsertIntoTCPriorityTable.ExecuteNonQuery();

            // Заполнение критичности тест-кейса
            string insertIntoTCSeverityTable = "insert into TestCaseSeverity values " +
                "('0', 'Trivial', 'Тривиальный')," +
                "('1', 'Minor', 'Незначительный')," +
                "('2', 'Major', 'Значительный')," +
                "('3', 'Critical', 'Критический')," +
                "('4', 'Blocker', 'Блокирующий');";
            MySqlCommand InsertIntoTCSeverityTable = new MySqlCommand(insertIntoTCSeverityTable, conn);
            InsertIntoTCSeverityTable.ExecuteNonQuery();

            // Заполнение поведения тест-кейса
            string insertIntoTCBehaviorTable = " insert into TestCaseBehavior values " +
                "('0', 'Negative', 'Негативный'), " +
                "('1', 'Positive', 'Позитивный'), " +
                "('2', 'Destructive', 'Деструктивный'); ";
            MySqlCommand InsertIntoTCBehaviorTable = new MySqlCommand(insertIntoTCBehaviorTable, conn);
            InsertIntoTCBehaviorTable.ExecuteNonQuery();

            // Заполнение типа тест-кейса
            string insertIntoTCTypeTable = "insert into TestCaseType values " +
                "('0', 'Functional', 'Функциональное тестирование')," +
                "('1', 'Smoke', 'Дымовое тестирование')," +
                "('2', 'Regression', 'Регрессионное тестирование')," +
                "('3', 'Security', 'Тестирование безопасности')," +
                "('4', 'Usability', 'Тестирование на удобство использования')," +
                "('5', 'Performance', 'Тестирование производительности')," +
                "('6', 'Acceptance', 'Тестирование на ошибки пользователя')," +
                "('7', 'Compatibility', 'Тестирование совместимости')," +
                "('8', 'Integration', 'Интеграционное тестирование')," +
                "('9', 'Recovery', 'Тестирование восстановления после сбоя')," +
                "('10', 'Automated', 'Автоматизированное тестирование')," +
                "('11', 'Exploratory', 'Эксплоративное тестирование');";
            MySqlCommand InsertIntoTCTypeTable = new MySqlCommand(insertIntoTCTypeTable, conn);
            InsertIntoTCTypeTable.ExecuteNonQuery();

            // Заполнение статуса тест-кейса
            string insertIntoTCStatusTable = " insert into TestCaseStatus values " +
                "('0', 'Passed', 'Пройден'), " +
                "('1', 'Failed', 'Провален'), " +
                "('2', 'Blocked', 'Блокирован'), " +
                "('3', 'Skipped', 'Пропущен'), " +
                "('4', 'Draft', 'Не выполнен'), " +
                "('5', 'In progress', 'В тестировании'); ";
            MySqlCommand InsertIntoTCStatusTable = new MySqlCommand(insertIntoTCStatusTable, conn);
            InsertIntoTCStatusTable.ExecuteNonQuery();

            // Заполнение приоритета тест-сьюта
            string insertIntoTSPriorityTable = "insert into TestSuitePriority values" +
                "('0', 'Low', 'Низкий'), " +
                "('1', 'Medium', 'Средний'), " +
                "('2', 'High', 'Высокий'); ";
            MySqlCommand InsertIntoTSPriorityTable = new MySqlCommand(insertIntoTSPriorityTable, conn);
            InsertIntoTSPriorityTable.ExecuteNonQuery();

            // Заполнение критичности тест-сьюта
            string insertIntoTSSeverityTable = "insert into TestSuiteSeverity values " +
                "('0', 'Trivial', 'Тривиальный')," +
                "('1', 'Minor', 'Незначительный')," +
                "('2', 'Major', 'Значительный')," +
                "('3', 'Critical', 'Критический')," +
                "('4', 'Blocker', 'Блокирующий');";
            MySqlCommand InsertIntoTSSeverityTable = new MySqlCommand(insertIntoTSSeverityTable, conn);
            InsertIntoTSSeverityTable.ExecuteNonQuery();
        }


        public void CreateMainTablesInDB()
        {
            // Таблица пользователей
            string createUserTable = "use " + name + "; create table if not exists Userinfo " +
                "(UserID int not null AUTO_INCREMENT, " +
                "FirstName varchar(25) not null, " +
                "LastName varchar(25) not null, " +
                "Login varchar(20) not null, " +
                "Password varchar(20) not null, " +
                "RoleID int not null," +
                "CompanyID int not null," +
                "primary key (UserID)," +
                "foreign key (RoleID) references Role (RoleID)," +
                "foreign key (CompanyID) references Company (CompanyID)); ";
            MySqlCommand CreateUserTable = new MySqlCommand(createUserTable, conn);
            CreateUserTable.ExecuteNonQuery();

            // Таблица заказчиков
            string createCustomerTable = "use " + name + "; create table if not exists Customer " +
                "(CustomerID int not null AUTO_INCREMENT, " +
                "CustomerFirstName varchar (25) not null, " +
                "CustomerLastName varchar (25) not null, " +
                "CustomerPhone varchar (15) not null, " +
                "CustomerEmail varchar (50) not null, " +
                "CustomerNotes varchar (255), " +
                "primary key(CustomerID)); ";
            MySqlCommand CreateCustomerTable = new MySqlCommand(createCustomerTable, conn);
            CreateCustomerTable.ExecuteNonQuery();

            // Таблица проектов
            string createProjectTable = "use " + name + "; create table if not exists Project " +
                "(ProjectID varchar (50) not null, " +
                "ProjectName varchar (255) not null, " +
                "CompanyID int not null, " +
                "ProjectDateOfCreation date not null, " +
                "CustomerID int not null, " +
                "primary key(ProjectID), " +
                "foreign key (CustomerID) references Customer (CustomerID)," +
                "foreign key (CompanyID) references Company(CompanyID)); ";
            MySqlCommand CreateProjectTable = new MySqlCommand(createProjectTable, conn);
            CreateProjectTable.ExecuteNonQuery();

            // Таблица проектной документации
            string createProjectDocumentationTable = "use " + name + "; create table if not exists ProjectDocumentation " +
                "(ProjectDocumentationID int not null AUTO_INCREMENT, " +
                "ProjectID varchar (50) not null, " +
                "ProjectDocumentationAttachment int not null, " +
                "primary key(ProjectDocumentationID), " +
                "foreign key (ProjectID) references Project(ProjectID)); ";
            MySqlCommand CreateProjectDocumentationTable = new MySqlCommand(createProjectDocumentationTable, conn);
            CreateProjectDocumentationTable.ExecuteNonQuery();

            // Таблица чек-листов
            string createCheckListTable = "use " + name + "; create table if not exists CheckList " +
                "(CheckListID varchar (50) not null, " +
                "CLSummary varchar (255) not null, " +
                "CLDescription varchar (255), " + // Что делает чек-лист
                "CLPersentageOfPassed varchar (255) not null, " + // Об этом надо подумать+
                "primary key(CheckListID)); ";
            MySqlCommand CreateCheckListTable = new MySqlCommand(createCheckListTable, conn);
            CreateCheckListTable.ExecuteNonQuery();

            // Таблица пунктов чек-листа
            string createCheckListItemTable = "use " + name + "; create table if not exists CheckListItem " +
                "(CheckListItemID varchar (50) not null, " +
                "CheckListItemDescription varchar (255) not null, " +
                "CLStatusID int not null, " +
                "CLComment varchar (255) not null, " +
                "CheckListID varchar (50) not null, " +
                "CLAttachment varchar(255), " +
                "CheckListUserID int, " +
                "DataOfExecution date, " +
                "CLPriorityID int, " +
                "primary key(CheckListID)," +
                "foreign key (CLStatusID) references CheckListStatus(CLStatusID)," +
                "foreign key (CheckListID) references CheckList(CheckListID)); ";
            MySqlCommand CreateCheckListItemTable = new MySqlCommand(createCheckListItemTable, conn);
            CreateCheckListItemTable.ExecuteNonQuery();


            // Таблица тест-сьютов
            string createTestSuiteTable = "use " + name + "; create table if not exists TestSuite " +
                "(TestSuiteID varchar (50) not null, " +
                "TestSuiteSummary varchar (255) not null, " +
                "TestSuiteDescription text not null, " +
                "TestSuiteLabel char (3) not null, " +
                "TestSuitePreconditions varchar(255), " +
                "TestSuiteParentID varchar (50), " +
                "primary key(TestSuiteID), " +
                "unique (TestSuiteLabel)," +
                "foreign key (TestSuiteParentID) references TestSuite(TestSuiteID)); ";
            MySqlCommand CreateTestSuiteTable = new MySqlCommand(createTestSuiteTable, conn);
            CreateTestSuiteTable.ExecuteNonQuery();


            //Таблица тест-кейсов
            string createTestCaseTable = "use " + name + "; create table if not exists TestCase " + // создание таблицы чек-листов
                "(TestCaseID varchar (50) not null, " +
                "TestCaseSummary varchar (255) not null, " +
                "TestCaseDescription varchar(1000), " +
                "TestCaseSteps varchar (255) not null, " +
                "TestCaseExpectedResult varchar(255) not null, " +
                "TestCaseActualResult varchar(255) not null, " +
                "TCStatusID int not null, " +
                "TestCaseTestData varchar(255) not null, " +
                "TestSuiteID varchar (50) not null, " +
                "CreatorUserID int not null, " +
                "TestCaseCreationDate date not null, " +
                "ExecutorUserID int not null, " +
                "TestCaseExecutionDate date not null," +
                "TestCaseEnvironment varchar(255) not null, " +
                "TCTypeID int, " +
                "TCBehaviorID int, " +
                "TCPriorityID int, " +
                "TCSeverityID int, " +
                "TestCaseAttachment varchar(255), " +
                "TestCasePrecondition varchar (255), " +
                "TestCasePostcondition varchar (255), " +
                "primary key(TestCaseID)," +
                "foreign key (TestSuiteID) references TestSuite(TestSuiteID), " +
                "foreign key (CreatorUserID) references Userinfo(UserID), " +
                "foreign key (ExecutorUserID) references Userinfo(UserID), " +
                "foreign key (TCStatusID) references TestCaseStatus(TCStatusID), " +
                "foreign key (TCTypeID) references TestCaseType(TCTypeID), " +
                "foreign key (TCBehaviorID) references TestCaseBehavior(TCBehaviorID), " +
                "foreign key (TCPriorityID) references TestCasePriority(TCPriorityID), " +
                "foreign key (TCSeverityID) references TestCaseSeverity(TCSeverityID)); ";
            MySqlCommand CreateTestCaseTable = new MySqlCommand(createTestCaseTable, conn);
            CreateTestCaseTable.ExecuteNonQuery();

            // Таблица баг-репортов
            string createBRTable = "use " + name + "; create table if not exists BugReport " + // таблица баг-репортов
               "(BugReportID char(10) not null, " +
               "BugReportSummary varchar(255) not null," +
               "BugEnvironment varchar(255) not null, " +
               "BugSteps text not null, " +
               "BugExpectedResult text not null, " +
               "BugActualResult text not null, " + // Остальные поля по выбору
               "BugPreconditions varchar(255), " +
               "BugTestData varchar(255), " +
               "BugAttachment varchar(255), " +

               "BugSeverityID int, " +
               "BugPriorityID int, " +
               "BRStatusID int, " +
               "ProjectID varchar (50) not null, " +
               "UserID int not null, " +

               "DateOfCreation date not null, " +
               "BugReportRemark text, " +
               "BugComponentOfSW varchar(255) , " +
               "BugVersionOfSW varchar(100) , " +
               "TestCaseID varchar(255), " + // Ссылка на тест-кейс, если баг был найден во время тестирования
                                             //"VersionID int, " + позже создадим таблицу внутри проекта с номерами версий. А пока что без неё
                                             // Версия, в которой баг был исправлен
               "primary key (BugReportID)," +
               "foreign key (UserID) references Userinfo(UserID)," +
               "foreign key (TestCaseID) references TestCase(TestCaseID)," +
               "foreign key (ProjectID) references Project(ProjectID)," +
               "foreign key (BugSeverityID) references BugSeverity(BugSeverityID)," +
               "foreign key (BugPriorityID) references BugPriority(BugPriorityID)," +
               "foreign key (BRStatusID) references BugReportStatus(BRStatusID)) ;";
            MySqlCommand createNewBRTable = new MySqlCommand(createBRTable, conn);
            createNewBRTable.ExecuteNonQuery();
        }
    }
}
*/