   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  1    +Test_Management_System.Pages.PageNewProject   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageNewProject��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��Header��$��0��$��18(�$��10q��� $��4�� �� Orientation$ 
Horizontal=�$��10q�.+��� $��Документация ���� -    ��Name$ AttachmentsListBox��$	��737��$	��117��$��91, 0, 10, 0q����� .R��� $ 
Horizontal=�.+��� $��10q�$��14(�$��Courier)����� �� -   $��Удалить��$��10, 0q�$	��100��   RoundedCorners#���   �� -   $��AddAttachment��$'��!Добавить вложение��$��10, 10, 10,10q�$	��200��#���   $��44���� $��1��$��10q�$
��Left=�$��Название *���� -    ��Name$ TBProjectName��$��1��$��Right=� �� 	MaxLength$	 255��$	��960��$��123, 10, 10, 10q��� $��2��$ 
Horizontal=�$��10q�.+��� $*��$Дата начала проекта��$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ dpStartDate��$	��200��$��Center=�$��54,0, 10, 0q�$��15(����#ffffff�� $��2��$��Заметки��$��493, 10, 10, 0q��� -   $��TBProjectNotes��$��2��$��2�� �� TextWrapping$
 Wrap=�$	 500�� �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�$��645,10,10,10q��� $��3��$ 
Horizontal=�$��10q�.+��� $5��/Дата окончания (если есть)��$��Center=�  -   $ 	dpEndDate��$	��200��$��Center=�$��
13,0, 0, 0q�$��15(����#ffffff�� $?��9Информация о заказчике проекта��$��5��$��18(�$��10q�� -	   $��customerFields��$��6�� �� $
��Auto ��� $
��Auto �.+��� $��0��$��Имя *��$��10q��� -
   $ customerNameTB��$��0��$ 25��$	��200��$��208, 10, 0, 10q�$
��Left=��� $��0��$)��#Электронная почта *��$��493, 10, 10, 10q��� -   $ customerEmailTB��$��0��$	 100��$	��200��$
��Left=�$��645,10, 0, 10q��� $��1��$��Фамилия *��$��10q�$��Center=��� -   $ customerLastNameTB��$��1��$ 25��$	��200��$��Center=�$
��Left=�$��208,10, 0, 10q��� $��1��$��Телефон *��$��493, 10, 10, 10q�$��Center=��� -   $ customerPhoneTB��$��1��$ 20��$	��200��$��Center=�$
��Left=�$��645,10, 0, 10q��� $��8��$
��Left=�$��10q�$��Заметки���� -   $ customerNotesTB��$��8��$��Right=�$��10q�$	 255��$
	 Auto=� . $
 Wrap=�$	��960��$	��115���� $��9��$ 
Horizontal=�$��10,10,10,20q�$��Right=�$��Bottom=�.+��� -   $��ConfirmAdding��$#��Добавить проект��#���   $��0, 0, 10, 0q�$	��200���� -   $��SaveProjectChanges��$+��%Сохранить изменения��#���   $��0, 0, 10, 0q�$��10q�{�.  $	��200���� -   $��ExitWithoutSave��$,��&Выйти без сохранения��#���   $��10q�$	��200��