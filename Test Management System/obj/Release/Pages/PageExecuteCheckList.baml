   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  7    1Test_Management_System.Pages.PageExecuteCheckList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageExecuteCheckList��.���  � RowDefinitions �� $��* ��� $
��Auto �.+��� -   $��LISTBOX������ ���� .R�� $��5q� � ColumnDefinitions �� $	��300 ��� $	��150 ��� $	��150 ��� $	��400 ��� $	��150 ��� $
��Auto �.+��� $
��Wrap=�$��0��$��14(����� *CheckListItemDescription+�� $��ComboStatus��$��1�� �� DisplayMemberPath$$ CLStatusDescriptionTranslation������ *
Statuses+ �� SelectedValue �� *
CLStatusID+�� $��ComboPriority��$��2��$&  CLPriorityDescriptionTranslation������ *DataContext.Priorities+ �� RelativeSource ��  �� AncestorType$ ListBoxL� �� *CLPriorityID+��  �� TextWrapping$
 Wrap=� �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�$��3������ *	CLComment+�� $��4������ *CLAttachment+�� -   $��5��$��Удалить���� $��1��
 �� Orientation$
 
Horizontal=�$��10q�$��Right=�.+��� -   $
��Save��$+��%Сохранить изменения��$	��180��$��10, 0, 10, 0q�   RoundedCorners#���   �� -   $��Cancel��$��Отмена��$	��180��#���   