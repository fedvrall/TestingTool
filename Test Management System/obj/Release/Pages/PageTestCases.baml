   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  0    *Test_Management_System.Pages.PageTestCases   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageTestCases��.��� -   $��mainGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $2��,Просмотр тест-кейсов из ��$��18(�$��10q�$��0��$��0���� -   $��HeaderTestCasesView��$�� ��$��18(�$��240, 10, 10, 10q�$��0��$��0����  �� Orientation$ 
Horizontal=�$��0, 20, 10, 20q�$��3��$��Right=�$��0��.+��� -   $��AddTestCaseItem��$��Добавить��   RoundedCorners#���   $	��150��$��0, 0, 10, 0q��� -   $��EditTestCaseItem��$ ��Редактировать��#���   $	��150��$��0, 0, 10, 0q�{�.  �� -   $��DeleteTestCase��$��Удалить��#���   $	��150��$��0, 0, 10, 0q�{�.  �� -   $��BackToTS��$��
Назад��#���   $	��150���� $��1��$ 
Horizontal=�$��10q�$��0��.+��� $"��Сортировать по ��$��0,10,0,0q�$y�Hidden=��� -   $��ComboSortBy��$	��350��$��49, 0, 0, 0q�$y�Hidden=�.@��� $0��*дате (от новых к старым)���� $0��*дате (от старых к новым)���� $'��!статусу (провален)���� $,��&статусу (не выполнен)���� $D��>приоритету (от низкого к высокому)���� $D��>приоритету (от высокого к низкому)���� $T��Nкритичности (от тривиальной к блокирующей)���� $T��Nкритичности (от блокирующей к тривиальной)���� -   $��ChoseTCFields��$%��Просмотреть поля��$��Right=�$��10, 10, 10, 10q�$	��150��#���   $��0��$��1���� -	    ��Name$ FormContainer��$��2��$��1��$��10q� �� CornerRadius$ 5��$y�	Collapsed=�$��Right=�._��  � Cursor$  �� �� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$	��200��.+��� $#��Добавить/скрыть��$��16(�$��10, 5, 10, 5q�$
��Bold"��� -
   $��CloseAdding��$��0��$��13, 5, 0, 5q�$��Right=�#���   $��
5, 0, 5, 0q�$	�� X ���� -    ��Name$ addFieldsList��$��1��$��14(� �� SelectionMode$ Multiple=����� .R��� $ 
Horizontal=�.+��� -   $��5q�$��14(�$��Courier)����� *Header+	 d� 	IsChecked	 �� *
IsSelected+&   System.Windows.Controls.DataGrid  -   $��testCaseGrid��$
   HorizontalScrollBarVisibility$

 Auto=�$��2��$��10q�   CanUserAddRows .     HeadersVisibility$ Column=�   AutoGenerateColumns .  $��0��$��540.8��$��540.8������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *TestCaseVisibleID+  $ Заголовок��$	 150    
Visibility$ Visible=� �� *TestCaseSummary+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $ Статус��$	 100 $ Visible=� �� *.,TestCaseStatus.TCStatusDescriptionTranlation+  $- 'Шаги воспроизведения��$	 250 $ Visible=� �� *TestCaseSteps+ �� .���  � ��$
 Wrap=�  $+ %Ожидаемый результат��$	 250 $ Visible=� �� *TestCaseExpectedResult+ �� .���  � ��$
 Wrap=�  $/ )Фактический результат��$	 200 $ Visible=� �� *TestCaseActualResult+ �� .���  � ��$
 Wrap=�  $ Создатель��$ Visible=� �� *Userinfo.LastName+  $ Исполнитель��$ Visible=� �� *Userinfo1.LastName+