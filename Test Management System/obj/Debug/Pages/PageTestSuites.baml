   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      1    +Test_Management_System.Pages.PageTestSuites   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  PageTestSuites��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10, 10, 10, 10q�6;   $
��Left=�6S   .+�5      �� $,��&Просмотр тест-сьютов��6   $��18(�63   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgvTestSuites��5   *      CanUserAddRows .  $��1��6q   $��10q�6~      HeadersVisibility$ Column=�6�      AutoGenerateColumns .  ��6�   �� *	TestSuite+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Заголовок��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 68   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6D   �� *TestSuiteSummary+
   ElementStyle
 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       � ��$ Center=�6L   �� 5       � ��$ 5,5,0,0q�6A   5      5        5      $ Описание��6%   $	 300 67   	 6C   �� *TestSuiteDescription+
 5       �� 5!      .�5"      ��  � ��$
 Wrap=�6G   �� 5#       � ��$ Center=�6L   �� 5$       � ��$ 5,5,0,0q�6A   5%      5'        5(      $ 
Метка��6%   $ 80 64   	 6?   �� *TestSuiteLabel+
 5)      �� 5*      .�5+      ��  � ��$ Center=�6L   �� 5,       � ��$ 5,5,0,0q�6A   5-      5/        50      $ Предусловия��6%   $	 200 6:   	 6F   �� *TestSuitePreconditions+
 51      �� 52      .�53      ��  � ��$
 Wrap=�6G   �� 54       � ��$ Center=�6L   �� 55       � ��$ 5,5,0,0q�6A   56      58        59      $0 *Родительский тест-сьют��6%   $	 220 6E   	 6Q   �� *TestSuiteParentID+
 5:      �� 5;      .�5<      ��  � ��$
 Wrap=�6G   �� 5=       � ��$ Center=�6L   �� 5>       � ��$ 5,5,0,0q�6A   5?      5A      4  .System.Windows.Controls.DataGridTemplateColumn  5B      $  ��6)      CellTemplate 5C      �� 5D      .R�5E      �� $ 
Horizontal=�6)   .+�5F   "   �� $��WatchTestCases��6)   -   5        ���#626262   RoundedCorners#���   5F   r   $��5q�6�   ��5G   &   �� 5H   *   $��/Pages/watch.png��60   $��25��6K   $��25��6W   5J   #   �� 5K   "   $��EditTestSuite��6)   -   5        ���#626262#���   5K   o   $��5q�6�   ��5L   &   �� 5M   *   $��/Pages/edit.png��60   $��25��6I   $��25��6U   5O   #   �� 5P   "   $��DeleteTestSuite��6)   -   5        ���#626262#���   5P   s   $��5q�6�   ��5Q   &   �� 5R   *   $��/Pages/delete.png��60   $��25��6L   $��25��6X   5T   #   5U      5V      5X      5Z      �� 5[   
   $��2��6   $ 
Horizontal=�6"   $��10q�6;   $��Right=�6G   .+�5\      �� -   5        $��NewTestSuiteButton��5\   D   $	��200��6   $3��-Добавить новый тест-сьют��6!   #���   6   5^      5_      5`      