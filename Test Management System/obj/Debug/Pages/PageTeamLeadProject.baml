   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      6    0Test_Management_System.Pages.PageTeamLeadProject   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  PageTeamLeadProject��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��GridProjects��5      $��10q�6'   $��0��63      AutoGenerateColumns .     CanUserAddRows .     HeadersVisibility$ Column=�6�   ��6@   �� *	Project+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$% Название проекта��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *ProjectName+  5      $* $Дата начала проекта��6%   $	 210 6B    6N   �� *ProjectDateOfCreation+  5      $0 *Дата окончания проекта��6%   $	 210 6E    6Q   �� *ProjectDateOfDeadLine+  5      $ Заметки��6%   $	 430 66    6B   �� *ProjectNotes+5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��1��6.   .+�5      �� $��Вложения��6   $��10, 10, 10, 0q�6(   �� 5      -   5        
 ��Name$
 AttachmentsListBox��5   G   $
��1060��6   $��80��6#   $��10, 10, 10, 10q�6/   ��5       �� 5!      .R�5"      �� $	 
Horizontal=�6%   .+�5#      �� $��10q�69   $��14(�6E   $��Courier)�6S   ��6(   �� 6S   5$      5%      5'      5(      �� 5*   
   $A��;Добавить тестировщиков в проект��6   $��10q�6:   $��2��6F   �� 5+   
   $��Уже в проекте��6   $��3��6(   $��10q�65   �� 5,   
   $2��,Доступны для добавления��6   $��3��62   $��10, 10, 200, 10q�6?   $��Right=�6X   �� 5.   
   -   5        $
 usersInProject��5.   a   $��4��6   $��14(�6   $	��200��6-   $	��400��6:   $
��Left=�6F   {�.  $��15, 10, 10,40q�6�    �� SelectionMode$ Multiple=�6�   .@�5/      �� ��6   �� 50      �� 51   
   -   5        $��DeleteFromProject��51   �      RoundedCorners#���   6   $��4��6:   $	��200��6G   $��16(�6S   $��0, 0, 0, 50q�6a   {�.  $��<-��6�   $��Center=�6�   $��Center=�6�   �� 52   
   -   5        $��AddToProject��52   �   #���   6   $��4��6:   $	��200��6G   $��0, 50, 0, 0q�6S   $��->��6i   $��16(�6v   {�.  $��Center=�6�   $��Center=�6�   �� 55   
   -   5        $
 usersNotInProject��55   F   $��4��6   $��14(�6   $	��200��6-   $	��400��6:   $��Right=�6a   {�.  $��	0,5,20,40q�6�   $ Single=�6�   .@�56      �� ��6   �� 57      59      5:      