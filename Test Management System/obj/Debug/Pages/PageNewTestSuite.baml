   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5      3    -Test_Management_System.Pages.PageNewTestSuite   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Test_Management_System.Pages     5        N� Title$  PageNewTestSuite��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��HeaderTS��5      $��0��6    $��18(�6.   $��10, 0, 0, 0q�6<   $��DemiBold"�6Q   �� 5   
   $��Заголовок *��6   $��1��6&   $��10, 10, 0, 0q�63   �� 5   
   -   5        $��TBtestSuiteSummary��5   4   $��1��6   $��197,10,10,0q�6    �� 	MaxLength$	 255��6N   6^   �� 5   
   $��2��6   $��10, 10, 0, 0q�6   $'��!Длинное описание *��63   �� 5   
   -   5        $��TBTestSuiteDescription��5   @   $��2��6   $	��100��6    �� TextWrapping$
 Wrap=�6,   $
 1000��6^   $��197,10,10,0q�6o   �� 5   
   $��3��6   $��10, 10, 0, 0q�6   $#��Короткая метка *��63   �� 5   
   -   5        $��TBTestSuiteLabel��5   5   $��3��6   $��197,10,10,0q�6    65   �� 5!   
   $��4��6   $��10, 10, 0, 0q�6   $��Предусловия:��63   �� 5"   
   -   5        $��TBTestSuitePreconditions��5"   Q   $��4��6   $	��100��6    $
 Wrap=�6-   $	 255��6A   $��197,10,10,0q�6q   �� 5$   
   $��5��6   $��10, 10, 0, 0q�6   $1��+Родительский тест-сьют:��63   �� 5%   
   -   5        $��ComboTestSuiteParentID��5%   5   $��5��6   $��197,10,10,0q�6    $��30��6S    �� DisplayMemberPath$ TestSuiteSummary��6`   �� 5'   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��Bottom=�6W   $��10, 10, 10, 20q�6r   .+�5(      �� -   5        $��SaveTestSuite��5(   L   $?��9Сохранить и выйти к тест-сьютам��6   $	��270��6@   $��0,0,10,0q�6}      RoundedCorners#���   6�   �� 5)      -   5        $��BackToTestSuitePageButton��5)   O   $E��?Выйти к тест-сьютам без сохранения��6   $	��270��6C   #���   6�   5*      5+      5-      