   M S B A M L   `   `   `  ����   Test Management System3    -Test_Management_System.Pages.PageNewBugReport   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  PageNewBugReport��.��� -   $��BRGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��Header��$��0��$��16(�$��10q�$��DemiBold"��� $��Заголовок *��$��1��$��10, 10, 0, 0q��� -    ��Name$ 	TBSummary�� �� 	MaxLength$	 255��$	��980��$��1��$��Right=�$��	0,10,10,0q��� $��2��$��Окружение *��$��10, 10, 0, 0q��� -   $ TBEnvir��$	 255��$��2��$	��980��$��Right=�$��
0,10,10,10q��� $��3��$��
Шаги *��$��10, 10, 0, 0q��� -   $ TBSteps��$
 1000��$��3��$	��980��$��Right=�$��0,0,10,0q� �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$	��100����  �� Orientation$ 
Horizontal=�$��4��.+��� $-��'Ожидаемый результат *��$��10, 10, 13, 10q��� -   $ 
TBexpected��$
 1000�� . $
 Wrap=�$
 Auto=�$��4��$��2��$	��397��$	��100���� $1��+Фактический результат *��$��10, 10, 8, 10q��� -   $ TBactual��$
 1000�� . $
 Wrap=�$
 Auto=�$��4��$��2��$��	0,10,10,0q�$	��397��$	��100���� $��5��$��Предусловия��$��10, 10, 0, 0q��� -   $ 	TBprecond��$	 255��$��5��$	��980��$��Right=�$��	0,10,10,0q��� $��6��$#��Тестовые данные��$��10, 10, 0, 0q��� -	   $ 
TBtestdata��$	 255��$��6��$	��980��$��Right=�$��	0,10,10,0q��� $ 
Horizontal=�$��7��$��10, 10, 10, 0q�.+��� $��Приоритет���� -
    ��Name$ ComboPriority��	 �� SelectedIndex$	 0��
 �� DisplayMemberPath$ 
 BugPriorityNameTranslation��$	��200��$��	97,0,55,0q��� $��Критичность���� -   $ ComboSeverity��$	 0��$ 
 BugSeverityNameTranslation��$	��200��$��	63,0,55,0q��� $��Статус���� -   $ ComboStatus��$	 0��$
 BRStatusNameTranslation��$	��200��$��66,0,0,0q��� $ 
Horizontal=�$��8��$��10, 10, 10, 0q�.+��� $��Компонент ПО���� -   $ TBComponent��$	 255��$	��397��$��	70,0,32,0q��� $��Версия ПО���� -   $ 	TBVersion��$	 100��$	��397��$��75,0,0,0q��� $ 
Horizontal=�$��9��$��10, 10, 10, 0q�.+��� $��Дата создания��(  "System.Windows.Controls.DatePicker  -     Name$ 
DPCreation��$	��397��$��74,0,0,0q�$��30���� $��Заметки��$��9��$��
615,10,0,0q��� -   $ TBNotes��$
 1000�� . $
 Wrap=�$
 Auto=�$��9��$��2��$��768,10,10,0q�$	��397���� $ 
Horizontal=�$��10��$��10, 10, 0, 0q�.+��� $,��&Связанные тест-кейсы���� -   $ ComboTC��$
 TestCaseSummary��$	��397��$��23,0,0,0q��� $ 
Horizontal=�$��11��$��
10, 10,0,0q�.+��� $��Вложения��$��0, 10, 10, 0q��� -    ��Name$ AttachmentsListBox��$	��751��$��80��$��92, 0, 10, 0q����� .R��� $ 
Horizontal=�.+��� $��10q�$��14(�$��Courier)����� �� $��	RemoveAtt��-   $��Удалить��$��10, 0q�$	��100��   RoundedCorners#���   �� -   $��AddAttachment��#���   $��10q�$	��200��$'��!Добавить вложение��$��20, 10, 10, 10q�$��Center=��� $ 
Horizontal=�$��12��$��10, 10, 10, 10q�$��Right=�$��Bottom=�.+��� -    ��Name$ SaveBRAndExit��#���   $��0, 0, 10, 0q�$&�� Сохранить и выйти��$	��200���� -   $ SaveAndAddOneMoreBR��#���   $��0, 0, 10, 0q�$<��6Сохранить и добавить ещё один��$	��250���� -   $ ExitWithoutSaveBR��#���   $,��&Выйти без сохранения��$	��200��