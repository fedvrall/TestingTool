   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      1    +Test_Management_System.Pages.PageCheckLists   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  PageCheckLists��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $3��-Просмотр всех чек-листов��6   $��10q�63   $��16(�6?   $��DemiBold"�6M   &   System.Windows.Controls.DataGrid  5   
   -   5        $��CheckListGrid��5   +      AutoGenerateColumns .  $��10q�6\   $��1��6h      CanUserAddRows .     HeadersVisibility$ Column=�6�      
IsReadOnly .    CanUserResizeRows .  ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Название��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 350 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	CLSummary+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       � ��$ Center=�6L   �� 5       � ��$ 5,5,0,0q�6A   5      5!        5"      $	 Описание��6%   $	
 650 68    6D   �� *CLDescription+ 5#      �� 5$      .�5%      ��  � ��$
 Wrap=�6G   �� 5&       � ��$ Center=�6L   �� 5'       � ��$ 5,5,0,0q�6A   5(      5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+         CellTemplate 5,      �� 5-      .R�5.      �� $��WatchCheckList��6z   -   5           RoundedCorners#���   5.   %   ���#626262$��5q�6c   $��5q�6n   ��5/   "   �� 50   &   $��/Pages/watch.png��6,   $��25��6F   $��25��6R   52      53      55        57       58      �� 59      .R�5:      �� $��EditCheckList��6z   -   5        #���   5:   %   $��5q�6N   ���#626262$��5q�6n   ��5;   "   �� 5<   &   $��/Pages/edit.png��6,   $��25��6E   $��25��6Q   5>      5?      5A        5C       5D      �� 5E      .R�5F      �� $��DeleteCheckList��6z   -   5        #���   5F   %   $��5q�6N   ���#626262$��5q�6n   ��5G   "   �� 5H   &   $��/Pages/delete.png��6,   $��25��6G   $��25��6S   5J      5K      5M      5O      �� 5Q   
   -   5         ��Name$ FormContainer��5Q      $��1��6(   $��1��65   $��10q�6E    �� CornerRadius$ 5��6Q   $	��300��6b   $y�	Collapsed=�6n   $��Right=�6�   ._�5R      �  5S      �� 5T      $
��Auto �6$   �� 5U      $
��Auto �6$   �� 5V      $
��Auto �6$   .+�5Y      �� $��0��6   $
��Left=�6*   $,��&Добавление чек-листа��6E   $��16(�6d   $��0, 10q�6r   $
��Bold"�6�   �� 5Z      -   5        $��CloseAdding��5Z   <   $��0��6   $��0, 10, 0, 10q�6&   $��Right=�6O   #���   6k   $��
5, 0, 5, 0q�6�   $	�� X ��6�   �� 5\      $��1��6    �� Orientation$ Vertical=�6*   $��10q�6A   .+�5]      �� $*��$Название чек-листа *��6   $
��0,10q�6<   �� 5^      -   5         ��Name$ TBNameCheckList��5^       �� 	MaxLength$	 255��67   �� 5_      $*��$Описание чек-листа *��6   $��0, 10q�6;   �� 5`      -   5        $ TBDescrCheckList��5`      $	 255��68    �� TextWrapping$
 Wrap=�6H   $	��200��6\   5a      �� 5c      -	   5        $��AddCheckList��5c   9   $��2��6   $��Добавить��6&   $��10q�6M   $	��130��6Y   $
��Left=�6e   $��10q�6�   #���   6�   6�   �� 5d      -
   5        $��SaveChanges��5d   :   $��2��6   $��Сохранить��6&   $��10q�6M   $	��130��6Y   $
��Left=�6e   $��10q�6�   #���   6�   $y�	Collapsed=�6�   6�   �� 5e      -   5        $��Cancel��5e   7   $��2��6   $��Отмена��6&   $��10q�6E   $	��130��6Q   $��10q�6]   $��Right=�6j   #���   6�   6�   5f      5g      �� 5i   
   $��2��6   $��0��6"   $��10, 20, 10, 20q�62   .+�5j      �� -   5        $��AddNewCheckList��5j   `   #���   6   $1��+Добавить новый чек-лист��6>   $	��210��6�   $��Right=�6�   $��Bottom=�6�   5k      5l      5n      