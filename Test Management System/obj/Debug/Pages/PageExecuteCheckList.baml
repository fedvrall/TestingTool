   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      7    1Test_Management_System.Pages.PageExecuteCheckList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  PageExecuteCheckList��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��LISTBOX��5      ��6!   �� ��5      �� 5      .R�5      � $��5q�6    � ColumnDefinitions 5      �� 5      $	��300 �6/   �� 5      $	��150 �6/   �� 5      $	��150 �6/   �� 5      $	��400 �6/   �� 5      $	��150 �6/   �� 5      $
��Auto �6/   .+�5      �� $
��Wrap=�6$   $��0��68   $��14(�6r   ��6H   �� *CheckListItemDescription+6r   �� 5      $��ComboStatus��5!   N   $��1��5   #    �� DisplayMemberPath$$ CLStatusDescriptionTranslation��5!      ��5   3   �� *
Statuses+ �� SelectedValue 5       �� *
CLStatusID+5!   N   �� 5#      $��ComboPriority��5%   P   $��2��5#   #   $&  CLPriorityDescriptionTranslation��5%      ��5#   3   �� *DataContext.Priorities+ �� RelativeSource ��  �� AncestorType$ ListBoxL� 5$      �� *CLPriorityID+5%   P   �� 5&       �� TextWrapping$
 Wrap=�6"    �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�6K   $��3��6n   ��6~   �� *	CLComment+�� 5'      $��4��6$   ��64   �� *CLAttachment+�� 5(      -   5        $��5��5(   !   $��Удалить��61   6C   5)      5*      5,      �� 5�   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"   $��10q�6;   $��Right=�6G   .+�5�      �� -   5        $
��Save��5�   3   $+��%Сохранить изменения��6   $	��180��6?   $��10, 0, 10, 0q�6K      RoundedCorners#���   6t   �� 5�      -   5        $��Cancel��5�   &   $��Отмена��6   $	��180��64   #���   6U   5�      5�      5�      