   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  1    +Test_Management_System.Pages.PageCheckLists   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageCheckLists��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $3��-Просмотр всех чек-листов��$��10q�$��16(�$��DemiBold"�&   System.Windows.Controls.DataGrid  -   $��CheckListGrid��   AutoGenerateColumns .  $��10q�$��1��   CanUserAddRows .     HeadersVisibility$ Column=�   
IsReadOnly .    CanUserResizeRows .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Название��
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 350 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	CLSummary+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $	 Описание��$	
 650  �� *CLDescription+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� $��WatchCheckList��-      RoundedCorners#���   ���#626262$��5q�$��5q����� $��/Pages/watch.png��$��25��$��25��   �� .R��� $��EditCheckList��-   #���   $��5q����#626262$��5q����� $��/Pages/edit.png��$��25��$��25��   �� .R��� $��DeleteCheckList��-   #���   $��5q����#626262$��5q����� $��/Pages/delete.png��$��25��$��25���� -    ��Name$ FormContainer��$��1��$��1��$��10q� �� CornerRadius$ 5��$	��300��$y�	Collapsed=�$��Right=�._��  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$
��Left=�$,��&Добавление чек-листа��$��16(�$��0, 10q�$
��Bold"��� -   $��CloseAdding��$��0��$��0, 10, 0, 10q�$��Right=�#���   $��
5, 0, 5, 0q�$	�� X ���� $��1�� �� Orientation$ Vertical=�$��10q�.+��� $*��$Название чек-листа *��$
��0,10q��� -    ��Name$ TBNameCheckList�� �� 	MaxLength$	 255���� $*��$Описание чек-листа *��$��0, 10q��� -   $ TBDescrCheckList��$	 255�� �� TextWrapping$
 Wrap=�$	��200���� -	   $��AddCheckList��$��2��$��Добавить��$��10q�$	��130��$
��Left=�$��10q�#���   �� -
   $��SaveChanges��$��2��$��Сохранить��$��10q�$	��130��$
��Left=�$��10q�#���   $y�	Collapsed=��� -   $��Cancel��$��2��$��Отмена��$��10q�$	��130��$��10q�$��Right=�#���   �� $��2��$��0��$��10, 20, 10, 20q�.+��� -   $��AddNewCheckList��#���   $1��+Добавить новый чек-лист��$	��210��$��Right=�$��Bottom=�