   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  1    +Test_Management_System.Pages.PageBugReports   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageBugReports��.��� -   $��mainGrid�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $.��(Просмотр баг-репортов��$��18(�$��10q�$��0��$��0����  �� Orientation$ 
Horizontal=�$��0, 20, 10, 20q�$��3��$��Right=�$��0��.+��� -   $��AddBR��$��Добавить��   RoundedCorners#���   $	��150��$��0, 0, 10, 0q��� -   $��EditBR��$ ��Редактировать��#���   $	��150��$��0, 0, 10, 0q�{�.  �� -   $��DeleteBR��$��Удалить��#���   $	��150��{�.  �� $��1��$ 
Horizontal=�$��10q�$��0��.+��� $"��Сортировать по ��$��	0,10,0,10q�$y�Hidden=��� $	��400��$��10, 0, 0, 0q�$y�Hidden=�.@��� $0��*дате (от новых к старым)���� $0��*дате (от старых к новым)���� $D��>приоритету (от низкого к высокому)���� $D��>приоритету (от высокого к низкому)���� $T��Nкритичности (от тривиальной к блокирующей)���� $T��Nкритичности (от блокирующей к тривиальной)���� -   $��ChoseBRFields��$%��Просмотреть поля��$��Right=�$��10, 10, 10, 10q�$	��150��#���   $��0��$��1���� -    ��Name$ FormContainer��$��2��$��1��$��10q� �� CornerRadius$ 5��$y�	Collapsed=�$��Right=�._��  � Cursor$  �� �� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$	��200��.+��� $#��Добавить/скрыть��$��16(�$��10, 5, 10, 5q�$
��Bold"��� -   $��CloseAdding��$��0��$��13, 5, 0, 5q�$��Right=�#���   $��
5, 0, 5, 0q�$	�� X ���� -    ��Name$ addFieldsList��$��1��$��14(� �� SelectionMode$ Multiple=����� .R��� $ 
Horizontal=�.+��� -	   $��5q�$��14(�$��Courier)����� *Header+	 d� 	IsChecked	 �� *
IsSelected+&   System.Windows.Controls.DataGrid  -
   $��bugReportGrid��$
   HorizontalScrollBarVisibility$

 Auto=�$��2��$��10q�   HeadersVisibility$ Column=�   CanUserAddRows .     AutoGenerateColumns .  $��0������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Заголовок��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150    
Visibility$ Visible=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *BugReportSummary+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=���  � ��$ 5,5,0,0q�  $- 'Шаги воспроизведения��$	 250 $ Visible=� �� *
BugSteps+ �� .���  � ��$
 Wrap=���  � ��$ 5,5,0,0q�  $+ %Ожидаемый результат��$	 250 $ Visible=� �� *BugExpectedResult+ �� .���  � ��$
 Wrap=���  � ��$ 5,5,0,0q�  $/ )Фактический результат��$	 250 $ Visible=� �� *BugActualResult+ �� .���  � ��$
 Wrap=���  � ��$ 5,5,0,0q�  $ Статус��$	 100 $ Visible=� �� *)'BugReportStatus.BRStatusNameTranslation+  $ Создатель��$ Visible=� �� *Userinfo.LastName+  $ Дата создания��$ Visible=� �� *DateOfCreation+