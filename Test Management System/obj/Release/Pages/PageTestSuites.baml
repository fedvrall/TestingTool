   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  1    +Test_Management_System.Pages.PageTestSuites   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageTestSuites��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��10, 10, 10, 10q�$
��Left=�.+��� $,��&Просмотр тест-сьютов��$��18(�&   System.Windows.Controls.DataGrid  -   $��dgvTestSuites��   CanUserAddRows .  $��1��$��10q�   HeadersVisibility$ Column=�   AutoGenerateColumns .  ���� *	TestSuite+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Заголовок��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *TestSuiteSummary+
   ElementStyle
 �� .���  �� Property � �� �� Value$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Описание��$	 300 	 �� *TestSuiteDescription+
 �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ 
Метка��$ 80 	 �� *TestSuiteLabel+
 �� .���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Предусловия��$	 200 	 �� *TestSuitePreconditions+
 �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $0 *Родительский тест-сьют��$	 220 	 �� *TestSuiteParentID+
 �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�4  .System.Windows.Controls.DataGridTemplateColumn  $  ��   CellTemplate �� .R��� $ 
Horizontal=�.+��� $��WatchTestCases��-   ���#626262   RoundedCorners#���   $��5q����� $��/Pages/watch.png��$��25��$��25���� $��EditTestSuite��-   ���#626262#���   $��5q����� $��/Pages/edit.png��$��25��$��25���� $��DeleteTestSuite��-   ���#626262#���   $��5q����� $��/Pages/delete.png��$��25��$��25���� $��2��$ 
Horizontal=�$��10q�$��Right=�.+��� -   $��NewTestSuiteButton��$	��200��$3��-Добавить новый тест-сьют��#���   