   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      /    )Test_Management_System.Pages.PageProjects   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  Проекты��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $(��"Работа с проектами��6   $��16(�6-   $��DemiBold"�6;   $��0��6Q   &   System.Windows.Controls.DataGrid  5   
   -   5        $��GridProjects��5      $��10q�6'   $��1��63      AutoGenerateColumns .     CanUserAddRows .     HeadersVisibility$ Column=�6�   ��6@   �� *	Project+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$% Название проекта��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *ProjectName+  5      $* $Дата начала проекта��6%   $	 210 6B    6N   �� *ProjectDateOfCreation+  5      $0 *Дата окончания проекта��6%   $	 210 6E    6Q   �� *ProjectDateOfDeadLine+  5      $ Заметки��6%   $	 430 66    6B   �� *ProjectNotes+5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��2��6.   $��10q�6;   $��80��6G   .+�5       �� -   5        
 ��Name$
 AttachmentsListBox��5    ;   $
��1060��6   $��10, 10, 10, 0q�6$   ��5!      �� 5"      .R�5#      �  � ColumnDefinitions 5$      �� 5%   "   $	��890 �63   �� 5&   "   $	��150 �63   .+�5(      �� $��0��6(   $��10q�6I   $��14(�6U   $��Courier)�6c   ��68   �� 6c   �� 5)       ��Name$ OpenFile��6X   -   5        $��1��5)   %   $��Открыть файл��65   $	��150��6L      RoundedCorners#���   6�   ��6�   �� 5*      5+      5-      5.      �� 50   
   -   5        $��CustomerInfo1��50      $��3��6*   $	 
Horizontal=�67   $��10q�6P   .+�51      �� $1��+Информация о заказчике:��6   $��16(�67   $
��Bold"�6E   �� 52      $+��%Заметки о заказчике:��6   $��444, 0, 0, 0q�63   $��16(�6I   $
��Bold"�6W   53      �� 55   
   -   5        $��CustomerInfo2��55      $��4��6*   $	 
Horizontal=�67   $��10q�6P   .+�56      �� $��Фамилия:��6   $��Center=�6'   �� 57      -   5         ��Name$ txtLastName��57       �� 	MaxLength$ 25��6+   $	��200��6:   $��24, 0, 10, 0q�6F   {�.  6\   �� 58      $(��"Электронная почта:��6   $��Center=�62   �� 59      -   5        $ txtEmail��59      $	 100��6(   $��10, 0, 10, 0q�68   $	��200��6O   {�.  6\   5;      �� 5<   
   -   5        $��CustomerInfo3��5<       �� AcceptsReturn . $	 255��6<    �� TextWrapping$
 Wrap=�6L   " �� VerticalScrollBarVisibility$
 Auto=�6`   $��4��6�   $��2��6�   $��675,10,10,10q�6�   {�.  6�   �� 5>   
   -	   5        $��CustomerInfo4��5>      $��5��6*   $	 
Horizontal=�67   $��10q�6P   .+�5?      �� $��Имя:��6   $��Center=�6%   �� 5@      -
   5        $ txtFirstName��5@      $ 25��6,   $	��200��6;   $��55, 0, 10, 0q�6G   {�.  6]   �� 5A      $��Телефон:��6   $��Center=�6(   �� 5B      -   5        $ txtPhone��5B      $ 20��6(   $	��200��67   $��78, 0, 10, 0q�6D   {�.  6Z   5D      �� 5E   
   $��6��6   $	 
Horizontal=�6"   $��10, 20, 10, 20q�6;   $��Right=�6S   .+�5F      �� -   5        $��AddNewProject��5F   y   #���   6   $	��150��6>   $��0, 0, 10, 0q�6J   $#��Добавить проект��6_   $��Center=�6�   $��Right=�6�   �� 5G      -   5        $��EditProject��5G   �   #���   6   $	��150��6>   $��0, 0, 10, 0q�6J   {�.  $ ��Редактировать��6q   $��Center=�6�   $��Right=�6�   �� 5H      -   5        $��DeleteProject��5H   J   #���   6   $	��150��6>   $��Удалить��6`   {�.  $��Center=�6�   $��Right=�6�   6�   5J      5K      5L      