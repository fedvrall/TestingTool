   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5    /Test_Management_System.Pages.PageCheckListItems   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageCheckListItems��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $5��/Список пунктов чек-листов��$��16(�$��DemiBold"�$��20, 10, 0, 0q�� $��1��$��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��10 0 0 5q�$��Описание *���� -    ��Name$ TextBoxDescription��$��0��$
��1030�� �� 	MaxLength$
 1000��$��Right=�$��5, 5, 10, 5q��� $��1�� �� Orientation$ 
Horizontal=�$��0, 10, 0, 10q�.+��� $��10, 0, 56, 0q�$��Статус���� -    ��Name$ ComboBoxStatus��$	��400��$��10q� �� DisplayMemberPath$$ CLStatusDescriptionTranslation���� $��75, 0, 75, 0q�$��Приоритет���� -   $ ComboBoxPriority��$	��400��$��10q�$&  CLPriorityDescriptionTranslation���� $��2��$��10, 5, 0, 5q�$��Комментарий���� -   $ TextBoxComment��$��2��$	 255��$
��1030��$��Right=�$��5, 5, 10, 5q��� $��3��$��Вложение��$��10 5 0 5q��� -    ��Name$ AttachmentsListBox��$��3��$	��975��$��70��$��Right=�$��5,5,65,5q����� .R��� $ 
Horizontal=�.+��� $��10q�$��14(�$��Courier)����� �� -   $��Удалить��$��10, 0q�$	��100��   RoundedCorners#���   �� -   #���   $��3��$	�� + ��$��26(�$��5q�$��Right=�$��Center=�$��5, 5, 10, 5q��� -   $��AddChecklistItem��$��4��$!��Добавить пункт��$��10q�#���   &   System.Windows.Controls.DataGrid  -	   $��CheckListGrid��"   VerticalScrollBarVisibility$
 Auto=�$��10q�$��5��	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     HeadersVisibility$ Column=�   CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     
IsReadOnly . $	��368��$	��325��$
��1160��$	��Top=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Описание��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CheckListItemDescription+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Статус��$	 120  �� *0.CheckListStatus.CLStatusDescriptionTranslation+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Приоритет��$	 120  �� *42CheckListPriority.CLPriorityDescriptionTranslation+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Комментарий��$	 400  �� *	CLComment+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Вложение��$	 245  �� *CLAttachment+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�4  .System.Windows.Controls.DataGridTemplateColumn  $ 50    CellTemplate �� .R��� -
   #���   $	�� X ��$��5q�$��20(�$��5q�
 � Tag �� �� $��2��$ 
Horizontal=�$��Right=�$��0, 10, 20, 20q�.+��� -   $��ExecuteList��#���   $	��200��$��0, 0, 10, 0q�$"��Пройти чек-лист��$y�	Collapsed=��� -   $!��ExitFromAddingCheckListItem��#���   $	��200��$'��!Выйти к чек-листам��