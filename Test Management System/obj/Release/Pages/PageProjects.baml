   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  /    )Test_Management_System.Pages.PageProjects   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  Проекты��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $(��"Работа с проектами��$��16(�$��DemiBold"�$��0��&   System.Windows.Controls.DataGrid  -   $��GridProjects��$��10q�$��1��   AutoGenerateColumns .     CanUserAddRows .     HeadersVisibility$ Column=����� *	Project+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$% Название проекта��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ProjectName+  $* $Дата начала проекта��$	 210  �� *ProjectDateOfCreation+  $0 *Дата окончания проекта��$	 210  �� *ProjectDateOfDeadLine+  $ Заметки��$	 430  �� *ProjectNotes+�� 	 �� Orientation$	 
Horizontal=�$��2��$��10q�$��80��.+��� -   
 ��Name$
 AttachmentsListBox��$
��1060��$��10, 10, 10, 0q����� .R��  � ColumnDefinitions �� $	��890 ��� $	��150 �.+��� $��0��$��10q�$��14(�$��Courier)����� ��  ��Name$ OpenFile��-   $��1��$��Открыть файл��$	��150��   RoundedCorners#���   ���� �� -   $��CustomerInfo1��$��3��$	 
Horizontal=�$��10q�.+��� $1��+Информация о заказчике:��$��16(�$
��Bold"��� $+��%Заметки о заказчике:��$��444, 0, 0, 0q�$��16(�$
��Bold"��� -   $��CustomerInfo2��$��4��$	 
Horizontal=�$��10q�.+��� $��Фамилия:��$��Center=��� -    ��Name$ txtLastName�� �� 	MaxLength$ 25��$	��200��$��24, 0, 10, 0q�{�.  �� $(��"Электронная почта:��$��Center=��� -   $ txtEmail��$	 100��$��10, 0, 10, 0q�$	��200��{�.  �� -   $��CustomerInfo3�� �� AcceptsReturn . $	 255�� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$��4��$��2��$��675,10,10,10q�{�.  �� -	   $��CustomerInfo4��$��5��$	 
Horizontal=�$��10q�.+��� $��Имя:��$��Center=��� -
   $ txtFirstName��$ 25��$	��200��$��55, 0, 10, 0q�{�.  �� $��Телефон:��$��Center=��� -   $ txtPhone��$ 20��$	��200��$��78, 0, 10, 0q�{�.  �� $��6��$	 
Horizontal=�$��10, 20, 10, 20q�$��Right=�.+��� -   $��AddNewProject��#���   $	��150��$��0, 0, 10, 0q�$#��Добавить проект��$��Center=�$��Right=��� -   $��EditProject��#���   $	��150��$��0, 0, 10, 0q�{�.  $ ��Редактировать��$��Center=�$��Right=��� -   $��DeleteProject��#���   $	��150��$��Удалить��{�.  $��Center=�$��Right=�